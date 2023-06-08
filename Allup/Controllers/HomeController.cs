using Allup.DAL;
using Allup.DAL.Entities;
using Allup.Extensions;
using Allup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Allup.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task<IActionResult> Index()
        {

            var sliders = await _dbContext.Sliders.ToListAsync();
            var banners = await _dbContext.Banners.ToListAsync();
            var categories = await _dbContext.Categories.ToListAsync();
            var products = await _dbContext.Products.Include(x => x.Category).ToListAsync();
            var brands = await _dbContext.Brands.ToListAsync();
            var informations = await _dbContext.Informations.ToListAsync();
            var blogs = await _dbContext.Blogs.ToListAsync();
            var testimonials = await _dbContext.Testimonials.ToListAsync();
            var visitors = await _dbContext.Visitors.ToListAsync();

            var model = new HomeViewModel
            {
                Sliders = sliders,
                Banners = banners,
                Categories = categories,
                Products = products,
                Brands = brands,
                Informations = informations,
                Blogs = blogs,
                Testimonials = testimonials,
                Visitors= visitors,

            };

            HttpContext.Session.SetJson("visitors", visitors);

            return View(model);
        }

        public IActionResult Basket()
        {
            var json = Request.Cookies["basket"];

            List<BasketViewModel> basketViewModels;

            if (json == null) basketViewModels = new List<BasketViewModel>();
            else basketViewModels = JsonConvert.DeserializeObject<List<BasketViewModel>>(json);

            return Json(basketViewModels);
        }

        public IActionResult AddToBasket(int? id)
        {
            if (id == null) return NotFound();

            var product = _dbContext.Products.Find(id);

            var json = Request.Cookies["basket"];
            List<BasketViewModel> basketViewModels;

            if (json == null) basketViewModels = new List<BasketViewModel>();
            else basketViewModels = JsonConvert.DeserializeObject<List<BasketViewModel>>(json);

            if (basketViewModels == null)
            {
                basketViewModels = new List<BasketViewModel>();
                basketViewModels.Add(new BasketViewModel
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price
                });
            }
            else
            {
                var existBasketViewModel = basketViewModels.FirstOrDefault(x => x.ProductId == product.Id);

                if(existBasketViewModel == null)
                {
                    basketViewModels.Add(new BasketViewModel
                    {
                        ProductId = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        FirstImageUrl = product.FirstImageUrl
                    });
                }

                else
                {
                    existBasketViewModel.Count++;
                }
            }
            
            json = JsonConvert.SerializeObject(basketViewModels);

            Response.Cookies.Append("basket", json);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Search(string searchedProduct)
        {
            var products = _dbContext.Products.Where(x => x.Name.Contains(searchedProduct)).ToList();

            return PartialView("_SearchedProductPartial", products);
        } 

    }
     
}