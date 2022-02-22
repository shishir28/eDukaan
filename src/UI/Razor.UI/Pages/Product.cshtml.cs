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

        public int PageSize = 10;
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; }
        public int TotalItems { get; set; }
        public List<CatalogModel> PagedCatalog { get; set; }
        public IEnumerable<CatalogCategoryModel> ProductCategoryList { get; set; } = new List<CatalogCategoryModel>();
        public IEnumerable<string> CategoryList { get; set; } = new List<string>();
        public IEnumerable<CatalogModel> ProductList { get; set; } = new List<CatalogModel>();
        public IEnumerable<CatalogBrandModel> ProductBrandList { get; set; } = new List<CatalogBrandModel>();


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

                ProductBrandList = ProductBrandList.Select(x =>
                {
                    x.ProductCount = productList.Where(p => p.BrandCode == x.Code).Count();
                    return x;
                });

                ProductBrandList = ProductBrandList.Where(x => x.ProductCount > 0).ToList();

                ProductCategoryList = ProductCategoryList.Select(x =>
                {
                    x.ProductCount = productList.Where(p => p.ParentCategoryCode == x.Code).Count();
                    return x;
                });

                ProductCategoryList = ProductCategoryList.Where(x => x.ProductCount > 0).ToList();

                PagedCatalog = ProductList.Skip((PageIndex - 1) * PageSize)
                .Take(PageSize).ToList();

                TotalItems = ProductList.Count();
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
                  SmallImageURL = product.SmallImageURL
              });

            var basketUpdated = await _basketService.UpdateBasket(basket);
            return RedirectToPage();

            // return RedirectToPage("Cart");
        }
    }
}