using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XSManager.Models;

namespace XSManager.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel m)
        {
            // usingステートメントで自動開放(Disposeの代替)
            try
            {
                using (var context = new MyContext())
                {
                    // データの読み出し
                    var user = context.Users.Where(x => x.Username == m.UserName && x.Password == m.Password);
                    if (user.Count() > 0)
                    {
                        Session["user"] = m.UserName;
                        return Redirect("/List");
                    }
                    else
                    {
                        ViewData["Message"] = "ユーザー名またはパスワードが正しくありません!!!";
                    }
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