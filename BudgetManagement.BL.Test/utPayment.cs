using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BudgetManagement.BL;
using System.Linq;

namespace BudgetManagement.BL.Test
{
    [TestClass]
    public class utPayment
    {
        [TestMethod]
        public void LoadTest()
        {
            PaymentList payments = new PaymentList();
            payments.Load();
            int expected = 4;
            int actual = payments.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            Payment newpayment = new Payment();

            newpayment.Id = Guid.NewGuid();
            newpayment.Description = "New Payment";

            int actual = newpayment.Insert();
            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            PaymentList payments = new PaymentList();
            payments.Load();

            Payment payment = payments.FirstOrDefault(c => c.Description == "New Payment");

            payment.Description = "Updated Payment";
            payment.Update();

            payment.LoadById();

            Assert.AreEqual(payment.Description, "Updated Payment");
        }

        [TestMethod]
        public void DeleteTest()
        {
            PaymentList payments = new PaymentList();
            payments.Load();

            Payment payment = payments.FirstOrDefault(c => c.Description == "Updated Payment");
            int actual = payment.Delete();

            Assert.IsTrue(actual > 0);
        }
    }
}
