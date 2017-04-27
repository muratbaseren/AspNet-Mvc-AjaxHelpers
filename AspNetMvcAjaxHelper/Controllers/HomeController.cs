using AspNetMvcAjaxHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcAjaxHelper.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Index2()
        {
            return View();
        }


        public ActionResult Index3()
        {
            List<string> datas = new List<string>();

            if (Session["datas"] != null)
                datas = Session["datas"] as List<string>;

            return View(datas);
        }


        public PartialViewResult GetData()
        {
            System.Threading.Thread.Sleep(3000);

            return PartialView("_UrunlerPartialView");
        }


        public PartialViewResult SetData(Veri model)
        {
            System.Threading.Thread.Sleep(3000);

            return PartialView("_UrunlerPartialView2", model.Data);
        }

        public PartialViewResult InsertUrun(string newdata)
        {
            System.Threading.Thread.Sleep(3000);

            List<string> datas = new List<string>();

            if (Session["datas"] != null)
                datas = Session["datas"] as List<string>;

            datas.Add(newdata);

            Session["datas"] = datas;

            return PartialView("_YeniUrunPartialView", new Tuple<int, string>(datas.IndexOf(newdata), newdata));
        }

        public PartialViewResult RemoveUrun(int id)
        {
            System.Threading.Thread.Sleep(3000);

            List<string> datas = new List<string>();

            if (Session["datas"] != null)
                datas = Session["datas"] as List<string>;

            datas.RemoveAt(id);

            Session["datas"] = datas;

            return PartialView("_YeniUrunPartialView", new Tuple<int, string>(-1, string.Empty));
        }
    }
}