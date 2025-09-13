using RepositoryFacturation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Practica01_.Data.ApiData
{
    public interface IDataApi
    {
        public List<Product> GetProducts();

        public int SaveProduct(Product p);

        public int DeleteProduct(int id);

        public int UpdateProduct(Product p);

        public List<Bills> GetBills();

        public int UpdateBills(Bills bills);
        public int SaveBills(Bills b);

        public int DeleteBills(int id);


    }
}
