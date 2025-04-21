using Common.Application.Abstractions.Messaging;
using ECommerce.Applicatoin.SharedDTOs.Product;
using ECommerce.Applicatoin.Specifications.Products;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Applicatoin.Features.Products.Query.GetAllProduct
{
    public class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, IList<ProductDto>>
    {
        private readonly IGenericRepository<Product> _productRepository;

        public GetAllProductsQueryHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseModel<IList<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products =  _productRepository.GetWithSpec(new GetAllProductWithCategorySpec(request)).data.ToList();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name
            }).ToList();

        }
    }

}
