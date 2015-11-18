using System;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EMMTY_GO_WEB.Startup))]
namespace EMMTY_GO_WEB
{
    public partial class Startup
    {
        public static bool SqlStarted { get; set; }

        public void Configuration(IAppBuilder app)
        {
            SqlStarted = false;
            ConfigureAuth(app);
            //GlobalHost.DependencyResolver.UseSqlServer(ConfigurationManager.ConnectionStrings["backplane_db_connection"].ConnectionString);
            app.MapSignalR();
        }
    }
}
