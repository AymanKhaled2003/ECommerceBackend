using ECommerce.Domain.Entities;
using ECommerce.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ECommerce.Applicatoin.Specifications.Cart
{
    public class GetCartByUserIdSpec : Specification<Carts>
    {
        public GetCartByUserIdSpec(string userId)
        {
            AddCriteria(c => c.UserId == userId);
            AddInclude(nameof(Carts.CartItems));
            AddInclude("CartItems.Product");
        }
    }

}
