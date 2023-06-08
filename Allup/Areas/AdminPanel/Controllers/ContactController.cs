using Allup.DAL;
using Allup.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Allup.Areas.AdminPanel.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ContactController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Area("AdminPanel")]

        public IActionResult Index()
        {
            var contacts = _dbContext.Contacts.FirstOrDefault();

            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(string name, string phoneNumber, string email, string workingHours)
        {
            return Content(name + "" + phoneNumber + "" + email + "" + workingHours);


        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var contact = _dbContext.Contacts.FindAsync(id);

            if (contact == null) return NotFound();

            return View(contact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Contact contact)
        {
            if (id == null) return NotFound();

            if(id != contact.Id) return NotFound();

            var existContact = await _dbContext.Contacts.FindAsync(id);

            existContact.Address = contact.Address;
            existContact.PhoneNumber = contact.PhoneNumber;
            existContact.Email = contact.Email;
            existContact.WorkingHours = contact.WorkingHours;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
