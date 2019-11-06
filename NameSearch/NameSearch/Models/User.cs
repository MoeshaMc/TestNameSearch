using System;
using Newtonsoft.Json;

namespace NameSearch.Models
{
    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }     
        public string Username { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
 
        public string SearchString { get; set; }
            }
}
