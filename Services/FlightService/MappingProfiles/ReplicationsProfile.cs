using AutoMapper;
using FlightService.DataTransfer;
using FlightService.DataTransfer.Messaging;
using FlightService.Models.Replications;

namespace FlightService.MappingProfiles
{
    public class ReplicationsProfile : Profile
    {
        public ReplicationsProfile()
        {
            CreateMap<Airport, AirportReadTransfer>();
            CreateMap<AirportAddress, AirportAdressReadTransfer>();
            CreateMap<AirportPublished, Airport>();
            CreateMap<AirportAdressPublished, AirportAddress>();
        }
    }
}
