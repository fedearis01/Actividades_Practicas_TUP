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
        public int Paym_meth { get; set; }
        public string Client { get; set; }

        public List<BillDetails>? id_det { get; set; }

        public int Cancelled { get; set; }

        public override string ToString()
        {
            return N_Bill + " - " + Date_bill + " - " + Paym_meth + " - " + Client + " - " + id_det;
        }
    }
}
