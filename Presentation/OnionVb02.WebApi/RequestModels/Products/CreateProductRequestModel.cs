namespace OnionVb02.WebApi.RequestModels.Products
{
    public class CreateProductRequestModel
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}
