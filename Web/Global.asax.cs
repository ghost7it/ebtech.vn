﻿using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Web.Controllers;
namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error()
        {
            ////Lấy thông tin của controller, action hiện tại
            //HttpContextBase currentContext = new HttpContextWrapper(HttpContext.Current);
            //UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            //RouteData routeData1 = urlHelper.RouteCollection.GetRouteData(currentContext);

            //string action = routeData1.Values["action"] as string;
            //string controller = routeData1.Values["controller"] as string;
            //string area = routeData1.DataTokens["area"] as string;
            //var exception = Server.GetLastError();
            ////Ghi log lỗi
            ////Không dùng vì trong config đã cài đặt ghi rồi
            ////Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            //Dictionary<string, object> TempData = Context.Session["__ControllerTempData"] as Dictionary<string, object>;
            //if (TempData == null)
            //{
            //    TempData = new Dictionary<string, object>();
            //}
            //TempData["Exception"] = exception.Message;
            //Response.Clear();
            //Server.ClearError();
            //if (!string.IsNullOrEmpty(area) && area == "Management")
            //{
            //    HttpContext.Current.Session["__ControllerTempData"] = TempData;
            //    HttpContext.Current.Response.RedirectToRoute("ManagementGeneralError");
            //    HttpContext.Current.ApplicationInstance.CompleteRequest();
            //}
            //else
            //{
            //    HttpContext.Current.Session["__ControllerTempData"] = TempData;
            //    HttpContext.Current.Response.RedirectToRoute("FrontEndPublicIndex");
            //    HttpContext.Current.ApplicationInstance.CompleteRequest();
            //}
        }
    }
}
