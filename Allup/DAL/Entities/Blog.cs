namespace Allup.DAL.Entities
{
    public class Blog : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string DateTime { get; set; }
    }
}
