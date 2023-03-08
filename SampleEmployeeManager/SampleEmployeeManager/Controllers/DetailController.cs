using System;
using System.Linq;
using System.Web.Mvc;
using XSManager.Models;

namespace XSManager.Controllers
{
    public class DetailController : Controller
    {
        // context as db
        private MyContext context = new MyContext();

        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(Session["user"] != null ? Session["user"].ToString() : null))
            {
                return Redirect("/Login");
            }

            DetailViewModel dM = new DetailViewModel();

            try
            {
                // データの読み出し
                var employee = context.Employees.Single(x => x.Id == id);

                dM.Id = employee.Id;
                dM.Name = employee.Name;
                dM.Position = employee.Position;
                dM.StartDate = employee.StartDate;
            }
            catch (Exception)
            {
                ViewData["Message"] = "エラーが発生しました！！！";
            }
            finally
            {
                context.Dispose();
            }

            return View(dM);
        }

        [HttpPost]
        public ActionResult Index(DetailViewModel m,string Update, string Delete)
        {
            // 削除
            if (!String.IsNullOrEmpty(Delete))
            {
                try
                {
                    var employee = context.Employees.Single(x => x.Id == m.Id);
                    context.Employees.Remove(employee);
                    context.SaveChanges();

                    ViewData["Message"] = "削除しました！！！";
                    ViewData["DeletedFlag"] = true;
                }
                catch (Exception)
                {
                    ViewData["Message"] = "エラーが発生しました！！！";
                }
                finally
                {
                    context.Dispose();
                } 
            }
            // 更新
            else if (!String.IsNullOrEmpty(Update))
            {
                return Redirect("/Update?id="+ m.Id);
            }
            return View(m);
        }
    }
}