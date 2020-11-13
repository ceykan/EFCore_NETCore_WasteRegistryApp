using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WasteRegistry.API.Token.Model;

namespace WasteRegistry.API.Token.Services
{
    public interface IUserService
    {
        bool IsValidUser(UserModel user);

    }
}
