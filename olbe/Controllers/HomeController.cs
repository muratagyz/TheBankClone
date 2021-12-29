using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using olbe.Data;
using olbe.Entity;
using olbe.Filters;
using olbe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace olbe.Controllers
{

    public class HomeController : Controller
    {


        private readonly ArbankContext _context;
        public HomeController(ArbankContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Panel");
            }
            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Panel");
            }
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(string mail, string tel, string tc, string password, string userNameSurname)
        {
            var nesne = new User()
            {
                userMail = mail,
                userPassword = password,
                userTel = tel,
                userTC = tc,
                userNameSurname = userNameSurname
            };
            var model = _context.Users.Add(nesne);
            _context.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Panel");
            }
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(User u)
        {
            var user = _context.Users.FirstOrDefault(x => x.userMail.Equals(u.userMail) && x.userPassword.Equals(u.userPassword));
            if (user != null)
            {
                HttpContext.Session.SetInt32("id", user.userId);
                HttpContext.Session.SetString("fullname", user.userNameSurname + ", " + "hoşgeldiniz.");



                var serv = _context.Users.FirstOrDefault(x => x.userMail == u.userMail);
                string userMail = serv.userMail.ToString();
                string userPassword = serv.userPassword.ToString();
                string userNameSurname = serv.userNameSurname.ToString();
                string userTC = serv.userTC.ToString();
                string userTel = serv.userTel.ToString();




                return RedirectToAction("Panel", new
                {
                    userMail = userMail,
                    userPassword = userPassword,
                    userTC = userTC,
                    userTel = userTel,
                    userNameSurname = userNameSurname

                });
            }
            return Redirect("/Home/SignIn");
        }
        public IActionResult LogOut()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        [UserFilter]
        public IActionResult Panel(string userMail, string userPassword, string userNameSurname, string userTC, string userTel)
        {
            
            List<depoDto> depo = (from bank in _context.BankAccount
                        join userr in _context.Users on bank.userId equals userr.userId
                        where userr.userMail == userMail
                        select new depoDto
                        {

                            money = bank.Money,
                            Iban=bank.IBAN
                            

                        }).ToList();
            ViewBag.userMail = userMail;
            ViewBag.userPassword = userPassword;
            ViewBag.userNameSurname = userNameSurname;
            ViewBag.userTC = userTC;
            ViewBag.userTel = userTel;
            ViewBag.depo = depo;
            return View(depo);
        }
        [UserFilter]
        public IActionResult UserInformation(string userMail)
        {
            List<infoDto> depo = (from userr in _context.Users
                                  where userr.userMail == "ali@gmail.com"
                                  select new infoDto
                                  {

                                      userMail=userr.userMail,
                                      userNameSurname=userr.userNameSurname,
                                      userPassword=userr.userPassword,
                                      userTC=userr.userTC,
                                      userTel=userr.userTel

                                  }).ToList();
            return View(depo);
        }

        //public IActionResult Kamil(string userMail)
        //{
        //    ViewBag.userMail = userMail;
        //    return View();
        //}
        //[HttpPost]
        //public JsonResult Kamil2(string userMail)
        //{
        //    return Json(new {kamil= userMail }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        //}

    }
}
