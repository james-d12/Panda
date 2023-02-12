using Panda.Application.Common.Interfaces.Persistence;
using Panda.Domain.Entities;

namespace Panda.Infrastructure.Persistence
{
    public sealed class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(user => user.Email == email);
        }
    }
}
