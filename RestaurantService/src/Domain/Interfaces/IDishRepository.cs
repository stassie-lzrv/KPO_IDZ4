using Domain.Entity;

namespace Domain.Interfaces;

public interface IDishRepository
{
    Task<long> CreateAsync(DishEntity dishEntity);
    Task<DishEntity> GetAsync(long id);
    Task<List<DishEntity>> GetAllAsync();
    Task<List<DishEntity>> GetManyByIdAsync(long[] ids);
    Task<long> UpdateAsync(DishEntity dishEntity);
    Task<long> DeleteAsync(long id);
    Task<long> DecreaseQuantityAsync(IEnumerable<(long, int)> dishes);
}