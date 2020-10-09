using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Domain.Entity
{
    public class Customer: Base
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public City City { get; set; }
        public Region Region { get; set; }
        public DateTime LastPurchase { get; set; }
        public Classification Classification { get; set; }
        public UserSys User { get; set; }
    }
}
