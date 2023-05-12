using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Thumbnail
    {
        [Key]
        public Guid ThumbnailUid { get; set; }
        public byte[]? Content { get; set; }
        public string? Url { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public DateTime InsertDate { get; set; }
        public int Status { get; set; }
        public string? ErrorMessage { get; set; }
    }
}