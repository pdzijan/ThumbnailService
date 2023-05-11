using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
