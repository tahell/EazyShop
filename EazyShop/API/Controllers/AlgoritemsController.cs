using BL.Dijxtra;
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
        [Route("api/Algoritems/GetDTOWaze")]
        [HttpGet]
        public void GetDTOWaze()
        {


            DTOProduct milk = new DTOProduct() { Product_code = 5 };
            DTOProduct kotege = new DTOProduct() { Product_code = 6 };
            DTOProduct shampoo = new DTOProduct() { Product_code = 8 };
            DTOProduct conditioner = new DTOProduct() { Product_code = 9 };
            List<DTOProduct> list = new List<DTOProduct>();
            list.Add(milk);
            list.Add(kotege);
            list.Add(shampoo);
            list.Add(conditioner);
          //  BL.Algoritm.PassingNodes();
            return;
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
