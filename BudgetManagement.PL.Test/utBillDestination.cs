using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetManagement.PL.Test
{
    [TestClass]
    public class utBillDestination
    {
        [TestMethod]
        public void LoadTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                int expected = 2;
                var destinations = dc.tblBillDestinations;
                int actual = destinations.Count();
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void InsertTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                tblBillDestination tblbilldestination = new tblBillDestination();
                tblbilldestination.Id = Guid.NewGuid();
                tblbilldestination.BusinessName = "Chase";
                tblbilldestination.BusinessAddress = "111 E Wisconsin Ave";

                dc.tblBillDestinations.Add(tblbilldestination);
                dc.SaveChanges();

                tblBillDestination newdestination = dc.tblBillDestinations.Where(c => c.BusinessName == "Chase").FirstOrDefault();

                Assert.AreEqual(tblbilldestination.BusinessName, newdestination.BusinessName);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                tblBillDestination tblbilldestination = dc.tblBillDestinations.Where(c => c.BusinessName == "Chase").FirstOrDefault();
                tblbilldestination.BusinessAddress = "4401 W Wisconsin Ave";

                dc.SaveChanges();

                tblBillDestination newdestination = dc.tblBillDestinations.Where(c => c.BusinessAddress == "4401 W Wisconsin Ave").FirstOrDefault();

                Assert.AreNotEqual(tblbilldestination.BusinessAddress, "111 E Wisconsin Ave");
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                tblBillDestination tblbilldestination = dc.tblBillDestinations.Where(c => c.BusinessName == "Chase").FirstOrDefault();
                dc.tblBillDestinations.Remove(tblbilldestination);
                dc.SaveChanges();

                tblBillDestination newdestination = dc.tblBillDestinations.Where(c => c.BusinessName == "Chase").FirstOrDefault();

                Assert.IsNull(newdestination);
            }
        }
    }
}
