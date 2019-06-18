using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManagement.PL;

namespace BudgetManagement.BL
{
    public class Payment
    {
        public Guid Id { get; set; }
        public string Description { get; set; }



        public int Insert()
        {
            int result = 0;
            try
            {
                using (BudgetManagementEntities dc = new BudgetManagementEntities())
                {
                    tblPayment make = new tblPayment();
                    make.Id = Guid.NewGuid();
                    make.Description = this.Description;

                    dc.tblPayments.Add(make);
                    result = dc.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Delete()
        {
            try
            {
                using (BudgetManagementEntities dc = new BudgetManagementEntities())
                {
                    if (this.Id != Guid.Empty)
                    {
                        tblPayment make = dc.tblPayments.Where(c => c.Id == this.Id).FirstOrDefault();
                        dc.tblPayments.Remove(make);
                        return dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Id is not set.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadById()
        {
            try
            {
                using (BudgetManagementEntities dc = new BudgetManagementEntities())
                {
                    if (this.Id != Guid.Empty)
                    {
                        tblPayment make = dc.tblPayments.FirstOrDefault(c => c.Id == this.Id);

                        if (make != null)
                        {
                            this.Id = make.Id;
                            this.Description = make.Description;
                        }
                        else
                        {
                            throw new Exception("Could not find the row.");
                        }
                    }
                    else
                    {
                        throw new Exception("Id is not set.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update()
        {
            try
            {
                using (BudgetManagementEntities dc = new BudgetManagementEntities())
                {
                    if (this.Id != Guid.Empty)
                    {
                        tblPayment make = dc.tblPayments.Where(c => c.Id == this.Id).FirstOrDefault();
                        make.Description = this.Description;
                        return dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Id is not set.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class PaymentList : List<Payment>
    {
        public void Load()
        {
            try
            {
                using (BudgetManagementEntities dc = new BudgetManagementEntities())
                {
                    dc.tblPayments
                        .ToList()
                        .ForEach(c => this
                        .Add(new Payment // ??           
                        {
                            Id = c.Id,
                            Description = c.Description
                        }));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
