namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults
{
    public class GetOrderByIdQueryResult
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
        public string? UserName { get; set; }
    }
}
