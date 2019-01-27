using FestWebSite.Models;
using Microsoft.AspNetCore.Mvc;


namespace FestWebSite.Controllers
{
    public class IndexController : Controller
    {
        private AppDbContext _DbContext;


        public IndexController(AppDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        [Route("")]
        public IActionResult Home()
        {
            return View();
        }
        [Route("[controller]/[action]")]
        public IActionResult Register()
        {
            return View();
        }
        [Route("[controller]/[action]")]
        public IActionResult PostData(RegisterViewModel vm)
        {
            RegisterModel rm = new RegisterModel()
            {
                Name = vm.Name, Accomodation = vm.Accomodation, Email = vm.Email, UniversityName = vm.UniversityName,
                Events = vm.Events, ContactNumber = vm.ContactNumber, NumberOfParticipants = vm.NumberOfParticipants
            };
            _DbContext.RegisterModels.Add(rm);
            _DbContext.SaveChanges();

            return RedirectToAction("Home", "Index");
        }
    }
}
