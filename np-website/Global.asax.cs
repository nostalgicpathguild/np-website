using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace np_website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            if (Request.Cookies["npGuildIdentity"] != null)
            {
                var sessionId = Request.Cookies["npGuildIdentity"].Value;

                using (var db = new Database.NPGuildEntities())
                {
                    var authenticatedSession = db.AuthenticatedSessions.FirstOrDefault(f => f.ASPNetSessionId == sessionId && f.IpAddress == Request.UserHostAddress);

                    if(authenticatedSession != null)
                    {
                        Resources.MySession.Email = authenticatedSession.User.Email;
                        Resources.MySession.CharacterName = authenticatedSession.User.CharacterName;
                        Resources.MySession.UserLevel = authenticatedSession.User.UserLevelId;
                        Resources.MySession.UserId = authenticatedSession.User.UserId;

                        var forumUser = db.ForumUsers.FirstOrDefault(f => f.UserName == authenticatedSession.User.CharacterName && f.Email == authenticatedSession.User.Email);

                        Resources.MySession.aspnetforumUserID = forumUser.UserID;
                        Resources.MySession.aspnetforumUserName = authenticatedSession.User.CharacterName;
                    }
                }
            }
        }
    }
}
