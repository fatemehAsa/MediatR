using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application.Admin.Category.Commands
{
   public class DeleteCategoryCommand:IRequest<bool>
    {
        public DeleteCategoryCommand(int categoryId)
        {

        }

        public int Id { get; set; }
    }
}
