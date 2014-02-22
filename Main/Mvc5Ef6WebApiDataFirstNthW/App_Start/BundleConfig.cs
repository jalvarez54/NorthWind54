using System.Web;
using System.Web.Optimization;

namespace Mvc5Ef6WebApiDataFirstNthW
{
    public class BundleConfig
    {
        // Pour plus d’informations sur le regroupement, rendez-vous sur http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BundleTable.EnableOptimizations = true;
            //bundles.UseCdn = true; //enable CDN support 
            ////add link to jquery on the CDN 
            //var jqueryCdnPath = "https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false&key=AIzaSyALDo0MgNC8vRSNN3It38Yo9L_g8_8GoqM";

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.tablesorter.js",
                        "~/Scripts/jquery.tablesorter.widgets.js",
                        "~/Scripts/jquery-cdf54-imagePreview.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            // Utilisez la version de développement de Modernizr pour développer et apprendre. Puis, lorsque vous êtes
            // prêt pour la production, utilisez l’outil de génération sur http://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/cdf54.bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
