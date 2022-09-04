using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application.Admin.Category.Queries
{
    public class CategoryQueriesHandler : IRequestHandler<GetCategoryByIdQueries, Models.Models.Category>,
        IRequestHandler<GetCategoryListQueries, IEnumerable<Models.Models.Category>>,
        IRequestHandler<IsExistCategoryCommand, bool>
    {
        CustomContext _context;
        public CategoryQueriesHandler(CustomContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Models.Category>> Handle(GetCategoryListQueries request, CancellationToken cancellationToken)
            => await _context.tbl_Categories.ToListAsync(cancellationToken);



        public async Task<Models.Models.Category> Handle(GetCategoryByIdQueries request, CancellationToken cancellationToken)
        {
            var cat = await _context.tbl_Categories.FirstOrDefaultAsync(c => c.GenreId == request.GenreId, cancellationToken);
            return cat;

        }

        public async Task<bool> Handle(IsExistCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _context.tbl_Categories.AnyAsync(c => c.GenreId == request.CategoryId, cancellationToken);
        }
    }
}
