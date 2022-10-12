using Practice.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Ecommerce.Infrastructure.Interface
{
    public interface IUsersRepository
    {
        Users Authenticate(string username, string password);
    }
}
