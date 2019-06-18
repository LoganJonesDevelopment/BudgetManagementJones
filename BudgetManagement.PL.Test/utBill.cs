using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetManagement.PL.Test
{
    [TestClass]
    public class utBill
    {
        [TestMethod]
        public void LoadTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                int expected = 3;
                var bills = dc.tblBills;
                int actual = bills.Count();
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void InsertTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                tblUser user = dc.tblUsers.Where(c => c.FirstName == "Owen").FirstOrDefault();
                tblBillDestination destination = dc.tblBillDestinations.Where(c => c.BusinessName == "Spectrum").FirstOrDefault();
                tblBill tblbill = new tblBill();
                tblbill.Id = Guid.NewGuid();
                tblbill.UserId = user.Id;
                tblbill.BillDestinationId = destination.Id;
                tblbill.BillAmount = 50;
                tblbill.DueDate = new DateTime(2019, 5, 1);
                tblbill.PaidOnTime = true;

                dc.tblBills.Add(tblbill);
                dc.SaveChanges();

                tblBill newbill = dc.tblBills.Where(c => c.BillAmount == 50).FirstOrDefault();

                Assert.AreEqual(newbill.BillAmount, 50);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                tblBill tblbill = dc.tblBills.Where(c => c.BillAmount == 50).FirstOrDefault();
                tblbill.BillAmount = 100;

                dc.SaveChanges();

                tblBill newbill = dc.tblBills.Where(c => c.BillAmount == 100).FirstOrDefault();

                Assert.IsNotNull(newbill);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                tblBill tblbill = dc.tblBills.Where(c => c.BillAmount == 100).FirstOrDefault();
                dc.tblBills.Remove(tblbill);
                dc.SaveChanges();

                tblBill newbill = dc.tblBills.Where(c => c.BillAmount == 100).FirstOrDefault();

                Assert.IsNull(newbill);
            }
        }
    }
}
