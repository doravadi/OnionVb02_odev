namespace OnionVb02.WebApi.ResponseModels.Products
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
