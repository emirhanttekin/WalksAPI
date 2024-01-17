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
            CreateMap<AddWalkRequesDto,Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();

        }

     
    }
}
