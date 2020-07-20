using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace StackOverFlowProject

{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include("~/Scripts/jquery-3.5.1.js", "~/Scripts/umd/popper.js"));
            bundles.Add(new StyleBundle("~/Style/bootstrap").Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Style/Site").Include("~/Content/Style.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}