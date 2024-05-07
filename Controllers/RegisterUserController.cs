using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projectDemo.Models;

namespace projectDemo.Controllers
{
    public class RegisterUserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManage;
        public RegisterUserController(UserManager<IdentityUser>userManager,SignInManager<IdentityUser>signInManager)
        {
            _userManager = userManager;
            _signInManage = signInManager;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser registerobj)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = registerobj.Email, Email = registerobj.Email };

               var result= await _userManager.CreateAsync(user,registerobj.Password);

                if (result.Succeeded)
                {
                    await _signInManage.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Dashboard");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
            
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUser loginobj)
        {
            if (ModelState.IsValid)
            {
               var result= await _signInManage.PasswordSignInAsync(loginobj.Email, loginobj.Password, loginobj.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                ModelState.AddModelError(string.Empty, "Invalid username password");
            }
            return View("Login", loginobj);
        }

        
        public async Task<IActionResult> LogOut()
        {
            await _signInManage.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
