using Assignments.Models.Assign1;
using System;
using System.Web.Mvc;

namespace Assignments.Controllers
{
    public class Assign1Controller : Controller
    {
        #region "Display Greeting"
        /// <summary>
        /// Display the greeting view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }
        #endregion

        #region "RSVP Form"
        /// <summary>
        /// Display Rsvp form for party invite
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        #endregion

        #region "RSVP Confirmation"
        /// <summary>
        /// If form is valid display thanks view else display error
        /// </summary>
        /// <param name="guestResponse"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                // TODO: Email response to the party organizer
                //SmtpClient smtpClient = new SmtpClient();
                //smtpClient.EnableSsl = true;
                //MailMessage msg = new MailMessage("wcyber23@gmail.com", guestResponse.Email);
                //msg.Subject = "Hey, welcome.";
                //msg.Body = "You are invited for the party";
                //smtpClient.Send(msg);
                return View("Thanks", guestResponse);
            }
            else
            {
                // there is a validation error               
                return View();
            }
        }
        #endregion
    }
}