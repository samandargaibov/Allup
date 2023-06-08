using Allup.DAL;
using Allup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Allup.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public FooterViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var footers = await _dbContext.Footers.ToListAsync();
            var contact = await _dbContext.Contacts.ToListAsync();

            var model = new FooterViewModel
            {
                Footers = footers,
                Contacts = contact
            };
            return View(model);
        }
    }
}
