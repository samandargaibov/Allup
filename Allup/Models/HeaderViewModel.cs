using Allup.DAL.Entities;

namespace Allup.Models
{
    public class HeaderViewModel
    {
        public List<Header> Headers { get; set;}
        public List<Category> Categories { get; set;}
        public List<Contact> Contacts { get; set; }
        public List<BasketViewModel> BasketViewModels { get; set; }
    }
}
