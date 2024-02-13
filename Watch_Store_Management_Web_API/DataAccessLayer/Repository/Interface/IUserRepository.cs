using Watch_Store_Management_Web_API.DataAccessLayer.Entities;

namespace Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> ValidateUser(string userName, string password);
    }
}
