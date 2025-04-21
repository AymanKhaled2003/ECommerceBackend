using ECommerce.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Carts : Entity<Guid>, IAuditableEntity
    {
        public string UserId { get; set; }

        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }

        public void RecalculateTotals()
        {
            TotalQuantity = CartItems?.Sum(i => i.Quantity) ?? 0;
            TotalPrice = CartItems?.Sum(i => i.Price * i.Quantity) ?? 0;
            ModifiedOnUtc = DateTime.UtcNow;
        }
    }

}
