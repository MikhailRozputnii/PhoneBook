using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PhoneBook.BusinessLogic.DTO;
using PhoneBook.Contracts;
using PhoneBook.Domains;
using System;
using System.Threading.Tasks;

namespace PhoneBook.BusinessLogic.Services.IdentityProvider
{
    public class ManageUsers
    {
        private IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ManageUsers(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IdentityResult> CreateAsync(UserDto userDto)
        {
            if (userDto != null)
            {
                var entity = _mapper.Map<User>(userDto);
                _repositoryWrapper.User.Create(entity);
                var isExists = _repositoryWrapper.User.GetUserByCondition(i => i.Email == userDto.Email) != null;
                if (isExists)
                {
                    return IdentityResult.Success;
                }
            }

            return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {userDto.Email}." });
        }

        public async Task<IdentityResult> DeleteAsync(UserDto userDto)
        {
            var entity = _repositoryWrapper.User.GetUserByCondition(i => i.Id == userDto.Id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                _repositoryWrapper.User.Update(entity);
                return IdentityResult.Success;
            }
            return IdentityResult.Failed(new IdentityError { Description = $"Could not delete user {userDto.Email}." });
        }


        public async Task<UserDto> FindByIdAsync(Guid userId)
        {
            var entity = _repositoryWrapper.User.GetUserByCondition(i => i.Id == userId);
            var userDto = _mapper.Map<UserDto>(entity);
            return userDto;
        }

        public async Task<IdentityResult> UpdateAsync(UserDto userDto)
        {
            var entity = _repositoryWrapper.User.GetUserByCondition(i => i.Id == userDto.Id);
            if (entity != null)
            {
                entity.Email = userDto.Email;
                entity.PasswordHash = userDto.PasswordHash;
                _repositoryWrapper.User.Update(entity);
                return IdentityResult.Success;
            }
            return IdentityResult.Failed(new IdentityError { Description = $"Could not update user {userDto.Email}." });
        }


        public async Task<UserDto> FindByEmailAsync(string email)
        {
            var entity = _repositoryWrapper.User.GetUserByCondition(i => i.Email == email);
            var userDto = _mapper.Map<UserDto>(entity);
            return userDto;
        }
    }
}
