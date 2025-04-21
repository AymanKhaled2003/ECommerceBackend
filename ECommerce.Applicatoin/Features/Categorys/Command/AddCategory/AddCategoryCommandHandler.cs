using Common.Application.Abstractions.Messaging;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Applicatoin.Features.Categorys.Command.AddCategory
{
    public class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommand>
    {
        private readonly IGenericRepository<Category> _categoryRepo;

        public AddCategoryCommandHandler(IGenericRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<ResponseModel> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category();
            category.SetData(request.Name); 
            await _categoryRepo.AddAsync(category);
            await _categoryRepo.SaveChangesAsync(); 
            return ResponseModel.Success();  
        }
    }

}
