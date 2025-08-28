using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFacturation.Domain
{
    public class Bills
    {
        public int N_Bill { get; set; }
        public DateTime Date_bill  { get; set; }
        public Payment_Methods Paym_meth { get; set; }
        public string Client { get; set; }
    }
}
