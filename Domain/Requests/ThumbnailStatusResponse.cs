namespace Domain.Requests
{
    public class ThumbnailStatusResponse
    {
        public Guid ThumbnailUid { get; set; }     
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
