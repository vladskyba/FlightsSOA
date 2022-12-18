using AutoMapper;
using Flight.DataTransfer;
using Flight.DataTransfer.Messaging;
using Flight.Models.Replications;

namespace Flight.MappingProfiles
{
    public class ReplicationsProfile : Profile
    {
        public ReplicationsProfile()
        {
            CreateMap<Airport, AirportReadTransfer>();
            CreateMap<AirportAddress, AirportAdressReadTransfer>();
            
            CreateMap<AirportPublished, Airport>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));

            CreateMap<AirportAdressPublished, AirportAddress>();
        }
    }
}
