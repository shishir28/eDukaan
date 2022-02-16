namespace Shopping.Aggregator.Models
{
    public class BasketItemExtendedModel
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }

        //product properties

        public string ParentCategoryCode { get; set; }
        public string ChildCategoryCode { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string SmallImageURL { get; set; }
        public string MediumImageURL { get; set; }
        public string LargeImageURL { get; set; }


    }
}
