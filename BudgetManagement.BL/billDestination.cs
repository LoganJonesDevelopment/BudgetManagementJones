using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManagement.PL;

namespace BudgetManagement.BL
{
   public class BillDestination
    { 

    public Guid Id { get; set; }
    public string BusinessName { get; set; }
    public string BusinessAddress { get; set; }



    public int Insert()
    {
        int result = 0;
        try
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                tblBillDestination billDestination = new tblBillDestination();
                billDestination.Id = Guid.NewGuid();
                billDestination.BusinessName = this.BusinessName;
                billDestination.BusinessAddress = this.BusinessAddress;

                    dc.tblBillDestinations.Add(billDestination);
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
                    tblBillDestination billDestination = dc.tblBillDestinations.Where(c => c.Id == this.Id).FirstOrDefault();
                    dc.tblBillDestinations.Remove(billDestination);
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
                    tblBillDestination billDestination = dc.tblBillDestinations.FirstOrDefault(c => c.Id == this.Id);

                    if (billDestination != null)
                    {
                            this.Id = billDestination.Id;
                            this.BusinessAddress = billDestination.BusinessAddress;
                            this.BusinessName = billDestination.BusinessName;
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
                    tblBillDestination billDestination = dc.tblBillDestinations.Where(c => c.Id == this.Id).FirstOrDefault();
                        billDestination.BusinessName = this.BusinessName;
                        billDestination.BusinessAddress = this.BusinessAddress;
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

public class BillDestinationList : List<BillDestination>
{
    public void Load()
    {
        try
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                dc.tblBillDestinations
                    .ToList()
                    .ForEach(c => this
                    .Add(new BillDestination               
                    {
                        Id = c.Id,
                        BusinessAddress = c.BusinessAddress,
                        BusinessName = c.BusinessName
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
