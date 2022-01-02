using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {

        private readonly ILogger<BasketController> _logger;
        private readonly IBasketRepository _basketRepository;
        private readonly DiscountGrpcService _discountGrpcService;


        public BasketController(IBasketRepository basketRepository, DiscountGrpcService discountGrpcService, ILogger<BasketController> logger)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _discountGrpcService = discountGrpcService ?? throw new ArgumentNullException(nameof(discountGrpcService));
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
                return Ok(basekt ?? new ShoppingCart(userName));
            }
            catch (System.Exception ex)
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
            catch (System.Exception ex)
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
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data in the database");
            }
        }

    }
}