using API.Controllers;
using BL.Dijxtra;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //List<product_node> RE = new List<product_node>();
            //DepartmentController y = new DepartmentController();
            //RE = CreateShortestRouteOnStore(y.GetDepartmentAccordingCode(3));
        }

        //private List<product_node> CreateShortestRouteOnStore(List<DTOProduct> list)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
