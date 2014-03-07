using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5Ef6WebApiDataFirstNthW.Models;
using Mvc5Ef6WebApiDataFirstNthW.Helpers;
using System.Diagnostics;

namespace Mvc5Ef6WebApiDataFirstNthW.Controllers
{
    public class MyErrorController : Controller
    {
        /// <summary>
        /// Handle 404 error
        /// </summary>
        /// <param name="aspxerrorpath"></param>
        /// <returns>ViewResult</returns>
        public ActionResult NotFound(string aspxerrorpath)
        {
            ViewData["error_path"] = aspxerrorpath;
            MyTracer.MyTrace(TraceLevel.Warning, this.GetType(), null, null, string.Format("404 resource {0} not found", aspxerrorpath), null);

            return View();
        }
        /// <summary>
        /// Handle 403 error
        /// </summary>
        /// <param name="action"></param>
        /// <returns>ViewResult</returns>
        public ActionResult AccessDenied(string action)
        {
            @ViewData["action"] = action;
            MyTracer.MyTrace(TraceLevel.Warning, null, null, null, string.Format("Acess denied in the action {0}", action), null);
            return View();
        }
        /// <summary>
        /// Handle errors # 403, 404
        /// </summary>
        /// <returns>ViewResult</returns>
        public ActionResult UnHandledException(string aspxerrorpath)
        {
            ViewData["error_path"] = aspxerrorpath;
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            Exception unHandledException = new ApplicationException("My UnHandled Exception");
            MyTracer.MyTrace(TraceLevel.Error, this.GetType(), controllerName, actionName, string.Format("Unhandled exception in {0}", aspxerrorpath), unHandledException);
            return View(new HandleErrorInfo(unHandledException, controllerName, actionName));
        }
        /// <summary>
        /// For handled fatal exceptions
        /// </summary>
        /// <returns></returns>
        public ActionResult HandledFatalException()
        {
            return View();
        }

        #region Test errors actions
        public ActionResult NoView()
        {
            return View();
        }
        [Authorize(Roles = "Dev")]
        public ActionResult ForTestUnHandledException()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Show SignalExceptionToElmahAndTrace usage  with try...catch in a non fatal handled exception
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Dev")]
        public ActionResult ForTestHandledException()
        {
            try
            {
                throw new ApplicationException("Handled exception for test");
            }
            catch (Exception ex)
            {
                // Handled exception catch code
                Helpers.Utils.SignalExceptionToElmahAndTrace(ex, this);
                
            }
            // ...............................
            // Continu program...
            // ...............................
            // Finally call the view
            return View();
        }
        /// <summary>
        /// Show SignalExceptionToElmahAndTrace usage with try...catch in a fatal handled exception
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Dev")]
        public ActionResult ForTestHandledFatalException()
        {
            try
            {
                throw new ApplicationException("Fatal error for test");
            }
            catch (Exception ex)
            {
                // Unhandled exception catch code
                Helpers.Utils.SignalExceptionToElmahAndTrace(ex, this);
                // RedirectToAction called if fatal error
                return RedirectToAction("HandledFatalException", "MyError", new { area = "" });
            }
            // View called if no fatal error
            //return View(); // Never reached  in this sample
        }
        #endregion        

    }
}