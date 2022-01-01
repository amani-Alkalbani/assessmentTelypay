using assessmentTelypay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace assessmentTelypay.Controllers
{
    public class UserController : Controller
       
    {
        TelypayDB db = new TelypayDB();

        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            //return RedirectToAction("Login");
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    if (!userExist(user.Name) == true)
                    {

                        db.Users.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("Signin");
                    }
                    else
                    {

                        ModelState.AddModelError("", " Name ia already taken .. try another one");
                    }


                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Name ia already taken .. try another one");

            }


            return View();
        }

        public bool userExist(String name)
        {

            return db.Users.Count(x => x.Name == name) > 0;


        }

        [HttpGet]
        public ActionResult Signin()
        {
            
        

            return View();
        }

        [HttpPost]
        public ActionResult Signin(User user)
        {
            try
            {
                if (ModelState.IsValidField("Email") && ModelState.IsValidField("password"))
                {

                    var user1 = (from c in db.Users
                                 where c.Name == user.Name
                                 select c).FirstOrDefault();

                    //var model = db.Users.SingleOrDefault(x => x.password == user.password);
                    //var model2 = db.Users.SingleOrDefault(x => x.Name == user.Name && x.password == user.password);

                    if (user1 == null)
                    {
                        return new HttpStatusCodeResult(500, "Error");

                    }

                    else if (!user1.password.Equals(user.password))
                    {

                        return new HttpStatusCodeResult(400, "Wrong Password");

                    }

                    else
                    {

                        return new HttpStatusCodeResult(200, "Success");
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                    }


                }
            }
            return View();
        }
    }
}