using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TbsGroup.Models;
using TbsGroup.ViewModels;

namespace TbsGroup.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            Session["UserName"] = null;
            BI_USER DefaultUser = new BI_USER() { MANDT = "900", SYSID = "P01" };
            return View("Index", DefaultUser);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Authorize(BI_USER userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            using (TKTDSXEntities db = new TKTDSXEntities())
            {
                var userDetails = db.BI_USER.Where(x => x.MANDT == "900" && x.SYSID == "P01"
                                            && x.Username == userModel.Username && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    ModelState.AddModelError("", "Sign failed, please check input again.");

                    return View("Index", userModel);
                }
                else
                {
                    Session["Username"] = userDetails;
                    return RedirectToAction("Index", "Liveboard");
                }
            }

        }

        public ActionResult ChangePassword(UserManager user)
        {

            var loggedUser = Session["Username"] as BI_USER;
            user.Username = loggedUser.Username;

            if ((user.CurrentPassword == null) && (user.Password == null) 
                && (user.PasswordCofirm == null))
            {
                return View("ChangePassword", user);
            }


            if (!ModelState.IsValid)
            {
                return View("ChangePassword", user);
            }
            using (TKTDSXEntities dc = new TKTDSXEntities())
            {
                //Check exist user
                BI_USER existUser = dc.BI_USER.Where(x => x.MANDT == "900" && x.SYSID == "P01"
                                    && x.Username == user.Username).FirstOrDefault();
                if ((user.CurrentPassword != null) &&(user.CurrentPassword != existUser.Password))
                {
                    ModelState.AddModelError("CurrentPassword","Current Password Incorrect");
                    return View("ChangePassword",user);
                }
                else
                {
                    user.CurrentPassword = existUser.Password;
                }

                if ((user.Password != user.PasswordCofirm)&& ((user.Password != null) || (user.PasswordCofirm!= null)))
                {
                    ModelState.AddModelError("Password", "New Password do not match with confirm password");
                    return View("ChangePassword", user);
                }
                
                if ( user.Password == existUser.Password)
                {
                    ModelState.AddModelError("Password", "New Password must different exist password");
                    return View("ChangePassword", user);
                }
                else
                {
                    existUser.Password = user.Password;
                    existUser.GhiChu = user.JobPosition;

                    dc.BI_USER.Attach(existUser);
                    var entry = dc.Entry(existUser);
                    entry.Property(e => e.Password ).IsModified = true;
                    entry.Property(e => e.GhiChu).IsModified = true;
                    dc.SaveChanges();

                    Session["Username"] = existUser;
                    ViewBag.SuccessChangePassword = "Change Password Successful.";
                    return View("ChangePassword", user);

                }                
            }
        }

        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
        
    }
}