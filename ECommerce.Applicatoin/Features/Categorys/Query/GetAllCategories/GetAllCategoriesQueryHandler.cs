using Common.Application.Abstractions.Messaging;
using ECommerce.Applicatoin.SharedDTOs.Category;
using ECommerce.Applicatoin.SharedDTOs.Product;
using ECommerce.Applicatoin.Specifications.Categories;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Applicatoin.Features.Categorys.Query.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, IList<CategoryDto>>
    {
        private readonly IGenericRepository<Category> _categoryRepo;

        public GetAllCategoriesQueryHandler(IGenericRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<ResponseModel<IList<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = _categoryRepo.GetWithSpec(new GetAllCategorySpec()).data.ToList();

            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Product = c.Products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            }).ToList();
        }
    }

}
