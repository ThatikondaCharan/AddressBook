using AddressBook.Models;
using AutoMapper;
using Newtonsoft.Json;
using System.Text.Json;

namespace AddressBook.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles() {
            CreateMap<ContactDetailsViewModel, ContactDetails>()
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserEmail))
               .ForMember(dest => dest.Mobile, opt => opt.MapFrom(src => src.UserMobile))
               .ForMember(dest => dest.LandLine, opt => opt.MapFrom(src => src.UserLandLine))
               .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.UserWebsite))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src=>JsonConvert.SerializeObject(src.Address)));
            CreateMap<ContactDetails, ContactDetailsViewModel>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserMobile, opt => opt.MapFrom(src => src.Mobile))
                .ForMember(dest => dest.UserLandLine, opt => opt.MapFrom(src => src.LandLine))
                .ForMember(dest => dest.UserWebsite, opt => opt.MapFrom(src => src.Website))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => JsonConvert.DeserializeObject(src.Address)));
            
        }
    }
}
