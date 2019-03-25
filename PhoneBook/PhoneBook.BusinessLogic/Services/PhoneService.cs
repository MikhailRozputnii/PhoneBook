using AutoMapper;
using PhoneBook.BusinessLogic.Contracts;
using PhoneBook.BusinessLogic.DTO;
using PhoneBook.Contracts;
using PhoneBook.Domains;
using System;
using System.Collections.Generic;
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
            var result = GetPhone(phoneDto, userId);
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

        public (IEnumerable<PhoneDto>, int) GetPhones(ref int curentPage, int pageSize, string search, Guid userId)
        {

            var query = _repositoryWrapper.Phone.GetByCondition(i => i.UserId == userId);
            var result = _mapper.Map<IEnumerable<PhoneDto>>(query);
            var count = result.Count();
            if (!string.IsNullOrEmpty(search))
            {
                result = Search(search, userId);
                count = result.Count();
            }
            result = FilterPage(result, curentPage, pageSize);
            return (result, count);
        }

        public PhoneDto GetPhone(Guid phoneId, Guid userId)
        {
            var phone = _repositoryWrapper.Phone.GetModelByCondition(i => i.UserId == userId && i.Id == phoneId);
            var phoneDto = _mapper.Map<PhoneDto>(phone);
            return phoneDto;
        }

        public void Delete(Guid phoneId, Guid userId)
        {
            var phone = _repositoryWrapper.Phone.GetModelByCondition(i => i.Id == phoneId && i.UserId == userId);
            if (phone!=null) {
                _repositoryWrapper.Phone.Delete(phone);
                _repositoryWrapper.Save();
            }
        }

        private PhoneDto GetPhone(PhoneDto phoneDto, Guid userId)
        {
            if (phoneDto != null && IsExistsModelWithUser(userId))
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

        private bool IsExistsModelWithUser(Guid userId)
        {
            if (userId == Guid.Empty)
                return false;
            return _repositoryWrapper.User.GetModelByCondition(i => i.Id == userId) != null;
        }

        private IEnumerable<PhoneDto> Search(string search, Guid userId)
        {
            search = search.Trim(' ');
            var result = _repositoryWrapper.Phone.GetByCondition(i => i.UserId == userId).Where(u => u.Name.Contains(search) ||
                       u.PhoneNumber.Contains(search));
            var resultDto = _mapper.Map<IEnumerable<PhoneDto>>(result);
            return resultDto;
        }

        private IEnumerable<PhoneDto> FilterPage(IEnumerable<PhoneDto> phones, int skip, int take)
        {
            return phones.Skip((skip - 1) * take).
                Take(take).ToList();
        }
    }
}
