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
    public class GetCartItemByProductIdAndCartIdSpecification : Specification<CartItem>
    {
        public GetCartItemByProductIdAndCartIdSpecification(Guid cartId, Guid productId)
        {
            AddCriteria(ci => ci.CartId == cartId && ci.ProductId == productId);
        }
    }

}
