namespace Razor.UI.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ICatalogService _catalogServcie;
        private readonly IBasketService _basketService;

        public IndexModel(ICatalogService catalogServcie, IBasketService basketService)
        {
            _catalogServcie = catalogServcie ?? throw new ArgumentNullException(nameof(catalogServcie));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public IEnumerable<CatalogModel> ProductList { get; set; } = new List<CatalogModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            ProductList = await _catalogServcie.GetCatalog();
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            var product = await _catalogServcie.GetCatalog(productId);
            var userName = "skm";
            var basket = await _basketService.GetBasket(userName);

            basket.Items.Add(
                new BasketItemModel
                {
                    ProductId = productId,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1,
                    Color = "Black"

                }
                );

            await _basketService.UpdateBasket(basket);
            return RedirectToPage("Cart");
        }
    }
}
