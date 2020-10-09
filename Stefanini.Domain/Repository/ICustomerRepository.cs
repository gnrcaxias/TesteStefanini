using Stefanini.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Domain.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
    }
}
