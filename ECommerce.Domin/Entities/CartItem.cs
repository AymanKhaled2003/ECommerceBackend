using ECommerce.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class CartItem : Entity<Guid>
    {
        public Guid CartId { get; set; }
        [ForeignKey("CartId")]
        public Carts Carts { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; } 
    }


}
