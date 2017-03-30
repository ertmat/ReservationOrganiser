using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReservationOrganiser.Entities;
using ReservationOrganiser.Services;
using ReservationOrganiser.ViewModels;
using System.Threading.Tasks;

namespace ReservationOrganiser.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private IUserManagerData _userManagerData;
        private IHotelManagerData _hotelManager;

        public AccountController(UserManager<User> userManager, 
                                SignInManager<User> signInManager, 
                                IUserManagerData userManagerData,
                                IHotelManagerData hotelManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userManagerData = userManagerData;
            _hotelManager = hotelManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Creating First Hotel for User
                var hotel = new Hotel();
                hotel.Name = "Default Hotel";
                hotel.Status = 1;
                _hotelManager.Add(hotel);
                _hotelManager.Commit();

                var user = new User { UserName = model.UserName };

                user.Email = model.Email;
                user.SelectedHotelId = hotel.Id;
                var createResult = await _userManager.CreateAsync(user, model.Password);

                if (createResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);

                    return RedirectToAction("AddHotel", "Home", new { id = hotel.Id });
                }
                else
                {
                    foreach(var error in createResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync
                        (model.UserName, model.Password,
                        model.RememberMe, false);
                if (loginResult.Succeeded)
                {
                    if (Url.IsLocalUrl(model.RedirectUrl))
                    {
                        return Redirect(model.RedirectUrl);
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Nazwa użytkownika i hasło nie pasują do siebie");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
