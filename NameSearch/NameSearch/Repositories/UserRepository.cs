using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NameSearch.Interfaces;
using NameSearch.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace NameSearch.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IList<User> SearchedList { get; set; }
        public UserRepository()
        {
        }
        public IEnumerable<User> GetUsers(string searchString)
        {
            var client = new RestClient($"https://api.github.com/search/users?q={searchString}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
               
                var content = JsonConvert.DeserializeObject<List<User>>(response.Content);
                foreach (var item in content)
                {
                    User user = new User()
                    {
                        AvatarUrl = item.AvatarUrl,
                        Username = "User",
                        Name = item.Name,
                        Location = item.Location,
                        Email = item.Email
                    };
                    SearchedList.Add(user);
                } 
                return SearchedList;
            }
            return null;
        }
    
        public UserTableViewModel GetUsers()
        {
            return new UserTableViewModel() { UserList = SearchedList };
        }   
    }
}
