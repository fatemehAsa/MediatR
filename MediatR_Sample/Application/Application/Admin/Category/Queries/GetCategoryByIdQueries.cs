using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application.Admin.Category.Queries
{
    public class GetCategoryByIdQueries : IRequest<Models.Models.Category>
    {
        public GetCategoryByIdQueries(int categoryId)
        {
            GenreId = categoryId;
        }

        public int GenreId { get; set; }
    }
}
