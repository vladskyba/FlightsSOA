using AutoMapper;
using Airplane.DataTransfer;
using Airplane.Models;

namespace Airplane.MappingProfiles
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
