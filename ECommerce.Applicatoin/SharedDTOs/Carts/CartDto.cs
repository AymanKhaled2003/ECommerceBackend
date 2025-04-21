using ECommerce.Applicatoin.SharedDTOs.CartItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Applicatoin.SharedDTOs.Carts
{
    public class CartDto
    {
        public string UserId { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public List<CartItemDto> CartItems { get; set; }
    }
}
