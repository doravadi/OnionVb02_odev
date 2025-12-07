namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults
{
    public class GetAppUserProfileQueryResult
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
        public string? UserName { get; set; }
    }
}
