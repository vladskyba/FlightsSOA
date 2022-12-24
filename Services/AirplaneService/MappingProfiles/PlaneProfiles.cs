using AutoMapper;
using PlaneTransport.DataTransfer;
using PlaneTransport.Models;

namespace PlaneTransport.MappingProfiles
{
    public class PlaneProfiles : Profile
    {
        public PlaneProfiles()
        {
            CreateMap<Plane, PlaneBaseTransfer>()
                .ReverseMap();

            CreateMap<Plane, PlaneReadTransfer>()
                .ReverseMap();

            CreateMap<PlaneSeat, PlaneSeatBaseTransfer>()
                .ReverseMap();

            CreateMap<PlaneSeat, PlaneSeatReadTransfer>()
                .ReverseMap();
        }
    }
}
