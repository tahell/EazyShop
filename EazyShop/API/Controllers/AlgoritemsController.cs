using BL.Algorithm;
using DTO;
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
        [Route("api/Algorithm/GetDTOWaze")]
        [HttpGet]
        public List<Node> GetDTOWaze()
        {


            DTOProduct cola = new DTOProduct() { Product_code = 68 };
            DTOProduct RC = new DTOProduct() { Product_code = 69 };
            DTOProduct shampoo = new DTOProduct() { Product_code = 8 };
            DTOProduct conditioner = new DTOProduct() { Product_code = 9 };
            List<DTOProduct> list = new List<DTOProduct>();
            list.Add(cola);
            list.Add(RC);
            list.Add(shampoo);
            list.Add(conditioner);
            Algorithm a = new Algorithm();
           return  a.FindPath(list);
           
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
