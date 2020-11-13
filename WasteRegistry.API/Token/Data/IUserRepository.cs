using WasteRegistry.API.Data.DAL.Data.Interfaces;
using WasteRegistry.API.Token.Model;

namespace WasteRegistry.API.Token.Data
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        bool IsValidUser(UserModel user);
    }
}
