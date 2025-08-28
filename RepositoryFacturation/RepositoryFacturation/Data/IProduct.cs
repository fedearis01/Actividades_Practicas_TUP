using RepositoryFacturation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFacturation.Data
{
    public interface IProduct
    {
        public List<Product> Get();
        public int Save();
        public int Delete(int id);

        public List<Product> GetById(int id);
    }
}
