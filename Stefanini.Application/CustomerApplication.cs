using Stefanini.Domain.Entity;
using Stefanini.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stefanini.Application
{
    public class CustomerApplication
    {
        private ICustomerRepository _customerRepository;

        public CustomerApplication(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> SearchCustomers(string name, int genderId, int cityId, int regionId, 
                                                    DateTime fromLastPurchase, DateTime untilLastPurchase, 
                                                    int classificationId, int sellerId)
        {
            var searchReturn = _customerRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(name))
                searchReturn = searchReturn.Where(c => c.Name.ToUpper().Contains(name.ToUpper()));

            if (fromLastPurchase != new DateTime())
                searchReturn = searchReturn.Where(c => c.LastPurchase >= fromLastPurchase);

            if (untilLastPurchase != new DateTime())
                searchReturn = searchReturn.Where(c => c.LastPurchase <= untilLastPurchase);

            if (genderId > 0)
                searchReturn = searchReturn.Where(c => c.Gender.Id == genderId);

            if (cityId > 0)
                searchReturn = searchReturn.Where(c => c.City.Id == cityId);

            if (regionId > 0)
                searchReturn = searchReturn.Where(c => c.Region.Id == regionId);

            if (classificationId > 0)
                searchReturn = searchReturn.Where(c => c.Classification.Id == classificationId);

            if (sellerId > 0)
                searchReturn = searchReturn.Where(c => c.User.Id == sellerId);

            return searchReturn;
        }
    }
}
