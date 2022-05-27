namespace eShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } = 0;
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Image { get; set; } = "images/no-image.png";

    }
}