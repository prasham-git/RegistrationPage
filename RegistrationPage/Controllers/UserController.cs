using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationPage.Models;
using RegistrationPage.DataAccess;
using RegistrationPage.Filter;
using RegistrationPage;


namespace RegistrationPage.Controllers
{
   
    public class UserController : Controller
    {
        
        UserDbContext userdb = new UserDbContext();
        
        // new user registration 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                userdb.users.Add(user);
                userdb.SaveChanges();

                TempData["Name"] = user.Uname;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }
        [AuthenticationFilter]
        // display for id and name only
        public ActionResult Display()
        {
            var idname = userdb.users.ToList();
            return View(idname);
        }
        //all details displayed
        public ActionResult Detail(int id)
        {
            User userItem = userdb.users.Where(x => x.Uid == id).SingleOrDefault();
            return View(userItem);
        }

        // edit details
        public ActionResult Edit(int id)
        {
            User userItem=userdb.users.Where(x => x.Uid == id).SingleOrDefault();
            return View(userItem);
        }

        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {
                User userItem = userdb.users.Where(x => x.Uid == id).SingleOrDefault();
                user.Uid = id;
                if (userItem != null)
                {
                    userdb.Entry(userItem).CurrentValues.SetValues(user);
                    userdb.SaveChanges();
                    return RedirectToAction("Display");
                }
                else
                {
                    return View(user);
                }
            }
            else
            {
                return View();
            }
        }

        // delete details
        public ActionResult Delete(int id)
        {
            User userItem = userdb.users.Where(x => x.Uid == id).SingleOrDefault();
            return View(userItem);
        }

        [HttpPost]
        public ActionResult Delete(int id, User user)
        {
            if (ModelState.IsValid)
            {
                User userItem = userdb.users.Where(x => x.Uid == id).SingleOrDefault();
                user.Uid = id;
                if (userItem != null)
                {
                    userdb.users.Remove(userItem);
                    userdb.SaveChanges();
                    return RedirectToAction("Display");
                }
                else
                {
                    return View(user);
                }
            }
            else
            {
                return View();
            }
        }

        //searching
        [HttpGet]
        public ActionResult Search(string query)
        {
            TempData["Query"] = query;
            var users = userdb.users.Where(x => x.Uname.Contains(query)).ToList();
            if (users.Count() > 0)
            {
                return View(users);
            }
            else
            {
                TempData["Error"] = "No results found";
                return View(users);
            }
        }
    }
}