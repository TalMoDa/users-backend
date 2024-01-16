using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UsersApi.Data.Entites;
using UsersApi.Models;

namespace UsersApi.Services.Interfaces;

public interface IUsersService
{
    Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UserDto> CreateAsync(CreateUserRequestDto user, CancellationToken cancellationToken = default);
    Task<UserDto> UpdateAsync(UserDto user, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}