namespace Identity.API
{
    public class AppSettings
    {
        public string RazorClient { get; set; }
        public string CatalogApiClient { get; set; }
        public string BasketApiClient { get; set; }
        public string DiscountApiClient { get; set; }
        public string OrderingApiClient { get; set; }
        public string WebShoppingAgg { get; set; }
        public bool UseCustomizationData { get; set; }
        public string TokenLifetimeMinutes { get; set; }
        public bool UseVault { get; set; }
        public int PermanentTokenLifetimeDays { get; set; }

    }
}
