using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFacturation.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string N_Product { get; set; }
        public float unit_price { get; set; }
        public int Active { get; set; }

        public override string ToString()
        {
            return  Id + " - " + N_Product +" - " + unit_price + " - " + Active;
        }
    }
}
