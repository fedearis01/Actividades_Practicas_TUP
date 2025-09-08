using RepositoryFacturation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFacturation.Data.Interfaces
{
    public interface IBills
    {
        public List<Bills> Get();
        public Bills? GetById(int id);
        public int Save(Bills b);
        public int Delete(int id);

        public List<Payment_Methods> GetPaymentMethods();

        public List<BillDetails> GetBillDetails();

        public Bills? GetByDate(DateTime date);
    }
}
