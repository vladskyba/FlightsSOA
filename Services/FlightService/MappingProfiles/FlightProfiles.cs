using AutoMapper;
using FlightService.DataTransfer;

namespace FlightService.MappingProfiles
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
