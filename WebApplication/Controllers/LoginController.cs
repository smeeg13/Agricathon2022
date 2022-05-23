using Agricathon2022;
using EFCoreApp2021;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly AgricathonContext _context;

        public LoginController(AgricathonContext context)
        {
            _context = context;

        }

        public IActionResult Login()
        {

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login login)
        {
             
            if (ModelState.IsValid)
            {
                    List<Proprietaire> users = _context.ProprietaireSet.ToList();
                    User user = null;

                    for(int i=0; i< users.Count(); i++)
                    {
                        if(users[i].Email.Equals(login.Email) && users[i].Password.Equals(login.Password))
                        {
                            user = users[i];
                        }
                    }

                    if (user != null)
                    {
                            //Redirect to customer page if not an Proprio
                            if (user.EstPropriétaire)
                            {
                                HttpContext.Session.SetInt32("UserID", user.UserID);
                                return RedirectToAction("Index", "Proprietaires");
                            }
                            //Redirect to Exploitant
                            if (user.EstExploitant)
                            {
                                    HttpContext.Session.SetInt32("UserID", user.UserID);
                                    return RedirectToAction("Index", "Exploitants");
                            }


                            ModelState.AddModelError(string.Empty, "Utilisateur ou mot de passe invalide");

                            HttpContext.Session.SetInt32("UserID", user.UserID);
                            return RedirectToAction("Index", "Home");

                    }

                
            return RedirectToAction("Index", "Home");

            }
        
    }

        public IActionResult Register()
        {
            return View();
        }
    }
}
