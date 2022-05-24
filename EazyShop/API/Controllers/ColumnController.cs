using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ColumnController : ApiController
    {
        // GET: api/Column
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Column/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Column
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Column/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Column/5
        public void Delete(int id)
        {
        }
    }
}
