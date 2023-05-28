using Domain.Entity;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<long> InsertAsync(UserEntity user);
    Task<UserEntity?> GetByEmailAsync(string email);
    Task<UserEntity?> GetByIdAsync(long id);
}