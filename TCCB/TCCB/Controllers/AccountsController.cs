using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCB.Models.DAO;
using TCCB.Models.DTO;
using TCCB.Repositories.Interfaces;

namespace TCCB.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        IAccountRepository accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [Route("login", Name ="login")]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [Route("requestLogin")]
        [HttpPost]
        public ActionResult RequestLogin(RequestLogin requestLogin)
        {
            Account account = accountRepository.GetAccountByUsernameAndPassword(requestLogin.Username, requestLogin.Password);

            if (account != null && account.IsActive == false)
            {
                return Json(new ResponseResult(403, "Tài khoản hiện đang bị khóa", null));
            }
            else if (account == null)
            {
                return Json(new ResponseResult(403, "Sai tên truy cập hoặc mật khẩu", null));
            }
            Session.Add(CommonConstants.USER_SESSION, account);
            
            var accountJson = JsonConvert.SerializeObject(account,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Json(new ResponseResult(200, "success", accountJson), JsonRequestBehavior.AllowGet);

        }
        [Route("logout")]
        [HttpGet]
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}