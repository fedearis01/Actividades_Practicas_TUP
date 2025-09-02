using RepositoryFacturation.Data;
using RepositoryFacturation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFacturation.Services
{
    public class BillServices
    {
        private IBills _repository;

        public BillServices() 
        {
            _repository = new BillsRepository();
        }
        public List<Bills> GetAllBills()
        {
            return _repository.Get();
        }

        public Bills GetBillsbyId(int id)
        {
            return _repository.GetById(id);
        }

        public Bills GetBillByDate(DateTime date)
        {
            return _repository.GetByDate(date);

        }
        public int SaveBill(Bills b)
        {
            return _repository.Save(b);
        }
        public int DeleteBill(int id)
        {
            return _repository.Delete(id);
        }

        public List<Payment_Methods> GetPaymentMethods()
        {
            return _repository.GetPaymentMethods();
        }

        public List<BillDetails> GetBillDetails()
        {
            return _repository.GetBillDetails();
        }
        
    }
}
