using TunifyPrj.Models;

namespace TunifyPrj.Repositories.Interfaces
{
    public interface IUser
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int userId);
        Task<User> InsertAsync(User user);
        Task<User> UpdateAsync(int id,User user);
        Task<User> DeleteAsync(int userId);
    }
}