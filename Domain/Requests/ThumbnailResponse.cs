namespace Domain.Requests
{
    public class ThumbnailResponse
    {
        public Guid ThumbnailUid { get; set; }
        public byte[]? Content { get; set; }
        public int Status { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
