using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class Image
    {
        [Key]
        public Guid ImageUid { get; set; }
        public string? Url { get; set; }
        public int Status { get; set; }
        public string? ErrorMessage { get; set; }
        public byte[]? TumbnailImage { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
    }
}