namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults
{
    public class GetProductQueryResult
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
