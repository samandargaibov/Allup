namespace Allup.DAL.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        public string FirstImageUrl { get; set; }

        public string SecondImageUrl { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

    }
}
