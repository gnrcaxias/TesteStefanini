using Stefanini.Domain.Entity;
using Stefanini.Domain.Repository;
using System.Collections.Generic;

namespace Stefanini.Application
{
    public class CityApplication
    {
        private ICityRepository _cityRepository;

        public CityApplication(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IEnumerable<City> GetAll()
        {
            return _cityRepository.GetAll();
        }
    }
}
