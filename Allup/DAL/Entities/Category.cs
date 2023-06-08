namespace Allup.DAL.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public bool IsMain { get; set; }
        public int? CategoryId { get; set; }

        public List<Category>? ParentCategory { get; set; }

    }
}
