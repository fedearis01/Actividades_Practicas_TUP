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
        public int Delete(int id)
        {
            string sp = "SP_DELETE_PRODUCT";
            List<ParameterSP> lp = new List<ParameterSP>();
            {
                lp.Add(new ParameterSP()
                {
                    Name = @"id",
                    Value = id
                });
            }
            int rowact = DataHelper.GetInstance().ExecuteSave(sp, lp);
            return rowact;
        }

        public List<Product> Get()
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

        public Product? GetById(int id)
        {
            List<ParameterSP> lp = new List<ParameterSP>();
            {
                lp.Add(new ParameterSP()
                {
                    Name = @"id",
                    Value = id
                });



            }
            var dt = DataHelper.GetInstance().ExecuteQuery("SP_GETBYID_PRODUCTS", lp);
            if (dt != null && dt.Rows.Count > 0)
            {
                Product p = new Product();
                {
                    p.Id = (int)dt.Rows[0]["id_product"];
                    p.N_Product = dt.Rows[0]["n_prod"].ToString();
                    p.unit_price = Convert.ToSingle(dt.Rows[0]["unit_price"]);
                    p.Active = (int)dt.Rows[0]["active"];

                }
                ;
                return p;

            }
            return null;




        }

        int IProduct.Save(Product p)
        {
            string sp = "SP_SAVE_PRODUCTS";
            List<ParameterSP> lp = new List<ParameterSP>();
            if (p != null)
            {
                {
                    lp.Add(new ParameterSP()
                    {
                        Name = @"id",
                        Value = p.Id
                    });
                    lp.Add(new ParameterSP()
                    {
                        Name = @"name",
                        Value = p.N_Product
                    });
                    lp.Add(new ParameterSP()
                    {
                        Name = @"price",
                        Value = p.unit_price
                    });
                    lp.Add(new ParameterSP()
                    {
                        Name = @"active",
                        Value = p.Active
                    });
                }
            }
            int rowact = DataHelper.GetInstance().ExecuteSave(sp, lp);
            return rowact;
        }
    }
}
