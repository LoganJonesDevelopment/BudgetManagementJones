using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BudgetManagement.BL;

namespace BudgetManagement.SL.Controllers
{
    public class BillDestinationController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<BillDestination> Get()
        {
            BillDestinationList destinations = new BillDestinationList();
            destinations.Load();
            return destinations;
        }

        // GET api/<controller>/5
        public BillDestination Get(Guid id)
        {
            BillDestination destination = new BillDestination();
            destination.Id = id;
            destination.LoadById();
            return destination;
        }

        // POST api/<controller>
        public void Post([FromBody]BillDestination destination)
        {
            destination.Insert();
        }

        // PUT api/<controller>/5
        public void Put(Guid id, [FromBody]BillDestination destination)
        {
            destination.Update();
        }

        // DELETE api/<controller>/5
        public void Delete(Guid id)
        {
            Get(id).Delete();
        }
    }
}