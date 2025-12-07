namespace OnionVb02.WebApi.ResponseModels.Orders
{
    public class OrderResponseModel
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
        public string? UserName { get; set; }
    }
}
