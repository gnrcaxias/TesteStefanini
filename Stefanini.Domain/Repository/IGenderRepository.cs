using Stefanini.Domain.Entity;
using System.Collections.Generic;

namespace Stefanini.Domain.Repository
{
    public interface IGenderRepository
    {
        Gender Get(int id);
        IEnumerable<Gender> GetAll();
    }
}
