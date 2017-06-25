using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZEMP.DAO;
using ZEMP.DTO;
using ZEMP.Header;

namespace ZEMP.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            Session[CommonHeader.ssAccount] = null;
            ZEMP_USER account = new ZEMP_USER
            {
                SystemId = "900P01"  //default PRD system
            };

            return View("Index", account);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ZEMP_USER account)
        {
            if (!ModelState.IsValid)
            {
                return View(account);
            }

            using (TKTDSXEntities db = new TKTDSXEntities())
            {

                string strInput = account.Password.Trim();

                string decryptPass = CryptorEngine.Encrypt(strInput, true);

                var userDetails = db.ZEMP_USER.Where(x => x.SystemId == CommonHeader.defaultSystemId
                                            && x.Username == account.Username && x.Password == decryptPass).FirstOrDefault();
                if (userDetails == null)
                {
                    ModelState.AddModelError("", "Sign failed, please check input again.");

                    return View("Index", account);
                }
                else
                {
                    Session[CommonHeader.ctlAccount] = userDetails;
                    return RedirectToAction("Index", "Liveboard");
                }
            }

        }
    }
}