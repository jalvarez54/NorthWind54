using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text.RegularExpressions;
using Mvc5Ef6WebApiDataFirstNthW.Helpers;

namespace Mvc5Ef6WebApiDataFirstNthW.Areas.Administration.Controllers
{
    public class FileController : Controller
    {
        [Authorize(Roles = "Admin,Dev")]
        public ActionResult DeleteLogs()
        {
            //string lockedFiles = null;
            //string deletedFiles = null;
            List<string> fd = new List<string>();
            List<string> fl = new List<string>();

            string appDataFolder = Server.MapPath("~/App_data/");
            try
            {
                var files = Directory.EnumerateFiles(appDataFolder, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".xml") || s.EndsWith(".txt"));
                foreach (string file in files)
                {
                    if (!Utils.IsFileLocked(file))
                    {
                        System.IO.File.Delete(file);
                        //deletedFiles += file + ",";
                        fd.Add(file);
                    }
                    else
                    {
                        //lockedFiles += file + ","; 
                        fl.Add(file);
                    }
                }
                ViewData["lockedFiles"] = fl;
                ViewData["deletedFiles"] = fd;
            }
            catch (Exception ex)
            {
                Helpers.Utils.SignalExceptionToElmahAndTrace(ex, this);
                return RedirectToAction("HandledFatalException", "MyError", new { area = "" });
            }
            return View();
        }

    }
}