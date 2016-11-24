using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Dobachesky_FinalProject
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            registerRoutes(RouteTable.Routes);
        }

        public static void registerRoutes(RouteCollection routes)
        {
            //ignore WebResource .axd file
            routes.Ignore("{resource}.axd/{*pathInfo}");
            routes.MapPageRoute("default", "default", "~/default.aspx");
            routes.MapPageRoute("home", "home", "~/default.aspx");
            routes.MapPageRoute("artist", "artist", "~/artist.aspx");
            routes.MapPageRoute("album", "artist/album", "~/album.aspx");
            routes.MapPageRoute("track", "artist/album/track", "~/track.aspx");
            routes.MapPageRoute("genres", "genres", "~/genres.aspx");
            routes.MapPageRoute("tracks", "genres/tracks", "~/tracks.aspx");
        }
    }
}