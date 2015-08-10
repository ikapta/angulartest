using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MvcApplication1.Models;
using MvcApplication1.ViewModels;



namespace MvcApplication1.Controllers
{
    public class PeopleController : Controller
    {
        //
        // GET: /People/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Index(IEnumerable<PeopleView> pee)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var s = Request.Form.ToString();
           // var ss= serializer.Deserialize<PeopleView>(Request.Form.ToString());

            Dictionary<string,Boolean> dc=new Dictionary<string, bool>();
            var name = "";
            Boolean success = true;
            if (String.IsNullOrEmpty(Request["PId"]))
            {
                name = "id不能为空";
                success = false;
            }
            dc.Add(name,success);
            var pe = new People();

            List<KeyValuePair<string, bool>> list = new List<KeyValuePair<string, bool>>();
            foreach (var b in dc)
                list.Add(b);
            return Json(list);
        }
    }
}
