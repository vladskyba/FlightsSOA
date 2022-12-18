using Airport.DataTransfer;
using Airport.Models;
using AutoMapper;

namespace Airport.MappingProfiles
{
    public class AirportProfiles : Profile
    {
        public AirportProfiles()
        {
            CreateMap<Models.Airport, AirportCreateTransfer>()
                .ReverseMap();

            CreateMap<Models.Airport, AirportReadTransfer>()
            .ReverseMap();

            CreateMap<AirportAdressBaseTransfer, AirportAddress>()
            .ReverseMap();
        }
    }
}
