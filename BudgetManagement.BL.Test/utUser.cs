using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetManagement.BL.Test
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
        public void LoadTest()
        {
            UserList users = new UserList();
            users.Load();
            int expected = 3;
            int actual = users.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            User newuser = new User();

            newuser.Id = Guid.NewGuid();
            newuser.FirstName = "New";
            newuser.LastName = "User";
            newuser.BillingAddress = "123 Main St";
            newuser.Address = "123 Main St";
            newuser.City = "Neenah";
            newuser.State = "Wisconsin";
            newuser.ZipCode = 54956;
            newuser.Password = "Password";
            newuser.Email = "email";

            int actual = newuser.Insert();
            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            UserList users = new UserList();
            users.Load();

            User user = users.FirstOrDefault(c => c.FirstName == "New");

            user.FirstName = "Updated";
            user.Update();

            user.LoadById();

            Assert.AreEqual(user.FirstName, "Updated");
        }

        [TestMethod]
        public void DeleteTest()
        {
            UserList users = new UserList();
            users.Load();

            User user = users.FirstOrDefault(c => c.FirstName == "Updated");
            int actual = user.Delete();

            Assert.IsTrue(actual > 0);
        }
    }
}
