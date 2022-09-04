using MediatR;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application.Admin.Category.Queries
{
   public class GetCategoryListQueries:IRequest<IEnumerable<Models.Models.Category>>
    {
       
    }

}
