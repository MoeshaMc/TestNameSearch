using System;
using Microsoft.EntityFrameworkCore;
using NameSearch.Models;

namespace NameSearch.Data
{
    public class UserContext : DbContext 
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
