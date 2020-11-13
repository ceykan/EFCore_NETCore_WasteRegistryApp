using System;
using System.Linq;
using System.Net;
using WasteRegistry.API.Data.DAL.Data;
using WasteRegistry.API.Token.Model;
using Microsoft.Extensions.DependencyInjection;
using WasteRegistry.API.Token.Data;

namespace WasteRegistry.API.Token.Services
{
    public class UserService : IUserService
    {
        private readonly IServiceProvider _provider;

        public UserService(IServiceProvider provider )
        {
            _provider = provider;
        }
        public bool IsValidUser(UserModel user)
        {
            return  _provider.GetService<IUserRepository>().IsValidUser(user);
        }
    }
}
