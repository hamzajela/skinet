

using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Product
    {
       // [Key]->It tells Visual Studio that this attribute is primary key
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}