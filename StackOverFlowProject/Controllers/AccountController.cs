using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using stackOverflow.ViewModels;
using StackOverflow.ServiceLayer;

namespace StackOverFlowProject.Controllers
{
    public class AccountController : Controller
    {
        IUsersService us;
        public AccountController(IUsersService us)
        {
            this.us = us;
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                int uid = this.us.InsertUser(rvm);
                Session["CurrentUserID"] = uid;
                Session["CurrentUserName"] = rvm.Name;
                Session["CurrentUserEmail"] = rvm.Email;
                Session["CurrentUserPassword"] = rvm.Password;
                Session["CurrentUserIsAdmin"] = false;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }

        }
        public ActionResult Login()

        {
            LoginViewModel lvm = new LoginViewModel();
            return View(lvm);

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
               UserViewModel uvm = this.us.GetUsersByEmailAndPassword(lvm.Email, lvm.Password);
                if(uvm!= null)
                {
                    Session["CurrentUserID"] = uvm.UserID;
                    Session["CurrentUserName"] = uvm.Name;
                    Session["CurrentEmail"] = uvm.Email;
                    Session["CurrentUserPassword"] = uvm.Password;
                    Session["CurrentUserIsAdmin"] = uvm.IsAdmin;
                    if (uvm.IsAdmin)
                    {
                        return RedirectToRoute(new { area = "admin", Controller = "AdminHome", action = "Index" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                else
                {
                    ModelState.AddModelError("x", "InValid Email or Password");
                    return View(lvm);

                }

            }
            else
            {
                ModelState.AddModelError("x", "InValid Data");
                return View(lvm);
            }
           
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}