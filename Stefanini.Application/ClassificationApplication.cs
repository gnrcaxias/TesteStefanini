using Stefanini.Domain.Entity;
using Stefanini.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Application
{
    public class ClassificationApplication
    {
        private IClassificationRepository _classificationRepository;

        public ClassificationApplication(IClassificationRepository classificationRepository)
        {
            _classificationRepository = classificationRepository;
        }

        public IEnumerable<Classification> GetAll()
        {
            return _classificationRepository.GetAll();
        }
    }
}
