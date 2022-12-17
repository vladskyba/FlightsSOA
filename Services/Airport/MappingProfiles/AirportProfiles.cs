using Airport.DataTransfer;
using Airport.Models;
using AutoMapper;

namespace Airport.MappingProfiles
{
    public class AirportProfiles : Profile
    {
        public AirportProfiles()
        {
            CreateMap<AirportEntity, AirportCreateDto>()
                .ReverseMap();

            CreateMap<AirportEntity, AirportReadDto>()
            .ReverseMap();

            CreateMap<AirportAddressDto, AirportAddress>()
            .ReverseMap();
        }
    }
}
