using Allup.DAL;
using Allup.DAL.Entities;
using Allup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Allup.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public HeaderViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var headers = await _dbContext.Headers.ToListAsync();
            var product = await _dbContext.Products.ToListAsync();
            var categories = await _dbContext.Categories.ToListAsync();
            var contacts = await _dbContext.Contacts.ToListAsync();

            var model = new HeaderViewModel
            {
                Headers = headers,
                Categories = categories,
                Contacts= contacts
            };

            return View(model);
        }

    }
}
