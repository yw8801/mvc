using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XSManager.Models;

namespace XSManager.Controllers
{
    public class ListController : Controller
    {

        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Session["user"] != null ? Session["user"].ToString() : null))
            {
                return Redirect("/Login");
            }

            try
            {
                // usingステートメントで自動開放(Disposeの代替)
                using (var context = new MyContext())
                {
                    // 全件
                    var employeesList = context.Employees.ToList();
                    ViewData["employeesList"] = employeesList;
                }
            }
            catch (Exception)
            {
                ViewData["Message"] = "エラーが発生しました！！！";
            }

            return View(new ListViewModel());
        }

        [HttpPost]
        public ActionResult Index(ListViewModel m, string Search, String New)
        {
            // 検索
            if (!String.IsNullOrEmpty(Search))
            {
                try
                {
                    // usingステートメントで自動開放(Disposeの代替)
                    using (var context = new MyContext())
                    {
                        if (m.Position != null)
                        {
                            // 条件
                            var employeesList = context.Employees.Where(x => x.Position == m.Position).ToList();
                            ViewData["employeesList"] = employeesList;
                        }
                        else
                        {
                            // 全件
                            var employeesList = context.Employees.ToList();
                            ViewData["employeesList"] = employeesList;
                        }
                    }
                }
                catch (Exception)
                {
                    ViewData["Message"] = "エラーが発生しました！！！";
                }
            }
            // 新規
            else if (!String.IsNullOrEmpty(New))
            {
                return Redirect("/Create");
            }

            return View(m);
        }
    }
}