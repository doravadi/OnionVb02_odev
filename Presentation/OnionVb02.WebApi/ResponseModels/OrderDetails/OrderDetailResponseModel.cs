namespace OnionVb02.WebApi.ResponseModels.OrderDetails
{
    public class OrderDetailResponseModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? OrderAddress { get; set; }
    }
}
