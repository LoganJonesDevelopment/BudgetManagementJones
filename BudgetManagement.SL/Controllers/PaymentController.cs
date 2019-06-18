using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BudgetManagement.BL;

namespace BudgetManagement.SL.Controllers
{
    public class PaymentController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Payment> Get()
        {
            PaymentList payments = new PaymentList();
            payments.Load();
            return payments;
        }

        // GET api/<controller>/5
        public Payment Get(Guid id)
        {
            Payment payment = new Payment();
            payment.Id = id;
            payment.LoadById();
            return payment;
        }

        // POST api/<controller>
        public void Post([FromBody]Payment payment)
        {
            payment.Insert();
        }

        // PUT api/<controller>/5
        public void Put(Guid id, [FromBody]Payment payment)
        {
            payment.Update();
        }

        // DELETE api/<controller>/5
        public void Delete(Guid id)
        {
            Get(id).Delete();
        }
    }
}