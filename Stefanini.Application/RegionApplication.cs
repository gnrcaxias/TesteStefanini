using Stefanini.Domain.Entity;
using Stefanini.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Application
{
    public class RegionApplication
    {
        private IRegionRepository _regionRepository;

        public RegionApplication(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public IEnumerable<Region> GetAll()
        {
            return _regionRepository.GetAll();
        }

        //public IEnumerable<Region> GetByCity(int cityId)
        //{
        //    return _regionRepository.GetAll().Where(r => r.;
        //}
    }
}
