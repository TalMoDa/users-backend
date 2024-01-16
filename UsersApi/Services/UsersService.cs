using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using UsersApi.Data.Entites;
using UsersApi.Data.Repositories.Interfaces;
using UsersApi.Models;
using UsersApi.Services.Interfaces;

namespace UsersApi.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var users = await _usersRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _usersRepository.GetAsync(id, cancellationToken);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> CreateAsync(CreateUserRequestDto user, CancellationToken cancellationToken = default)
    {
        var userEntity = _mapper.Map<User>(user);
        await _usersRepository.AddAsync(userEntity, cancellationToken);
        await _usersRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<UserDto>(userEntity);
    }

    public async Task<UserDto> UpdateAsync(UserDto user, CancellationToken cancellationToken = default)
    {
        var dbUser = await _usersRepository.GetAsync(user.Id, cancellationToken);
        dbUser = _mapper.Map(user, dbUser);
        _usersRepository.Update(dbUser);
        await _usersRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<UserDto>(dbUser);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _usersRepository.GetAsync(id, cancellationToken);
        _usersRepository.Delete(user);
        await _usersRepository.SaveChangesAsync(cancellationToken);
    }
}