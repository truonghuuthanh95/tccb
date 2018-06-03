using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCCB.Controllers
{
    [RoutePrefix("error")]
    public class ErrorsController : Controller
    {
        // GET: Errors
        [Route("")]
        public ActionResult Error()
        {
            return View();
        }
    }
}