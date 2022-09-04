using MediatR;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application.Admin.Category.Commands
{
   public class EditCategoryCommand:IRequest<bool>
    {
        public EditCategoryCommand(Models.Models.Category category)
        {
            Category = category;
        }

        public Models.Models.Category Category { get; set; }
    }
}
