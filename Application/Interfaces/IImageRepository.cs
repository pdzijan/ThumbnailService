﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IImageRepository
    {
        Task<Guid> AddImage(Image image);  
        Task<Image> GetImage(Guid id);
    }
}
