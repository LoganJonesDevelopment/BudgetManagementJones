using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetManagement.BL.Test
{
    [TestClass]
    public class utBill
    {
        [TestMethod]
        public void LoadTest()
        {
            BillList bills = new BillList();
            bills.Load();
            int expected = 3;
            int actual = bills.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            Bill newbill = new Bill();

            newbill.Id = Guid.NewGuid();
            newbill.UserId = Guid.NewGuid();
            newbill.DesinationId = Guid.NewGuid();
            newbill.DueDate = new DateTime(2020, 5, 5);
            newbill.BillAmount = 500;
            newbill.PaidOnTime = true;

            int actual = newbill.Insert();
            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            BillList bills = new BillList();
            bills.Load();

            Bill bill = bills.FirstOrDefault(c => c.BillAmount == 500);

            bill.BillAmount = 600;
            bill.Update();
            

            Assert.AreEqual(bill.BillAmount, 600);
        }

        [TestMethod]
        public void DeleteTest()
        {
            BillList bills = new BillList();
            bills.Load();

            Bill bill = bills.FirstOrDefault(c => c.BillAmount == 600);
            int actual = bill.Delete();

            Assert.IsTrue(actual > 0);
        }
    }
}
