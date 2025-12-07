namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults
{
    public class GetOrderDetailQueryResult
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? OrderAddress { get; set; }
    }
}
