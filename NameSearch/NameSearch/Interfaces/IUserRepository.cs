using System;
using System.Collections.Generic;
using NameSearch.Models;

namespace NameSearch.Interfaces
{
    public interface IUserRepository

    {
        IEnumerable<User> GetUsers(string searchString);
       // User GetUser(string searchString);
    }
}
