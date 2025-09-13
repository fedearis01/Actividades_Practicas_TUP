using RepositoryFacturation.Data.Interfaces;
using RepositoryFacturation.Data.Repositories;
using RepositoryFacturation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Practica01_.Data.ApiData
{
    public class DataApiImp : IDataApi

    {
        private IProduct _Prepository;
        private IBills _Brepository;
        public DataApiImp()     
        { 
            _Prepository = new ProductRepository();
            _Brepository = new BillsRepository();
        }
        public int DeleteBills(int id)
        {
            return _Brepository.Delete(id);
        }

        public int DeleteProduct(int id)
        {
            return _Prepository.Delete(id);
        }

        public List<Bills> GetBills()
        {
            return _Brepository.Get();
        }

        public List<Product> GetProducts()
        {
            return _Prepository.Get();
        }

        public int SaveBills(Bills b)
        {
            return _Brepository.Save(b);
        }

        public int SaveProduct(Product p)
        {
            return _Prepository.Save(p);
        }

        public int UpdateBills(Bills bills)
        {
            throw new NotImplementedException();
        }

        public int UpdateProduct(Product p)
        {
            throw new NotImplementedException();
        }
    }
}
