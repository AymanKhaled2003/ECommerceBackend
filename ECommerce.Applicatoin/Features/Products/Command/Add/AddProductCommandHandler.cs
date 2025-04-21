using Common.Application.Abstractions.Messaging;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Applicatoin.Features.Products.Command.Add
{
    public class AddProductCommandHandler:ICommandHandler<AddProductCommand>
    {
        private readonly IGenericRepository<Product> _productRepository;
        public AddProductCommandHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ResponseModel> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var data = new Product();

            data.setData(request.Name, request.Description, request.Price, request.CategoryId);

            await  _productRepository.AddAsync(data);
            await _productRepository.SaveChangesAsync(cancellationToken);
            return ResponseModel.Success("Product added successfully");
        }
    }
   
   
}
