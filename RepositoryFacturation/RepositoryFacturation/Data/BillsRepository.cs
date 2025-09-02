using RepositoryFacturation.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFacturation.Data
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
            var dtpm = DataHelper.GetInstance().ExecuteQuery("SP_GETALL_PAYM_METH");

            List<Payment_Methods> lpm = new List<Payment_Methods>();
            foreach (DataRow row in dtpm.Rows)
            {
                Payment_Methods pm = new Payment_Methods();
                pm.Id = Convert.ToInt32(row["id_pay_meth"]);
                pm.N_paym_meth = row["n_pay_meth"].ToString();
                lpm.Add(pm);
            }

            foreach (DataRow row in dtb.Rows)
            {
                Bills b = new Bills();
                b.N_Bill = (int)row["id_bill"];
                b.Date_bill = Convert.ToDateTime(row["date_b"]);
                b.Client = Convert.ToString(row["client"]);
                foreach (Payment_Methods p in lpm)
                    if (dtb.Rows[0]["n_pay_meth"].ToString() == p.N_paym_meth)

                        b.Paym_meth = p.Id;
                lstb.Add(b);
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
            var dtpm = DataHelper.GetInstance().ExecuteQuery("SP_GETALL_PAYM_METH");
            if (dtb != null && dtb.Rows.Count > 0)
            {
                Bills b1 = new Bills();
                List <Payment_Methods> lpm = new  List <Payment_Methods>();
                foreach (DataRow row in dtpm.Rows) 
                    {
                    Payment_Methods pm = new Payment_Methods();
                        pm.Id = Convert.ToInt32(row["id_pay_meth"]);
                        pm.N_paym_meth = row["n_pay_meth"].ToString();
                        lpm.Add(pm);  
                    }
                
                {
                    b1.N_Bill = (int)dtb.Rows[0]["id_bill"];
                    b1.Date_bill = Convert.ToDateTime(dtb.Rows[0]["date_b"]);
                    b1.Client = dtb.Rows[0]["n_prod"].ToString();
                    foreach(Payment_Methods p in lpm )
                        if (dtb.Rows[0]["n_pay_meth"].ToString() == p.N_paym_meth)

                            b1.Paym_meth = p.Id;
                    b1.id_det = (int)dtb.Rows[0]["id_detail"] ;

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
            var dtpm = DataHelper.GetInstance().ExecuteQuery("SP_GETALL_PAYM_METH");
            if (dtb != null && dtb.Rows.Count > 0)
            {
                Bills b = new Bills();
                List<Payment_Methods> lpm = new List<Payment_Methods>();
                foreach (DataRow row in dtpm.Rows)
                {
                    Payment_Methods pm = new Payment_Methods();
                    pm.Id = Convert.ToInt32(row["id_pay_meth"]);
                    pm.N_paym_meth = row["n_pay_meth"].ToString();
                    lpm.Add(pm);
                }
                {
                    b.N_Bill = (int)dtb.Rows[0]["id_bill"];
                    b.Date_bill = Convert.ToDateTime(dtb.Rows[0]["date_b"]);
                    b.Client = dtb.Rows[0]["client"].ToString();
                    foreach (Payment_Methods p in lpm)
                        if (dtb.Rows[0]["n_pay_meth"].ToString() == p.N_paym_meth)

                            b.Paym_meth = p.Id;

                    b.id_det = (int)dtb.Rows[0]["id_detail"];
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

        public int Save(Bills b)
        {
            string sp = "SP_SAVE_BILLS";
            List<ParameterSP> lp = new List<ParameterSP>();
            if (b != null)
            {
                {
                    lp.Add(new ParameterSP()
                    {
                        Name = @"id",
                        Value = b.N_Bill
                    });
                    lp.Add(new ParameterSP()
                    {
                        Name = @"date",
                        Value = b.Date_bill
                    });
                    lp.Add(new ParameterSP()
                    {
                        Name = @"client",
                        Value = b.Client
                    });
                    lp.Add(new ParameterSP()
                    {
                        Name = @"id_pm",
                        Value = b.Paym_meth
                    });
                    lp.Add(new ParameterSP()
                    {
                        Name = @"id_det",
                        Value = b.id_det
                    });
                    lp.Add(new ParameterSP()
                    {
                        Name = @"cancelled",
                        Value = b.Cancelled
                    });

                }
            }
            int rowact = DataHelper.GetInstance().ExecuteSave(sp, lp);
            return rowact;
        }
    }
}

