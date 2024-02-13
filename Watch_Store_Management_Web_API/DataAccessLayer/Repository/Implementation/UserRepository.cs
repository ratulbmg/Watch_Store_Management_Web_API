using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Watch_Store_Management_Web_API.DataAccessLayer.Context;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface;

namespace Watch_Store_Management_Web_API.DataAccessLayer.Repository.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly WatchStoreDBContext watchStoreDBContext;

        public UserRepository(WatchStoreDBContext watchStoreDBContext) : base(watchStoreDBContext)
        {
            this.watchStoreDBContext = watchStoreDBContext;
        }

        public async Task<User?> ValidateUser(string userName, string password)
        {
            var user = await watchStoreDBContext.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.UserName == userName);
            if (user is not null)
            {
                var res = new PasswordHasher<object?>().VerifyHashedPassword(null, user.PasswordHash, password);
                if (res.Equals(PasswordVerificationResult.Success)) return user;
            }
            return null;
        }
    }
}
