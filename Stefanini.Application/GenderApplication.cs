using Stefanini.Domain.Entity;
using Stefanini.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Application
{
    public class GenderApplication
    {
        private IGenderRepository _genderRepository;

        public GenderApplication(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public IEnumerable<Gender> GetAll()
        {
            return _genderRepository.GetAll();
        }
    }
}
