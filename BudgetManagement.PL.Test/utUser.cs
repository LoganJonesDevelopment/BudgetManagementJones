using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BudgetManagement.PL.Test
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
        public void LoadTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                int expected = 2;
                var destinations = dc.tblUsers;
                int actual = destinations.Count();
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void InsertTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                tblUser tbluser = new tblUser();
                tbluser.Id = Guid.NewGuid();
                tbluser.FirstName = "Jay";
                tbluser.LastName = "Hemes";
                tbluser.Address = "123 Main Strees";
                tbluser.BillingAddress = "123 Main Street";
                tbluser.City = "Neenah";
                tbluser.State = "Wisconsin";
                tbluser.ZipCode = 54956;
                tbluser.Password = "Test1";
                tbluser.Email = "jay@gmail.com";

                dc.tblUsers.Add(tbluser);
                dc.SaveChanges();

                tblUser newuser = dc.tblUsers.Where(c => c.FirstName == "Jay").FirstOrDefault();

                Assert.AreEqual(newuser.FirstName, "Jay");
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                tblUser tbluser = dc.tblUsers.Where(c => c.Password == "Test1").FirstOrDefault();
                tbluser.Password = "TestUpdate";

                dc.SaveChanges();

                tblUser newuser = dc.tblUsers.Where(c => c.Password == "TestUpdate").FirstOrDefault();

                Assert.AreNotEqual(tbluser.Password, "Test1");
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            using (BudgetManagementEntities dc = new BudgetManagementEntities())
            {
                tblUser tbluser = dc.tblUsers.Where(c => c.FirstName == "Jay").FirstOrDefault();
                dc.tblUsers.Remove(tbluser);
                dc.SaveChanges();

                tblUser newuser = dc.tblUsers.Where(c => c.FirstName == "Jay").FirstOrDefault();

                Assert.IsNull(newuser);
            }
        }
    }
}
