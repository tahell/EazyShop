using BL.Dijxtra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AlgoritemsController : ApiController
    {
        // GET: api/Algoritem
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Algoritem/5
        [Route("api/Algoritems/GetDTOWaze")]
        [HttpGet]
        public List<product_node> GetDTOWaze()
        {
            return BL.Dijxtra.Dijxtra.CreateShortestRouteOnStore();
        }

        // POST: api/Algoritem
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Algoritem/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Algoritem/5
        public void Delete(int id)
        {
        }
    }
}
