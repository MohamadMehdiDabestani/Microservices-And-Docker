using System.ComponentModel.DataAnnotations;

namespace Catalog.API
{
    public class Product
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public string ImageFile { get; set; }

        public int Price { get; set; }
        public string Category { get; set; }
    }
}
