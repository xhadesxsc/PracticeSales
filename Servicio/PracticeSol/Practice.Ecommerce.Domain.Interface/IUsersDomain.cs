using Practice.Ecommerce.Domain.Entity;

namespace Practice.Ecommerce.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username, string password);
    }
}
