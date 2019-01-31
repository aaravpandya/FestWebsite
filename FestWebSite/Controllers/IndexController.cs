using System.Collections.Generic;
using System.Linq;
using FestWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FestWebSite.Controllers
{
    public class IndexController : Controller
    {
        private AppDbContext _DbContext;

        private string SendGridDetails = @"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";
        private string SendGridDetails2 = @"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";

        public IndexController(AppDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        [Route("")]
        [Route("[controller]/[action]")]
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
        public async System.Threading.Tasks.Task<IActionResult> PostDataAsync(RegisterViewModel vm)
        {
            RegisterModel rm = new RegisterModel()
            {
                Name = vm.Name, Accomodation = vm.Accomodation, Email = vm.Email, UniversityName = vm.UniversityName,
                Events = vm.Events, ContactNumber = vm.ContactNumber, NumberOfParticipants = vm.NumberOfParticipants
            };
            _DbContext.RegisterModels.Add(rm);
            _DbContext.SaveChanges();
            var client = new SendGridClient(SendGridDetails2);
            var msg = new SendGridMessage
            {
                From = new EmailAddress("team@67thmilestone.com", "The 67th Milestone Team"),
                Subject = "Registration Confirmation for BMUFEST 2019",
                HtmlContent = $"Thank you for registering with us. We will get back to you soon. <br/ > Contact for more info: <br/><br/> <b>Purnendu Bansal</b><br/>Email : purnendu.bansal.16bb@bml.edu.in<br/>Phone Number : 9559007777 <br><br> <b>Jonnavithula Chandan</b><br/>Email : jonnavithula.chandan.17ece@bml.edu.in<br/>Phone Number : 8309533570 <br><br><br> Please do not reply to this email. This email is unmonitored. "
            };
            msg.AddTo(new EmailAddress(vm.Email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            await client.SendEmailAsync(msg);
            return RedirectToAction("Home", "Index");
        }

        [Route("admin")]
        public IActionResult Admin()
        {
            List<RegisterModel> rms = _DbContext.RegisterModels.ToList();
            ViewBag.rms = rms;
            return View();
        }
    }
}
