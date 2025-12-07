namespace OnionVb02.WebApi.RequestModels.AppUserProfiles
{
    public class UpdateAppUserProfileRequestModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
    }
}
