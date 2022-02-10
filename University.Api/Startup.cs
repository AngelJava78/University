using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using University.BL.Data;

namespace University.Api
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(UniversityContext.Create);
        }
    }
}