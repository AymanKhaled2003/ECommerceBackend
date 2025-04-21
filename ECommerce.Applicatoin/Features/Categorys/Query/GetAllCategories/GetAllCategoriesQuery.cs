using Common.Application.Abstractions.Messaging;
using ECommerce.Applicatoin.SharedDTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Applicatoin.Features.Categorys.Query.GetAllCategories
{
    public class GetAllCategoriesQuery : IQuery<IList<CategoryDto>>
    {
    }
}
