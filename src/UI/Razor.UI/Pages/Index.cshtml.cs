using System.Linq;

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

        public int PageSize = 9;
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; }
        public int TotalItems { get; set; }
        public List<CatalogModel> PagedCatalog { get; set; }
        public IEnumerable<string> CategoryList { get; set; } = new List<string>();
        public IEnumerable<CatalogModel> ProductList { get; set; } = new List<CatalogModel>();
        public IEnumerable<CatalogBrandModel> ProductBrandList { get; set; } = new List<CatalogBrandModel>();
        public IEnumerable<CatalogCategoryModel> ProductCategoryList { get; set; } = new List<CatalogCategoryModel>();

        public async Task<IActionResult> OnGetAsync(string categoryCode, string brandCode)
        {
            ProductBrandList = await _catalogServcie.GetCatalogBrand();
            ProductCategoryList = await _catalogServcie.GetCatalogCategory();

            var productList = await _catalogServcie.GetCatalog();

            // filter products by brand
            if (!string.IsNullOrWhiteSpace(brandCode))
                ProductList = productList.Where(p => p.BrandCode == brandCode);

            // filter products by category
            if (!string.IsNullOrWhiteSpace(categoryCode))
                ProductList = productList.Where(p => string.Equals(p.ParentCategoryCode, categoryCode) || string.Equals(p.ChildCategoryCode, categoryCode));


            if (string.IsNullOrWhiteSpace(brandCode) && string.IsNullOrWhiteSpace(categoryCode))
                ProductList = productList;

            ProductBrandList = ProductBrandList.Select(x =>
                {
                    x.ProductCount = ProductList.Where(p => p.BrandCode == x.Code).Count();
                    return x;
                });

            ProductBrandList = ProductBrandList.Where(x => x.ProductCount > 0).ToList();

            ProductCategoryList = ProductCategoryList.Select(x =>
            {
                x.ProductCount = ProductList.Where(p => p.ParentCategoryCode == x.Code).Count();
                return x;
            });

            ProductCategoryList = ProductCategoryList.Where(x => x.ProductCount > 0).ToList();

            PagedCatalog = ProductList.Skip((PageIndex - 1) * PageSize)
            .Take(PageSize).OrderBy(x => x.Name).ToList();

            TotalItems = ProductList.Count();
            return Page();
        }

        public async Task<IActionResult> OnPostFilterCatalogByBrandAsync(string brandCode)
        {
            return RedirectToPage("/index", new { brandCode });
        }

        public async Task<IActionResult> OnPostFilterCatalogByCategoryAsync(string categoryCode)
        {
            return RedirectToPage("/index", new { categoryCode });
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
                }
                );

            await _basketService.UpdateBasket(basket);
            return RedirectToPage();
        }
    }
}
