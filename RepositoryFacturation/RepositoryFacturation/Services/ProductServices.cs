using RepositoryFacturation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryFacturation.Domain;


namespace RepositoryFacturation.Services
{
    public class ProductServices
    {
        private IProduct _repository;
        public  ProductServices()
        {
            _repository = new ProductRepository();
        }
        public List<Product> GetProduct()
        {
            return _repository.Get();
        }

        public Product GetPById(int id) 
        {
            return _repository.GetById(id);
        }

        public int DeleteProduct(int id)
        {
            return _repository.Delete(id);
        }
        
        
    }
}
