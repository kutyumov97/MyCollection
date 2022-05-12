using MyCollection.Data;
using MyCollection.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyCollection.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            var response = new LoginViewModel();            
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid) return View(login);

            var user = await _userManager.FindByEmailAsync(login.EmailAddress);

            if (user != null)
            {
                //User is found, check status
                if (user.Status == Status.Active)
                {
                    //Status is active, check password
                    var passwordCheck = await _userManager.CheckPasswordAsync(user, login.Password);
                    if (passwordCheck)
                    {
                        //Password correct
                        var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                        if (result.Succeeded)
                        {
                            GlobalVariables.SelectedUserId = user.Id;
                            GlobalVariables.ActualUserId = user.Id;
                            TempData["success"] = "You have successfully logged in.";
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    //Password is incorrect
                    TempData["error"] = "Wrong password. Please, try again";
                    return View(login);
                }
                TempData["error"] = "The user is blocked.";
                return View(login);
            }
            //User not found
            TempData["error"] = "User not found. Please, try again";
            return View(login);
        }


        [HttpGet]
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid) return View(register);

            var user = await _userManager.FindByEmailAsync(register.EmailAddress);
            if (user != null)
            {
                TempData["error"] = "This email address is already in use";
                return View(register);
            }

            var newUser = new AppUser()
            {
                Email = register.EmailAddress,
                UserName = register.UserName,
                Status = Status.Active,
                UserRole = "user"
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, register.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            TempData["success"] = "You have successfully registered. Please, log in";
            return RedirectToAction("Login", "Account");
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            GlobalVariables.SelectedUserId = null;
            GlobalVariables.ActualUserId = null;
            TempData["success"] = "You have successfully logged out.";
            return RedirectToAction("Index", "Collection");
        }
    }
}
