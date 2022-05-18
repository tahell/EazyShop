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
    public class DepartmentController : ApiController
    {
        // GET: api/Department
        [Route("api/Department/GetDepartmentAccordingCode")]
        [HttpGet]
        public List<DTOProduct> GetDepartmentAccordingCode(int CategoryNum)
        {
            List<DTOProduct> s = BL.ManagerDepartment.GetDepartmentAccordingCode(CategoryNum);
            return s;
        }

        // GET: api/Department/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Department
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Department/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Department/5
        public void Delete(int id)
        {
        }
    }
}
