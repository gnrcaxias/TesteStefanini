using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Application.Dto
{
    public class UserSysDto: BaseDto
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRoleDto UserRole { get; set; }
    }
}
