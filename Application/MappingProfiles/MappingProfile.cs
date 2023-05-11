using AutoMapper;
using Domain.Entities;
using Domain.Requests;

namespace WebApi.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Thumbnail, ThumbnailRequest>();
            this.CreateMap<ThumbnailRequest, Thumbnail>().AfterMap((src, dst) =>
            {

            });
            this.CreateMap<Thumbnail, ThumbnailResponse>();
            this.CreateMap<ThumbnailResponse, Thumbnail>();
        }
    }
}
