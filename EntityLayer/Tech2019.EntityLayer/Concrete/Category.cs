using System.Collections.Generic;

namespace Tech2019.EntityLayer.Concrete
{
    public class Category
    {
        public byte CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }

}
