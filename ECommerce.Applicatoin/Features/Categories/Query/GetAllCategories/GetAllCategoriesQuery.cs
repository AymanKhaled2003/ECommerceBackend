using Common.Application.Abstractions.Messaging;
using ECommerce.Applicatoin.SharedDTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Categories.Query.GetAllCategories
{
    public class GetAllCategoriesQuery : IQuery<IList<CategoryDto>>
    {
    }
}
