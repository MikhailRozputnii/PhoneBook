using AutoMapper;
using PhoneBook.BusinessLogic.DTO;
using PhoneBook.Domains;
using PhoneBook.Models;

namespace PhoneBook.Configs.MapperProfiles
{
    public class ViewModelProfile : Profile
    {
        public ViewModelProfile()
        {
            CreateMap<PhoneDto, PhoneViewModel>();
        }
    }
}
