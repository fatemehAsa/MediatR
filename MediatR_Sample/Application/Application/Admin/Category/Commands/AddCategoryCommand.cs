using MediatR;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application.Admin.Category.Commands
{
    public class AddCategoryCommand : IRequest<Models.Models.Category>
    {
        public AddCategoryCommand(Models.Models.Category category)
        {
            Category = category;

        }

        public Models.Models.Category Category { get; set; }

    }
}
