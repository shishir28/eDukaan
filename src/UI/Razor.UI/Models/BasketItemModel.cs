namespace Razor.UI.Models
{

    public class BasketItemModel
    {
        public decimal Price { get; set; }
        public string SmallImageURL { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }
    }
}
