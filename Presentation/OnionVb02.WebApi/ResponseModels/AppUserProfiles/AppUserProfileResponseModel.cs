namespace OnionVb02.WebApi.ResponseModels.AppUserProfiles
{
    public class AppUserProfileResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
        public string? UserName { get; set; }
    }
}
