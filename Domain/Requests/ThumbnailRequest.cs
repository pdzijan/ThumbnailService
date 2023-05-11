using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests
{
    public class ThumbnailRequest
    {
        public string? Url { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
    }
}
