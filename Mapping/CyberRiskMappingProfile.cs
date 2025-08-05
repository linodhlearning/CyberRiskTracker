using AutoMapper;
using CyberRiskTracker.Data.Entities;
using CyberRiskTracker.Models;

namespace CyberRiskTracker.Mapping
{ 
    public class CyberRiskMappingProfile : Profile
    {
        public CyberRiskMappingProfile()
        {
            CreateMap<AssetEntity, Asset>().ReverseMap();
            CreateMap<LoginAttemptEntity, LoginAttempt>().ReverseMap();

            CreateMap<RiskItemEntity, RiskItem>()
                .ForMember(dest => dest.ImageFullPath, opt => opt.MapFrom(src => $"/images/{src.ImageUrl}"));

            CreateMap<RiskItem, RiskItemEntity>()
                .ForMember(dest => dest.ImageFullPath, opt => opt.Ignore());
        }
    }

}
