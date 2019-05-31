using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebApiIntegration
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //The reason of comment out above line is that it's also calling from Owin Startup
            //GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
