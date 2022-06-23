using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class ProductController : ApiController
    {



        public List<DTONodes> GetChoiceProduct(List<DTOProduct> prod)
        {
            List<DTONodes> nodes = new List<DTONodes>();
            //foreach (var n in prod)
            //{
            //    int coliom = n.Kod_Column;

            //    if ()
            //}
            return nodes;
        }

     

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

        [Route("api/Products/GetNodes")]
        [HttpPost]

        // GET: api/Product/5
        public List<BL.Algorithm.Node> GetNodes()
        {
            List<DTOProduct> products = new List<DTOProduct>();

           products = JsonConvert.DeserializeObject<List<DTOProduct>>(HttpContext.Current.Request["allProducts"]);
            BL.Algorithm.Algorithm dijxtra = new BL.Algorithm.Algorithm();
            return dijxtra.FindPath(products);
            
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
