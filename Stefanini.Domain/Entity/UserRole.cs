using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Domain.Entity
{
    public class UserRole: Base
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
    }
}
