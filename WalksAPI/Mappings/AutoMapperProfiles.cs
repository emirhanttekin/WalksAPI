using AutoMapper;
using WalksAPI.Models.Domain;
using WalksAPI.Models.Domain.DTO;

namespace WalksAPI.Mappings
{
    public class AutoMapperProfiles : Profile

    {
        public AutoMapperProfiles()
        {

            CreateMap<Region , RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

        }

     
    }
}
