namespace Razor.UI

{
    [Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
    public class CartModel : PageModel
    {
        private readonly IBasketService _basketService;
        public BasketModel Cart { get; set; } = new BasketModel();

        public CartModel(IBasketService basketService)
        {
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }


        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await _basketService.GetBasket(this.HttpContext.User.Identity.Name);
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveFromCartAsync(string productId)
        {
            var userName = this.HttpContext.User.Identity.Name;
            var basket = await _basketService.GetBasket(this.HttpContext.User.Identity.Name);

            var item = basket.Items.Single(x => x.ProductId == productId);
            basket.Items.Remove(item);

            var basketUpdated = await _basketService.UpdateBasket(basket);

            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostChangeQuantityAsync(string productId, int quantity)
        {
            var userName = this.HttpContext.User.Identity.Name;
            var basket = await _basketService.GetBasket(this.HttpContext.User.Identity.Name);
            basket.Items.Single(x => x.ProductId == productId).Quantity = quantity;
            var basketUpdated = await _basketService.UpdateBasket(basket);

            return RedirectToPage();
        }


    }
}