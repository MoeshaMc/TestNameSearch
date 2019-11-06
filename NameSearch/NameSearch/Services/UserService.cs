using System;
using System.Collections.Generic;
using NameSearch.Interfaces;
using NameSearch.Models;

namespace NameSearch.Services
{
    public class UserService 
    {
        private readonly IUserRepository _userRepository;
        private string SearchString = "";
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers(string searchString)
        {
           SearchString = searchString;
           return _userRepository.GetUsers(searchString);
        }

        




    }
    
}
