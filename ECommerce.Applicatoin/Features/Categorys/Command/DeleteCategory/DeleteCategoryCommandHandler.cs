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

namespace ECommerce.Applicatoin.Features.Categorys.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
    {
        private readonly IGenericRepository<Category> _categoryRepo;

        public DeleteCategoryCommandHandler(IGenericRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<ResponseModel> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepo.GetByIdAsync(request.Id);
            if (category == null)
                return ResponseModel.Failure("التصنيف غير موجود");

             _categoryRepo.Delete(category);
            await _categoryRepo.SaveChangesAsync();
            return ResponseModel.Success("تم حذف التصنيف بنجاح");
        }
    }

}
