using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHostingEnvironment HostingEnvironment;
        private readonly ApplicationDbContext db;
        public IndexModel(

              IHostingEnvironment HostingEnvironment,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ApplicationDbContext _db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            db = _db;
            this.HostingEnvironment = HostingEnvironment;
        }

        public string Username { get; set; }
        public string url { get; set; }


        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Name")]
            public string Name { get; set; }

            [Display(Name = "Country")]
            public int CountryId { get; set; }

            [Display(Name = "City")]
            public int CityId { get; set; }
            [Display(Name = "Image")]
            public IFormFile img { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            int cityId = user.CityId ?? 1;
            int countryId = user.CountryId ?? 1;
            string name = user.Name;
            Username = userName;
            url = user.img == null ? "defaultimg.png" : user.img;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                CityId = cityId,
                CountryId = countryId,
                Name = name,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            ViewData["CountryId"] = new SelectList(db.Countries, "CountryId", "CountryName");
            ViewData["CityId"] = new SelectList(db.Cities, "CityId", "CityName");
            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            if (Input.Name != user.Name)
            {
                user.Name = Input.Name;
            }

            if (Input.CityId != user.CityId)
            {
                user.CityId = Input.CityId;
            }
            if (Input.CountryId != user.CountryId)
            {
                user.CountryId = Input.CountryId;
            }
            if (Input.img.FileName!=null)
            {

                string uploadFolder = Path.Combine(HostingEnvironment.WebRootPath, "img");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Input.img.FileName.Replace(' ', '_');
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                Input.img.CopyTo(new FileStream(filePath, FileMode.Create));
                user.img = uniqueFileName;
            }
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
