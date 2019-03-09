using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deneme.UI.Entities;
using Deneme.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.UI.Controllers
{
     public class AccountController:Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private SignInManager<CustomIdentityUser> _signInManager;

        public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid) //gelen kayıt formu eksiksiz ise
            {
                CustomIdentityUser user = new CustomIdentityUser
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email
                };

                //atamaları yap.

                IdentityResult result =
                    _userManager.CreateAsync(user, registerViewModel.Password).Result;

                if (result.Succeeded)//eğer sonuç doğru ise---------------->ROLE KISMI<------------------------------------
                {
                    if (!_roleManager.RoleExistsAsync("Admin").Result) //admin adında bir role yoksa
                    {
                        CustomIdentityRole role = new CustomIdentityRole
                        {
                            Name = "Admin" //admin adında bir role oluştur.
                        };

                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                        if (!roleResult.Succeeded)//eğer rol oluşmadıysa
                        {
                            ModelState.AddModelError("", "Role Eklenemiyor.");
                            return View(registerViewModel);
                        }
                    }

                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                    return RedirectToAction("Login", "Account");
                }
            }

            return View(registerViewModel);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)//giriş bilgilerinde hata yoksa
            {
                var result = _signInManager.PasswordSignInAsync(loginViewModel.UserName,
                    loginViewModel.Password, loginViewModel.RememberMe , false).Result;

                if (result.Succeeded)//bilgiler doğruysa giriş yap
                {
                    return RedirectToAction("Index", "Admin");
                }

                ModelState.AddModelError("", "Yanlış Giriş Yaptınız.");
            }

            return View(loginViewModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync().Wait();//Çıkış yap.
            return RedirectToAction("Login");
        }
    }
}
