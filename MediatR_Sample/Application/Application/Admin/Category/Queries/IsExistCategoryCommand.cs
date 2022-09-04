using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application.Admin.Category.Queries
{
   public class IsExistCategoryCommand:IRequest<bool>
    {

        public IsExistCategoryCommand(int categoryId)
        {

        }

        public int CategoryId { get; set; }
    }
}
