using RepositoryFacturation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFacturation.Data
{
    public interface IBills
    {
        public List<Bills> Get();
        public List<Bills> GetById(int id);
        public int Save();
        public int Delete(int id);

        public List<Bills> GetByDate();
    }
}
