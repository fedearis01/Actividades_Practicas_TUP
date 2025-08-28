using RepositoryFacturation.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFacturation.Data
{
    public class ProductRepository : IProduct
    {
        int IProduct.Delete(int id)
        {
            string sp = "SP_DELETE_PRODUCT";
            int rowact = DataHelper.GetInstance().ExecuteSave(sp);
            return rowact;
        }

        List<Product> IProduct.Get()
        {
            
            List<Product> lstp = new List<Product>();
            var DT = DataHelper.GetInstance().ExecuteQuery("SP_GETALL_PRODUCTS");
            foreach (DataRow row in DT.Rows)
            {
                Product p = new Product();
                p.Id = (int)row["id_product"];
                p.N_Product = row["n_prod"].ToString();
                p.unit_price = Convert.ToSingle(row["unit_price"]);
                p.Active = (int)row["active"];
                lstp.Add(p);
            }
            return lstp;
        }

        List<Product> IProduct.GetById(int id)
        {
            List<Product> lstp = new List<Product> ();
            var dt = DataHelper.GetInstance().ExecuteQuery("SP_GETBYID_PRODUCTS");

            
            foreach (DataRow row in dt.Rows)
            {
                Product p = new Product();
                p.Id = id;
                p.N_Product = row["n_prod"].ToString();
                p.unit_price = (float)row["unit_price"];
                p.Active = (int)row["active"];
                lstp.Add(p);
            }
            return lstp;
                
            
        }

        int IProduct.Save()
        {
            throw new NotImplementedException();
        }
    }
}
