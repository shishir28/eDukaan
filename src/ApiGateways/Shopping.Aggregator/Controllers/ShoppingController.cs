using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services;

namespace Shopping.Aggregator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShoppingController : ControllerBase
    {

        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public ShoppingController(ICatalogService catalogService, IBasketService basketService, IOrderService orderService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet("{userName}", Name = "GetShopping")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShoppingModel))]
        public async Task<ActionResult<ShoppingModel>> GetShopping(string userName)
        {
            // Get the basket for the user
            var basket = await _basketService.GetBasket(userName);

            // foreach basket item, get the product and add its attribute to the basket item
            foreach (var item in basket.Items)
            {
                var product = await _catalogService.GetCatalog(item.ProductId);
                item.ProductName = product.Name;
                item.Category = product.Category;
                item.Summary = product.Summary;
                item.Description = product.Description;
                item.ImageFile = product.ImageFile;
            }

            // Get the orders for the user
            var orders = await _orderService.GetOrdersByUserName(userName);

            // Return the shopping model
            var result = new ShoppingModel
            {

                UserName = userName,
                BasketWithProducts = basket,
                Orders = orders
            };
            return Ok(result);

        }

    }
}
