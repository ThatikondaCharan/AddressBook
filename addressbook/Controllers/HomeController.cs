using AddressBook.Models;
using AddressBook.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        private Service Service;
        public HomeController(Service service)
        {
            Service= service;
        }
        public IActionResult Index()
        {
            TempData["contactdetails"]= Service.GetAllContactsList();
            ViewData["id"] = Service.GetAllContactsList().ElementAt(0).ID;
            return View("DisplayContact", Service.GetAllContactsList().ElementAt(0));
        }
        public IActionResult AddContact()
        {
            TempData["contactdetails"] = Service.GetAllContactsList();
            return View();
        }
        [HttpPost]
        public IActionResult AddContact(ContactDetailsViewModel contact)
        {
            if (ModelState.IsValid)
            {
                Service.AddContactToList(contact);
                TempData["contactdetails"] = Service.GetAllContactsList();
                ViewData["id"] = Service.GetLastContact().ID;
                return View("DisplayContact", contact);
            }
            TempData["contactdetails"] = Service.GetAllContactsList();
            return View();
        }

        public IActionResult DisplayContact(int id)
        {

            ContactDetailsViewModel contact=Service.GetContactFromContactList(id);
            TempData["contactdetails"] = Service.GetAllContactsList();
            ViewData["id"] = id;
            return View(contact);
        }

        public IActionResult EditContact(int id)
        {
            ContactDetailsViewModel contact = Service.GetContactFromContactList(id);
            TempData["contactdetails"] = Service.GetAllContactsList();
            return View(contact);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditContact(ContactDetailsViewModel contact)
        {
            if (!ModelState.IsValid)
            {
                TempData["contactdetails"] = Service.GetAllContactsList();
                return View(contact);
            }
            Service.UpdateContactInContactList(contact);
            TempData["contactdetails"] = Service.GetAllContactsList();
            ViewData["id"] = contact.ID;
            return View("DisplayContact", contact);
        }

        public IActionResult DeleteContact(int id)
        {
            Service.DeleteContactFromContactList(id);
            return RedirectToAction("index");   
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}