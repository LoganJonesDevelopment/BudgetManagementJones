using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BudgetManagement.BL;

namespace BudgetManagement.SL.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<User> Get()
        {
            UserList users = new UserList();
            users.Load();
            return users;
        }

        // GET: api/User/5
        public User Get(Guid id)
        {
            User user = new User();
            user.Id = id;
            user.LoadById();
            return user;
        }

        // POST: api/User
        public void Post([FromBody]User user)
        {
            user.Insert();
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]User user)
        {
            user.Update();
        }

        // DELETE: api/User/5
        public void Delete(Guid id)
        {
            Get(id).Delete();
        }
    }
}
