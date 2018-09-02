using System.Web.Mvc;
using System.Web.Routing;

namespace TestApp.WebClient.Filters
{
    public class AuthorizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = filterContext.HttpContext;

            if (ctx.Session["AuthID"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Index", controller = "Home" }));
            }

            if (ctx.Request.Cookies["AuthID"].Value != ctx.Session["AuthID"].ToString())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Index", controller = "Home" }));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}