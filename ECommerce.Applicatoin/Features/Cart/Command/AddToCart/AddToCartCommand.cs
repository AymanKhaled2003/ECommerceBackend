using Common.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Applicatoin.Features.Cart.Command.AddToCart
{
    public class AddToCartCommand : ICommand
    {
        public string UserId { get; set; } 
        public Guid ProductId { get; set; } 
        public int Quantity { get; set; } 
    }
}
