using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class CategoryProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLocked { get; set; }
        public int OrderDisplay { get; set; }
        public DateTime DateCreated { get; set; }
        public string Slug { get; set; }
        public string PageTitle { get; set; }
        public string Path { get; set; }
        public string MetaDescription { get; set; }
        public string Colour { get; set; }
        public string Image { get; set; }
        public Guid? ParentId { get; set; }
        public string ExtendedDataString { get; set; }
        public virtual CategoryProduct CategoryProductNavigation { get; set; }
        public virtual ICollection<CategoryProduct> InverseCategoryProductNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

