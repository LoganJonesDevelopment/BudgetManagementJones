using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BudgetManagement.BL;

namespace BudgetManagement.SL.Controllers
{
    public class BillController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Bill> Get()
        {
            BillList bills = new BillList();
            bills.Load();
            return bills;
        }

        // GET api/<controller>/5
        public Bill Get(Guid id)
        {
            Bill bill = new Bill();
            bill.Id = id;
            bill.LoadById();
            return bill;
        }

        // POST api/<controller>
        public void Post([FromBody]Bill bill)
        {
            bill.Insert();
        }

        // PUT api/<controller>/5
        public void Put(Guid id, [FromBody]Bill bill)
        {
            bill.Update();
        }

        // DELETE api/<controller>/5
        public void Delete(Guid id)
        {
            Get(id).Delete();
        }
    }
}