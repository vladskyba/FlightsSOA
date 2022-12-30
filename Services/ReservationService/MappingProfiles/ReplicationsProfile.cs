using AutoMapper;
using ReservationService.DataTransfer;
using ReservationService.Models.Replications;

namespace ReservationService.MappingProfiles
{
    public class ReplicationsProfile : Profile
    {
        public ReplicationsProfile()
        {
            CreateMap<Airport, AirportReadTransfer>();
            CreateMap<Flight, FlightReadTransfer>();
            CreateMap<AirportAddress, AirportAdressReadTransfer>();
        }
    }
}
