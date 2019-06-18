using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetManagement.BL.Test
{
    [TestClass]
    public class utBillDestination
    {
        [TestMethod]
        public void LoadTest()
        {
            BillDestinationList billdestinations = new BillDestinationList();
            billdestinations.Load();
            int expected = 2;
            int actual = billdestinations.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            BillDestination newpayment = new BillDestination();

            newpayment.Id = Guid.NewGuid();
            newpayment.BusinessName = "New BillDestination";
            newpayment.BusinessAddress = "New BillDestination";

            int actual = newpayment.Insert();
            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            BillDestinationList billdestinations = new BillDestinationList();
            billdestinations.Load();

            BillDestination billdestination = billdestinations.FirstOrDefault(c => c.BusinessName == "New BillDestination");

            billdestination.BusinessName = "Updated BillDestination";
            billdestination.Update();

            billdestination.LoadById();

            Assert.AreEqual(billdestination.BusinessName, "Updated BillDestination");
        }

        [TestMethod]
        public void DeleteTest()
        {
            BillDestinationList billdestinations = new BillDestinationList();
            billdestinations.Load();

            BillDestination billdestination = billdestinations.FirstOrDefault(c => c.BusinessName == "Updated BillDestination");
            int actual = billdestination.Delete();

            Assert.IsTrue(actual > 0);
        }
    }
}
