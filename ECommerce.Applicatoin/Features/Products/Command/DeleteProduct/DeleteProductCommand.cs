using Common.Application.Abstractions.Messaging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
