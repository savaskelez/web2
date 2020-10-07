using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gnostice.StarDocsSDK;
using System.Web.Routing;

namespace projem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static StarDocs starDocs;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            starDocs = new StarDocs(
                new ConnectionInfo(new Uri("https://api.gnostice.com/stardocs/v1"),
                "8bbaf80c0d264ad49b600be3790b3508", "e6023927bc82496d92783dbf2a3e4c2f"));
            starDocs.Auth.loginApp();

        }
    }
}


