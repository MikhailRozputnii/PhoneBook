using Microsoft.AspNetCore.Identity;
using PhoneBook.BusinessLogic.DTO;
using PhoneBook.Contracts;
using PhoneBook.Domains;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.BusinessLogic.Services.IdentityProvider
{
    public partial class UserStore : IUserStore<UserDto>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ManageUsers _manage;

        public UserStore(IRepositoryWrapper repository, ManageUsers manage)
        {
            _repository = repository;
            _manage = manage;
        }
        public  async Task<IdentityResult> CreateAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));

            return await _manage.CreateAsync(userDto);
        }

        public async Task<IdentityResult> DeleteAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));

            return await _manage.DeleteAsync(userDto);
        }

        public void Dispose() { }

        public async Task<UserDto> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userId == null) throw new ArgumentNullException(nameof(userId));
            Guid idGuid;
            if (!Guid.TryParse(userId, out idGuid))
            {
                throw new ArgumentException("Not a valid Guid id", nameof(userId));
            }

            return await _manage.FindByIdAsync(idGuid);
        }

        public async Task<UserDto> FindByNameAsync(string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userName == null) throw new ArgumentNullException(nameof(userName));

            return await _manage.FindByEmailAsync(userName);
        }

        public Task<string> GetNormalizedUserNameAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }
            return Task.FromResult(userDto.Email);
        }

        public Task<string> GetUserIdAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));

            return Task.FromResult(userDto.Id.ToString());
        }

        public Task<string> GetUserNameAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));

            return Task.FromResult(userDto.Email);
        }

        public Task SetNormalizedUserNameAsync(UserDto userDto, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));
            if (normalizedName == null) throw new ArgumentNullException(nameof(normalizedName));

            userDto.Email = normalizedName;
            return Task.FromResult<object>(null);
        }

        public Task SetUserNameAsync(UserDto userDto, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }
            userDto.Email = userName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }


            return await _manage.UpdateAsync(userDto); ;
        }
    }
}
