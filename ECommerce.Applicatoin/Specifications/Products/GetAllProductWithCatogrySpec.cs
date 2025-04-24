using ECommerce.Application.Features.Products.Query.GetAllProduct;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Specification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ECommerce.Application.Specifications.Products
{
    internal class GetAllProductWithCategorySpec : Specification<Product>
    {
        public GetAllProductWithCategorySpec(GetAllProductsQuery query)
        {
            ApplyPaging(query.PageSize, query.PageIndex);
            AddInclude(nameof(Domain.Entities.Product.Category));

        }
    }
}
