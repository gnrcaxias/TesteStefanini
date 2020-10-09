using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Application.Dto
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public GenderDto Gender { get; set; }
        public CityDto City { get; set; }
        public RegionDto Region { get; set; }
        public DateTime LastPurchase { get; set; }
        public ClassificationDto Classification { get; set; }
        public UserSysDto User { get; set; }
    }
}
