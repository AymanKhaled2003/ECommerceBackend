
using System.Threading;
using System.Threading.Tasks;
using Common.Application.Abstractions.Messaging;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Shared;
using MediatR;

namespace ECommerce.Applicatoin.Features.Products.Command.Edit
{
   

    internal class EditProductCommandHandler : ICommandHandler<EditProductCommand>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Category> _categoryRepository;

        public EditProductCommandHandler(
            IGenericRepository<Product> productRepository,
            IGenericRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseModel> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
                return  ResponseModel.Failure("المنتج غير موجود");

            var categoryExists = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (categoryExists==null)
                return ResponseModel.Failure("التصنيف غير موجود");

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;

             _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();

            return ResponseModel.Success();
        }
    }

}
