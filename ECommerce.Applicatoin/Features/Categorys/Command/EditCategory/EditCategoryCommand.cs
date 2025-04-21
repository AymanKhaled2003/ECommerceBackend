using Common.Application.Abstractions.Messaging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Applicatoin.Features.Categorys.Command.EditCategory
{
    public class EditCategoryCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    
}
