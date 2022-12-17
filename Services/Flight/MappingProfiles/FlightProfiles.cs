using AutoMapper;
using Flight.DataTransfer;

namespace Flight.MappingProfiles
{
    public class FlightProfiles : Profile
    {
        public FlightProfiles()
        {
            CreateMap<Models.Flight, FlightReadTransfer>()
                .ReverseMap();

            CreateMap<Models.Flight, FlightBaseTransfer>()
                .ReverseMap();
        }
    }
}
