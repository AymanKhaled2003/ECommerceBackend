using ECommerce.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Product : Entity<Guid>, IAuditableEntity
    {

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        public void setData( string name ,string description ,decimal price,Guid categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            CreatedOnUtc = DateTime.UtcNow;
            ModifiedOnUtc = DateTime.UtcNow;
        }   
    }

}
