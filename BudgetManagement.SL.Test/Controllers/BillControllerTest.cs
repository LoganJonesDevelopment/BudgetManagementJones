using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BudgetManagement.SL1;
using BudgetManagement.SL.Controllers;
using BudgetManagement.BL;

namespace BudgetManagement.SL.Test.Controllers
{
    [TestClass]
    public class BillControllerTest
    {
        [TestMethod]
        public void Get()
        {
            BillController controller = new BillController();

            IEnumerable<Bill> result = controller.Get();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById()
        {
            BillController controller = new BillController();

            Guid.TryParse("0FCC1F09-3BC7-4423-A0B0-0A7E84F9581D", out Guid result);

            Assert.IsNotNull(controller.Get(result));
        }

        [TestMethod]
        public void Post()
        {
            BillController controller = new BillController();
            Bill bill = new Bill();

            controller.Post(bill);
        }

        [TestMethod]
        public void Put()
        {
            BillController controller = new BillController();

            Guid.TryParse("00000000-0000-0000-0000-000000000000", out Guid result);

            Bill bill = new Bill();
            bill.Id = result;

            controller.Put(result, bill);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            BillController controller = new BillController();

            Guid.TryParse("00000000-0000-0000-0000-000000000000", out Guid result);

            controller.Delete(result); 

            Assert.IsNotNull(result);
        }
    }
}
