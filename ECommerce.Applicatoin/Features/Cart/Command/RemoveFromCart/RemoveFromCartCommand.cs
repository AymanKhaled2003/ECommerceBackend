using Common.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Applicatoin.Features.Cart.Command.RemoveFromCart
{
    public class RemoveFromCartCommand : ICommand
    {
        public string UserId { get; set; } // المستخدم اللي عايز يشيل المنتج
        public Guid ProductId { get; set; } // المنتج اللي عايز يشيله
    }
}
