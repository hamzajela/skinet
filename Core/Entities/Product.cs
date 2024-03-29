

using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Product: BaseEntity
    {
       // [Key]->It tells Visual Studio that this attribute is primary key
       // public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        
        public ProductType ProductType { get; set; }
       public int ProductTypeId { get; set; }
    
       public ProductBrand ProductBrand { get; set; }
       public int ProductBrandId { get; set; }
    
    }

}