using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gnostice.StarDocsSDK;
using System.Web.Mvc;

namespace projem.Controllers
{
    public class BelgeController : Controller
    {
        // GET: Belge
        public ActionResult Index()
        {

            string file = @"S:\doc\asdasd.pdf";
            ViewerSettings viewerSettings = new ViewerSettings();
            viewerSettings.VisibleFileOperationControls.Open = true;
            ViewResponse viewResponse = MvcApplication.starDocs.Viewer.CreateView(
                new FileObject(file), null, viewerSettings
                );
            return new RedirectResult(viewResponse.Url);
        }
    }
}