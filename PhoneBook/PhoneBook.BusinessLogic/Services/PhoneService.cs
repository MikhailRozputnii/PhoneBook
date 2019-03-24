using AutoMapper;
using PhoneBook.BusinessLogic.Contracts;
using PhoneBook.BusinessLogic.DTO;
using PhoneBook.Contracts;
using PhoneBook.Domains;
using System;
using System.Linq;

namespace PhoneBook.BusinessLogic.Services
{
    public class PhoneService : IPhoneService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        public PhoneService(IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }
        public PhoneDto Create(PhoneDto phoneDto, Guid userId)
        {
            var result = SearchPhone(phoneDto, userId);
            if (result == null)
            {
                var entity = _mapper.Map<Phone>(phoneDto);
                entity.CreateDate = DateTime.UtcNow;
                entity.UserId = userId;
                _repositoryWrapper.Phone.Create(entity);
                _repositoryWrapper.Save();
            }

            return result;
        }

        private bool IsExistsUser(Guid userId)
        {
            if (userId == Guid.Empty)
                return false;
            return _repositoryWrapper.User.GetModelByCondition(i => i.Id == userId) != null;
        }

        private PhoneDto SearchPhone(PhoneDto phoneDto, Guid userId)
        {
            if (phoneDto != null && IsExistsUser(userId))
            {
                var result = _repositoryWrapper.Phone.GetByCondition(i => i.UserId == userId)
                                                             .Where(i => i.Name == phoneDto.Name
                                                                   || i.PhoneNumber == phoneDto.PhoneNumber).FirstOrDefault();
                if (result != null)
                {
                    return _mapper.Map<PhoneDto>(result);
                }
            }
            return null;
        }
    }
}
