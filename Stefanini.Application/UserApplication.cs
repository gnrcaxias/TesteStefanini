using Stefanini.Domain.Entity;
using Stefanini.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Application
{
    public class UserApplication
    {
        private IUserSysRepository _userSysRepository;

        public UserApplication(IUserSysRepository userSysRepository)
        {
            _userSysRepository = userSysRepository;
        }

        public UserSys TryLogin(string email, string password)
        {
            return _userSysRepository.GetAll().Where(u => u.Email == email 
                                                    && u.Password == password).FirstOrDefault();
        }

        public IEnumerable<UserSys> GetAll()
        {
            return _userSysRepository.GetAll();
        }
    }
}
