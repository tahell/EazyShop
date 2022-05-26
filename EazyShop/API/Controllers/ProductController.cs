using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ProductController : ApiController
    {
        
        [Route("api/Products/GetProducts")]
        [HttpGet]
        // GET: api/Product
        public List<DTOProduct> GetProduct()
        {
            List<DTOProduct> P = BL.ManagerProduct.GetProducts();
            return P;
        }

        [Route("api/Products/getForCheckCode")]
        [HttpGet]
 
        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
