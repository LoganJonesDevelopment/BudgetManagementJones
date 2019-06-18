using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManagement.PL;


namespace BudgetManagement.BL
{
    public class Bill
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DesinationId { get; set; }
        public DateTime DueDate { get; set; }
        public decimal BillAmount { get; set; }
        public bool PaidOnTime { get; set; }

        public int Insert()
        {
            int result = 0;
            try
            {
                using (BudgetManagementEntities dc = new BudgetManagementEntities())
                {
                    tblBill bill = new tblBill();
                    bill.Id = Guid.NewGuid();
                    bill.UserId = this.UserId;
                    bill.BillDestinationId = this.DesinationId;
                    bill.DueDate = this.DueDate;
                    bill.BillAmount = this.BillAmount;
                    bill.PaidOnTime = this.PaidOnTime;
                    

                    dc.tblBills.Add(bill);
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
                        tblBill bill = dc.tblBills.Where(c => c.Id == this.Id).FirstOrDefault();
                        dc.tblBills.Remove(bill);
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
                        tblBill bill = dc.tblBills.FirstOrDefault(c => c.Id == this.Id);

                        if (bill != null)
                        {
                            
                            this.Id = bill.Id;
                            this.UserId = bill.UserId;
                            this.DueDate = bill.DueDate;
                            this.BillAmount = bill.BillAmount;
                            this.PaidOnTime = bill.PaidOnTime;
                            this.DesinationId = bill.BillDestinationId;
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
                        tblBill bill = dc.tblBills.Where(c => c.Id == this.Id).FirstOrDefault();
                        bill.UserId = this.UserId;
                        bill.BillDestinationId = this.DesinationId;
                        bill.DueDate = this.DueDate;
                        bill.BillAmount = this.BillAmount;
                        bill.PaidOnTime = this.PaidOnTime;
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

    public class BillList : List<Bill>
    {
        public void Load()
        {
            try
            {
                using (BudgetManagementEntities dc = new BudgetManagementEntities())
                {
                    dc.tblBills
                        .ToList()
                        .ForEach(c => this
                        .Add(new Bill
                        {
                            Id = c.Id,
                            DesinationId = c.BillDestinationId,
                            UserId = c.UserId,
                            DueDate = c.DueDate,
                            BillAmount = c.BillAmount,
                            PaidOnTime = c.PaidOnTime,

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
