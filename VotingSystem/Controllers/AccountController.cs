using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;
using VotingSystem.Models;
using VotingSystem.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using VotingSystem.Models.ViewModels;

public class AccountController : Controller
{
	private readonly ApplicationDbContext _context;

	public AccountController(ApplicationDbContext context)
	{
		_context = context;
	}
    public async Task<IActionResult> Logout()
    {
        HttpContext.Session.Remove("UserId");
        return RedirectToAction("Index", "Home");
    }
    [HttpGet]
	public IActionResult Login()
	{
		var userId = HttpContext.Session.GetString("UserId");
		if (userId != null)
		{
			return RedirectToAction("Index", "Home");
		}
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Login(LoginViewModel model)
	{
		
		
		if (ModelState.IsValid)
		{
			var user = _context.Users.SingleOrDefault(u => u.Email == model.Email);
			String hashedPassword = "";
			if (user != null)
			{
				hashedPassword = PasswordHasher.HashPasswordWithSalt(model.Password, user.PasswordSalt);

				if (hashedPassword == user.Password)
				{
					HttpContext.Session.SetString("UserId", user.Id.ToString());
					return RedirectToAction("Index", "Home");
				}
			}
			else
			{

				ModelState.AddModelError(string.Empty, "Email not found.");
			}

			// Invalid login attempt
			ModelState.AddModelError(string.Empty, "Invalid login attempt.");
		}

		return View(model);
	}

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegistrationViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Check if the email is already registered
            var existingUser = _context.Users.SingleOrDefault(u => u.Email == model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Email is already registered.");
                return View(model);
            }

            // Hash the password and generate a salt
            string salt = PasswordHasher.GenerateSalt();
            string hashedPassword = PasswordHasher.HashPasswordWithSalt(model.Password, salt);

            // Create a new user
            var user = new User
            {
                UserFullName = model.UserFullName,
                Email = model.Email,
                Password = hashedPassword,
                PasswordSalt = salt,
                Age = model.Age
            };

            // Add the user to the database
            _context.Users.Add(user);
            _context.SaveChanges();

            // Redirect to the login page or any other desired page
            return RedirectToAction("Login", "Account");
        }

        return View(model);
    }
}
