using Stefanini.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Domain.Repository
{
    public interface IRegionRepository
    {
        Region Get(int id);
        IEnumerable<Region> GetAll();
    }
}
