using AutoMapper;
using PhoneBook.BusinessLogic.DTO;
using PhoneBook.Domains;

namespace PhoneBook.BusinessLogic.Configs.MapperProfiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
