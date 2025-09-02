using RepositoryFacturation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFacturation.Data.Interfaces
{
    public interface IProduct
    {
        List<Product> Get();
        int Save(Product p);
        int Delete(int id);

        Product? GetById(int id);
    }
}
