using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class UserController : ApiController
    {
        // GET: api/User
        [Route("api/User/GetUser")]
        [HttpGet]
        public List<DTOUser> GetUser()
        {
            List<DTOUser> U = BL.ManagerUser.GetUsers();
            return U;
        }
        [Route("api/GetUserById/{id}")]
        [HttpGet]

        // GET: api/User/5
        public DTOUser GetUserById(int id)
        {
            DTOUser dc = BL.ManagerUser.GetUsers().FirstOrDefault(a => a.User_Code == id);
            return dc;
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
