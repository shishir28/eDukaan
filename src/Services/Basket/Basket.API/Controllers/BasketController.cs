using AutoMapper;
using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize("ClientIdPolicy")]
    public class BasketController : ControllerBase
    {

        private readonly ILogger<BasketController> _logger;
        private readonly IBasketRepository _basketRepository;
        private readonly IDiscountGrpcService _discountGrpcService;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository, IDiscountGrpcService discountGrpcService,
        IPublishEndpoint publishEndpoint,
        IMapper mapper, ILogger<BasketController> logger)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _discountGrpcService = discountGrpcService ?? throw new ArgumentNullException(nameof(discountGrpcService));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShoppingCart))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {

            try
            {
                var basekt = await _basketRepository.GetBasket(userName);
                if (basekt != null)
                {
                    var qry = from item in basekt.Items
                              group item by item.ProductId into g
                              select new ShoppingCartItem
                              {
                                  ProductId = g.Key,
                                  SmallImageURL = g.FirstOrDefault().SmallImageURL,
                                  Price = g.FirstOrDefault().Price,
                                  ProductName = g.FirstOrDefault().ProductName,
                                  Quantity = g.Sum(x => x.Quantity)
                              };
                    basekt.Items = qry.ToList();
                }
                return Ok(basekt ?? new ShoppingCart(userName));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ShoppingCart))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            try
            {
                // call Discount gRPC 
                // to get the discount on product 
                foreach (var item in basket.Items)
                {
                    var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
                    item.Price -= coupon.Amount;
                }
                return Ok(await _basketRepository.UpdateBasket(basket));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }

        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ShoppingCart>> DeleteBasket(string userName)
        {
            try
            {
                await _basketRepository.DeleteBasket(userName);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data in the database");
            }
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        {
            try
            {
                //get the existing basket with total price
                var basket = await _basketRepository.GetBasket(basketCheckout.UserName);
                if (basket == null)
                    return BadRequest();

                //Create basket checkout event
                var basketCheckoutEvent = _mapper.Map<BasketCheckoutEvent>(basketCheckout);

                //Set the total price on checkout event
                basketCheckoutEvent.TotalPrice = basket.TotalPrice;
                // Send the event to the Rabbit MQ
                await _publishEndpoint.Publish<BasketCheckoutEvent>(basketCheckoutEvent);
                // remove the basket from redis cache
                await _basketRepository.DeleteBasket(basketCheckout.UserName);

                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }

    }
}