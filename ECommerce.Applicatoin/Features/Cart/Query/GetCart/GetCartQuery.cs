using Common.Application.Abstractions.Messaging;
using ECommerce.Applicatoin.SharedDTOs.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Cart.Query.GetCart
{
    public class GetCartQuery:IQuery<IList<CartDto>>
    {
    }
}
