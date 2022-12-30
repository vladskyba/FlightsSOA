using AutoMapper;
using ReservationService.DateTransfer;
using ReservationService.Models;

namespace ReservationService.MappingProfiles
{
    public class ReservationProfiles : Profile
    {
        public ReservationProfiles()
        {
            CreateMap<Reservation, ReservationReadTransfer>()
                .ReverseMap();

            CreateMap<Reservation, ReservationCreateTransfer>()
                .ReverseMap();

            CreateMap<ReservationTicket, TicketReadTransfer>()
                .ReverseMap();

            CreateMap<ReservationTicket, TicketBaseTransfer>()
                .ReverseMap();
        }
    }
}
