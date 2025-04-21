using Common.Application.Abstractions.Messaging;
using ECommerce.Applicatoin.SharedDTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Applicatoin.Features.Products.Query.GetAllProduct
{
    public class GetAllProductsQuery:IQuery<IList<ProductDto>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
