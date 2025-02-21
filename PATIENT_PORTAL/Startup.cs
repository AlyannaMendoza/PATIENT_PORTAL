using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PATIENT_PORTAL.Models;

[assembly: OwinStartupAttribute(typeof(PATIENT_PORTAL.Startup))]
namespace PATIENT_PORTAL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
