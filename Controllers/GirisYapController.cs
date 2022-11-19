using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Siniflar;
using System.Web.Security;
using System.Security.Cryptography.X509Certificates;

namespace TravelTripProject.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap

        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            //Kullanıcı adı ve şifrenin doğruluğunu kontrol etmek için:
            var bilgiler = c.Admins.FirstOrDefault(x =>
                x.Kullanici == ad.Kullanici && x.Sifre ==
                ad.Sifre);

            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index", "Admin");
                //Eğer kullanıcı adi ve şifre doğruysa, Admine  yönlendirir.

            }
            else
            {
                return View();
            }

        }
            public ActionResult Logout()
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "GirisYap");
            }
        }
    }
