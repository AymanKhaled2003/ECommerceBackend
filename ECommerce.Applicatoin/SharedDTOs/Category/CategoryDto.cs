using ECommerce.Applicatoin.SharedDTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Applicatoin.SharedDTOs.Category
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ProductDto> Product { get; set; }
    }
}
