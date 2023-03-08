using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XSManager.Models;

namespace XSManager.Controllers
{
    public class UpdateController : Controller
    {

        //context as db
        private MyContext context = new MyContext();

        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(Session["user"] != null ? Session["user"].ToString() : null))
            {
                return Redirect("/Login");
            }

            UpdateViewModel uM = new UpdateViewModel();

            try
            {
                // データの読み出し
                var employee = context.Employees.Single(x => x.Id == id);
                uM.Id = employee.Id;
                uM.Name = employee.Name;
                uM.Position = employee.Position;
                uM.StartDate = employee.StartDate;
            }
            catch (Exception)
            {
                ViewData["Message"] = "エラーが発生しました!!!";
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }

            return View(uM);
        }

        // POST
        [HttpPost]
        public ActionResult Index(UpdateViewModel m)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "モデルエラーが発生しました！！！";
                return View(m);
            }

            try
            {
                // データの更新
                var employee = context.Employees.Single(x => x.Id == m.Id);

                employee.Name = m.NewName;
                employee.Position = m.NewPosition;
                employee.StartDate = m.NewStartDate;

                context.SaveChanges();

                ViewData["Message"] = "更新しました!!!";
                ViewData["UpdatedFlag"] = true; 
            }
            catch (Exception)
            {
                ViewData["Message"] = "エラーが発生しました!!!";
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }

            return View(m);
        }
    }
}