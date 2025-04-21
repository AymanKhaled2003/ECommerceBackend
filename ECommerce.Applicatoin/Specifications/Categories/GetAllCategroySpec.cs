using ECommerce.Domain.Entities;
using ECommerce.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Applicatoin.Specifications.Categories
{
    public class GetAllCategorySpec:Specification<Category>
    {
        public GetAllCategorySpec()
        {
            AddInclude(nameof(Domain.Entities.Category.Products));
            AddOrderBy(x => x.Name);
            ApplyPaging(0, 10);
        }
    }
   
}
