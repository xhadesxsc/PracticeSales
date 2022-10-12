using Practice.Ecommerce.Domain.Entity;
using Practice.Ecommerce.Domain.Interface;
using Practice.Ecommerce.Infrastructure.Interface;

namespace Practice.Ecommerce.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;
        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public Users Authenticate(string userName, string password)
        {
            return _usersRepository.Authenticate(userName, password);
        }
    }
}
