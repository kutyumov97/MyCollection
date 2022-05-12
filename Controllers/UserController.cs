using MyCollection.Data;
using MyCollection.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MyCollection.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _db;
        public UserController(UserManager<AppUser> userManager, ApplicationDbContext db)
        {
            _db = db;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            var AppUserList = _db.AppUsers;
            return View(AppUserList);
        }


        public async Task<IActionResult> ChangeRole(string id)
        {
            var user = _db.AppUsers.Find(id);
            if(user.UserRole == "user")
            {
                user.UserRole = "admin";
                await _userManager.RemoveFromRoleAsync(user, UserRoles.User);
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            else if(user.UserRole == "admin")
            {
                user.UserRole = "user";
                await _userManager.RemoveFromRoleAsync(user, UserRoles.Admin);
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }              
            return RedirectToAction("Index");
        }


        public IActionResult Block(string id)
        {
            var user = _db.AppUsers.Find(id);
            user.Status = (Status)1;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Unblock(string id)
        {
            var user = _db.AppUsers.Find(id);
            user.Status = 0;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Del(string id)
        {
            var obj = _db.AppUsers.Find(id);
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Del(AppUser obj)
        {
            var user = _db.AppUsers.Find(obj.Id);
            _db.AppUsers.Remove(user);
            _db.SaveChanges();
            return RedirectToAction("Index", "User");
        }
    }
}
