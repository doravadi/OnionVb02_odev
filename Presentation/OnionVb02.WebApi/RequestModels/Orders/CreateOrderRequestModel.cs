namespace OnionVb02.WebApi.RequestModels.Orders
{
    public class CreateOrderRequestModel
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}
