using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetManagement.PL.Test
{
    [TestClass]
    public class utPayment
    {
        [TestMethod]
        public void LoadTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                int expected = 4;
                var payments = dc.tblPayments;
                int actual = payments.Count();
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void InsertTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                tblPayment tblpayment = new tblPayment();
                tblpayment.Id = Guid.NewGuid();
                tblpayment.Description = "TestPayment";

                dc.tblPayments.Add(tblpayment);
                dc.SaveChanges();

                tblPayment newpayment = dc.tblPayments.Where(c => c.Description == "TestPayment").FirstOrDefault();

                Assert.AreEqual(newpayment.Description, "TestPayment");
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                tblPayment tblpayment = dc.tblPayments.Where(c => c.Description == "TestPayment").FirstOrDefault();
                tblpayment.Description = "UpdatedPayment";

                dc.SaveChanges();

                tblPayment newpayment = dc.tblPayments.Where(c => c.Description == "UpdatedPayment").FirstOrDefault();

                Assert.AreNotEqual(newpayment.Description, "TestPayment");
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                tblPayment tblpayment = dc.tblPayments.Where(c => c.Description == "UpdatedPayment").FirstOrDefault();
                dc.tblPayments.Remove(tblpayment);
                dc.SaveChanges();

                tblPayment newpayment = dc.tblPayments.Where(c => c.Description == "UpdatedPayment").FirstOrDefault();

                Assert.IsNull(newpayment);
            }
        }
    }
}
