using Practice.Ecommerce.Application.DTO;
using Practice.Ecommerce.Transversal.Common;

namespace Practice.Ecommerce.Application.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDto> Authenticate(string username, string password);
    }
}
