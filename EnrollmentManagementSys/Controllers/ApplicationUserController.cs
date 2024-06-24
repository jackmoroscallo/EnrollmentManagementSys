using EnrollmentManagementSys.Models;
using EnrollmentManagementSys.Models.ModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace EnrollmentManagementSys.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ApplicationUserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUserView userView)
        {
            //Checks if the inputs are valid based on the annotations of the model.
            if (ModelState.IsValid)
            {
                //Creates an instance of the ApplicationUser to extact needed data from the model view.
                var user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = userView.Email,
                    FirstName = userView.FirstName,
                    LastName = userView.LastName,
                    UserName = userView.Email
                };

                //Creates the user with the use of the userManager object.
                var result = await _userManager.CreateAsync(user, userView.Password);
               
                

                if (result.Succeeded)
                {
                    //This will check if there is a user currently logged in it will redirect to login but if there is 
                    //a login session it will go to the index
                    if (User.Identity.IsAuthenticated == true)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return RedirectToAction(nameof(Login));
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(userView);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LogInView model)
        {
            if (ModelState.IsValid)
            {
                //Uses the SignInManager to sign in if the user passes the authentication.
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid Login attempt");

            }
            return View(model);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            

            if (user == null)
            {
                ViewBag.ErrorMEssage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            // var userRoles = await _userManager.GetRolesAsync(user);

            var model = new ApplicationUserView
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                //  Roles = userRoles
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(ApplicationUserView model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMEssage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {

                user.Id = model.Id;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                


                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    // user.AzureLink = await _blobStorageService.UploadBlobFileAsync(model.ImageFile, model.Id.ToString());

                    TempData["success"] = "User updated successfully!";
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);

            }

        }
    }
}
