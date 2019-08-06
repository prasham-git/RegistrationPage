using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RegistrationPage.Models;

namespace RegistrationPage.DataAccess
{
    public class UserDbContext : DbContext
    {
        public UserDbContext():base("name=RegPageConnection")
        {
        }
        public DbSet<User> users{get; set;}
    }
}