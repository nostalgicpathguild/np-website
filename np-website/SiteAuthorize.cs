using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
//using System.Web.Http;

namespace np_website
{
    public class SiteAuthorize : AuthorizeAttribute
    {
        public int[] UserLevels { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (Resources.MySession.UserLevel == 0)
                return false;

            return UserLevels == null || UserLevels.Contains(Resources.MySession.UserLevel);
            //var isAuthorized = base.AuthorizeCore(httpContext);
            //if (!isAuthorized)
            //{
            //    return false;
            //}

            //string privilegeLevels = string.Join("", GetUserRights(httpContext.User.Identity.Name.ToString())); // Call another method to get rights of the user from DB

            //return privilegeLevels.Contains(this.AccessLevel);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Member",
                                action = "Login"
                            })
                        );
        }

    }
}