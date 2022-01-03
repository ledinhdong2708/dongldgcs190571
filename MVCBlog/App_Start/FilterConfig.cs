using System.Web;
using System;
using System.Web.Mvc;

namespace MVCBlog
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    //public class ActionSpeedProfilerAttribute : FilterAttribute, IActionFilter
    //{
    //    public void OnActionExecuted(ActionExecutedContext filterContext)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class AuthLogAttribute : AuthorizeAttribute
    {
        public AuthLogAttribute()
        {
            View = "AuthorizeFailed";
        }

        public string View { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            IsUserAuthorized(filterContext);
        }

        private void IsUserAuthorized(AuthorizationContext filterContext)
        {

            if (filterContext.Result == null)
                return;


            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {

                var vr = new ViewResult();
                vr.ViewName = View;

                ViewDataDictionary dict = new ViewDataDictionary();
                dict.Add("Message", "Sorry you are not Authorized to Perform this Action");

                vr.ViewData = dict;

                var result = vr;

                filterContext.Result = result;
            }
        }
    }
}
