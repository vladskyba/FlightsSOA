using Airport.DataTransfer;
using Airport.Models;
using AutoMapper;

namespace Airport.MappingProfiles
{
    public class AirportProfiles : Profile
    {
        public AirportProfiles()
        {
            CreateMap<AirportEntity, AirportCreateTransfer>()
                .ReverseMap();

            CreateMap<AirportEntity, AirportReadTransfer>()
            .ReverseMap();

            CreateMap<AirportAdressBaseTransfer, AirportAddress>()
            .ReverseMap();
        }
    }
}
