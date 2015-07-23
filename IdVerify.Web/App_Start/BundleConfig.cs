using System.Web;
using System.Web.Optimization;

namespace ID_RESTAPI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
        //  bundles.Add(new var cssTransformer = new CssTransformer();  
        //var jsTransformer = new JsTransformer();  
        //var nullOrderer = new NullOrderer();  
  
        var defaultScriptsBundle = new Bundle("~/bundles/default.js").Include(  
                    "~/Scripts/jquery-{version}.js",  
                     "~/Scripts/jquery-ui-{version}.js",  
                    "~/Scripts/site.js");  
        //defaultScriptsBundle.Transforms.Add(jsTransformer);  
        //defaultScriptsBundle.Orderer = nullOrderer;  
        bundles.Add(defaultScriptsBundle);  
  
        var defaultStylesBundle = new Bundle("~/Content/default.css").Include("~/Content/site.less");  
        //defaultStylesBundle.Transforms.Add(cssTransformer);  
       // defaultStylesBundle.Orderer = nullOrderer;  
        bundles.Add(defaultStylesBundle); 
        }
    }
}