using Airport.DataTransfer;
using Airport.DataTransfer.Messaging;
using AutoMapper;

namespace Airport.MappingProfiles
{
    public class MessagePublishingProfile : Profile
    {
        public MessagePublishingProfile()
        {
            CreateMap<AirportReadTransfer, AirportPublished>();
            CreateMap<AirportAdressReadTransfer, AirportAdressPublished>();
        }
    }
}
