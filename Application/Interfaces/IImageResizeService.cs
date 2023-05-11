using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IImageResizeService
    {
        Task<byte[]> Resize(byte[] stream, int sizeX, int sizeY);
    }
}
