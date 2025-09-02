using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFacturation.Domain
{
    public class BillDetails
    {
        public int Id { get; set; }
        public int Product { get; set; }

        public int Amount { get; set; }

        public override string ToString()
        {
            return Id + " - " + Product + " - " + Amount;
        }
    }
}
