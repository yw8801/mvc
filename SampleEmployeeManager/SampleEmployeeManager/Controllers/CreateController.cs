using System;
using System.Web.Mvc;
using XSManager.Models;

namespace XSManager.Controllers
{
    public class CreateController : Controller
    {
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Session["user"] != null ? Session["user"].ToString() : null))
            {
                return Redirect("/Login");
            }

            return View(new CreateViewModel());
        }

        [HttpPost]
        public ActionResult Index(CreateViewModel m)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "モデルエラーが発生しました！！！";
                return View(m);
            }

            try
            {
                // usingステートメントで自動開放(Disposeの代替)
                using (var context = new MyContext())
                {
                    context.Employees.Add(new EmployeeModel
                    {
                        Id = m.Id,
                        Name = m.Name,
                        Position = m.Position,
                        StartDate = m.StartDate,
                    }
                    );
                    context.SaveChanges();

                    ViewData["Message"] = "登録しました！！！";
                    ViewData["CreatedFlag"] = true;
                }
            }
            catch (Exception)
            {
                ViewData["Message"] = "エラーが発生しました！！！";
            }

            return View(m);
        }
    }
}