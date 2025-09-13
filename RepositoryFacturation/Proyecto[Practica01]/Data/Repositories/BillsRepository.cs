using RepositoryFacturation.Data.Interfaces;
using RepositoryFacturation.Data;
using RepositoryFacturation.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFacturation.Data.Repositories
{
    public class BillsRepository : IBills
    {
        public int Delete(int id)
        {
            string sp = "SP_DELETE_BILLS";
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

        public List<Bills> Get()
        {
            List<Bills> lstb = new List<Bills>();
            var dtb = DataHelper.GetInstance().ExecuteQuery("SP_GETALL_BILLS");
            var dtpm = DataHelper.GetInstance().ExecuteQuery("SP_GETALL_DETAILS");

            List<BillDetails> lpm = new List<BillDetails>();
            foreach (DataRow row in dtpm.Rows)
            {
                BillDetails pm = new BillDetails();
                pm.Id = Convert.ToInt32(row["id_detail"]);
                pm.Amount = (int)row["amount"];
                pm.Product = (int)row["id_product"];
                lpm.Add(pm);
            }

            foreach (DataRow row in dtb.Rows)
            {
                Bills b = new Bills();
                b.N_Bill = (int)row["id_bill"];
                b.Date_bill = Convert.ToDateTime(row["date_b"]);
                b.Client = Convert.ToString(row["client"]);
                foreach (BillDetails p in lpm)
                    if ((int)dtb.Rows[0]["id_detail"] == p.Id)

                        lpm.Add(p);

                b.Paym_meth = (int)dtb.Rows[0]["id_pay_meth"];
            }
            return lstb;
        }

        public List<BillDetails> GetBillDetails()
        {
            List<BillDetails> ldb = new List<BillDetails>();
            var dtbd = DataHelper.GetInstance().ExecuteQuery("SP_GETALL_DETAILS");
            foreach(DataRow r in dtbd.Rows)
            {
                BillDetails bd = new BillDetails();
                {
                    bd.Id = (int)r["id_detail"];
                    bd.Amount = (int)r["amount"];
                    bd.Product = (int)r["id_product"];
                    ldb.Add(bd);
                    
                }
            }
            return ldb;
        }

        public Bills GetByDate(DateTime date)
        {
            List<ParameterSP> lp = new List<ParameterSP>();
            {
                lp.Add(new ParameterSP()
                {
                    Name = @"date",
                    Value = date
                });



            }
            var dtb = DataHelper.GetInstance().ExecuteQuery("SP_GETBYDATE_BILLS", lp);
            var dtbd = DataHelper.GetInstance().ExecuteQuery("SP_GETALL_DETAILS");
            if (dtb != null && dtb.Rows.Count > 0)
            {
                Bills b1 = new Bills();
                List <BillDetails> lpm = new  List <BillDetails>();
                foreach (DataRow row in dtbd.Rows)
                {
                    BillDetails pm = new BillDetails();
                    pm.Id = Convert.ToInt32(row["id_detail"]);
                    pm.Amount = (int)row["amount"];
                    pm.Product = (int)row["id_product"];
                    lpm.Add(pm);
                }

                {
                    b1.N_Bill = (int)dtb.Rows[0]["id_bill"];
                    b1.Date_bill = Convert.ToDateTime(dtb.Rows[0]["date_b"]);
                    b1.Client = dtb.Rows[0]["n_prod"].ToString();
                    foreach(BillDetails p in lpm )
                        if ((int)dtb.Rows[0]["id_detail"] == p.Id)

                            lpm.Add(p);

                    b1.Paym_meth = (int)dtb.Rows[0]["id_pay_meth"];

                }
                ;
                return b1;

            }
            return null;
        }

        public Bills GetById(int id)
        {
            List<ParameterSP> lp = new List<ParameterSP>();
            {
                lp.Add(new ParameterSP()
                {
                    Name = @"nro",
                    Value = id
                });



            }
            var dtb = DataHelper.GetInstance().ExecuteQuery("SP_GETBYNRO_BILLS", lp);
            var dtpm = DataHelper.GetInstance().ExecuteQuery("SP_GETALL_DETAILS");
            if (dtb != null && dtb.Rows.Count > 0)
            {
                Bills b = new Bills();
                List<BillDetails> lpm = new List<BillDetails>();
                foreach (DataRow row in dtpm.Rows)
                {
                   BillDetails pm = new BillDetails();
                    pm.Id = Convert.ToInt32(row["id_detail"]);
                    pm.Amount = (int)row["amount"];
                    pm.Product = (int)row["id_product"];
                    lpm.Add(pm);
                }
                {
                    b.N_Bill = (int)dtb.Rows[0]["id_bill"];
                    b.Date_bill = Convert.ToDateTime(dtb.Rows[0]["date_b"]);
                    b.Client = dtb.Rows[0]["client"].ToString();
                    foreach (BillDetails p in lpm)
                        if ((int)dtb.Rows[0]["id_detail"] == p.Id)

                            lpm.Add(p);

                    b.Paym_meth = (int)dtb.Rows[0]["id_pay_meth"];
                    ;

                }
                ;
                return b;

            }
            return null;
        }

        public List<Payment_Methods> GetPaymentMethods()
        {
            var dtpm = DataHelper.GetInstance().ExecuteQuery("SP_GETALL_PAYM_METH");
            List<Payment_Methods> lpm = new List<Payment_Methods>();
            foreach (DataRow row in dtpm.Rows)
            {
                Payment_Methods pm = new Payment_Methods();
                pm.Id = Convert.ToInt32(row["id_pay_meth"]);
                pm.N_paym_meth = row["n_pay_meth"].ToString();
                lpm.Add(pm);
              
            }
            return lpm;
        }

        public bool Save(Bills b)
        {
            
            bool rowact = DataHelper.GetInstance().ExecuteTransactionSp(b);
            return rowact;
        }
    }
}

