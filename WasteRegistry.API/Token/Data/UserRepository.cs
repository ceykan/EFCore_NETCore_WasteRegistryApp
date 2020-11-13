using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WasteRegistry.API.Data.DAL.Data;
using WasteRegistry.API.Data.DML;
using WasteRegistry.API.Token.Model;

namespace WasteRegistry.API.Token.Data
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(DbContextOptions<WasteRegistrationContext> options) : base(options)
        {

        }
        public bool IsValidUser(UserModel user)
        {
            return Context.User.Any(x => x.Username.ToLower().Equals(user.Username.ToLower()) && x.Password.Equals(user.Password));
        }
    }
}
