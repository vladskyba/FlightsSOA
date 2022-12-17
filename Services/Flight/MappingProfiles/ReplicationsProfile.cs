using AutoMapper;
using Flight.DataTransfer;
using Flight.Models.Replications;

namespace Flight.MappingProfiles
{
    public class ReplicationsProfile : Profile
    {
        public ReplicationsProfile()
        {
            CreateMap<Airport, AirportReadTransfer>()
                .ReverseMap();

            CreateMap<AirportAddress, AirportAdressReadTransfer>()
                .ReverseMap();
        }
    }
}
