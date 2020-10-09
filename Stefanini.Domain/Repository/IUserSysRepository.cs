using Stefanini.Domain.Entity;
using System.Collections.Generic;

namespace Stefanini.Domain.Repository
{
    public interface IUserSysRepository
    {
        UserSys Get(int id);
        IEnumerable<UserSys> GetAll();
        //bool TryLogin(string userName, string userPassword);
    }
}
