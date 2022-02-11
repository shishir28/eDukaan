namespace Razor.UI
{
    [Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
    public class ProductModel : PageModel
    {
        private readonly ICatalogService _catalogServcie;
        private readonly IBasketService _basketService;

        public ProductModel(ICatalogService catalogServcie, IBasketService basketService)
        {
            _catalogServcie = catalogServcie ?? throw new ArgumentNullException(nameof(catalogServcie));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public IEnumerable<string> CategoryList { get; set; } = new List<string>();
        public IEnumerable<CatalogModel> ProductList { get; set; } = new List<CatalogModel>();
        public IEnumerable<CatalogBrandModel> ProductBrandList { get; set; } = new List<CatalogBrandModel>();
        public IEnumerable<CatalogCategoryModel> ProductCategoryList { get; set; } = new List<CatalogCategoryModel>();



        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(string categoryName)
        {
            var productList = await _catalogServcie.GetCatalog();
            //CategoryList = productList.Select(p => p.Category).ToList();

            //if (!string.IsNullOrWhiteSpace(categoryName))
            //{
            //    ProductList = productList.Where(p => p.Category == categoryName);
            //    SelectedCategory = categoryName;
            //}
            //else
            {
                ProductList = productList;
                ProductBrandList = await _catalogServcie.GetCatalogBrand();
                ProductCategoryList = await _catalogServcie.GetCatalogCategory();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {

            var product = await _catalogServcie.GetCatalog(productId);
            var basket = await _basketService.GetBasket(this.HttpContext.User.Identity.Name);

            basket.Items.Add(
              new BasketItemModel
              {
                  ProductId = productId,
                  ProductName = product.Name,
                  Price = product.Price,
                  Quantity = 1,
                  Color = "Black"
              });

            var basketUpdated = await _basketService.UpdateBasket(basket);
            return RedirectToPage("Cart");
        }
    }
}