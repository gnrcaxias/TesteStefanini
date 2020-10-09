using Stefanini.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stefanini.Domain.Entity;

namespace Stefanini.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
