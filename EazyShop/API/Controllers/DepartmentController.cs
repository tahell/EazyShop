using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BL;
namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DepartmentController : ApiController
    {
        // GET: api/Department
        [Route("api/Department/GetDepartmentAccordingCode/{CategoryNum}")]
        [HttpGet]
        public List<DTOProduct> GetDepartmentAccordingCode(int CategoryNum)
        {
            List<DTOProduct> s = ManagerDepartment.GetDepartmentAccordingCode(CategoryNum);
            return s;
        }


        [Route("api/Department/GetAllDepartments")]
        [HttpGet]
        public List<DTODepartment> GetDTODepartments()
        {
             return ManagerDepartment.GetDepartment();
        }
    }
}
