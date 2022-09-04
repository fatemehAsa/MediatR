using Application.Application.Admin.Category.Commands;
using Application.Application.Admin.Category.Queries;
using MediatR;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Categories
{
    public class CategoryService : ICategoryService
    {

        private readonly IMediator _mediator;
        public CategoryService(IMediator mediator)
        {

            _mediator = mediator;
        }
        public async Task<Category> AddCategory(Category category, CancellationToken cancellationToken)
        {
            await _mediator.Send(new AddCategoryCommand(category),cancellationToken);
            return category;

        }

        public async Task<Category> FindCategoryById(int categoryId, CancellationToken cancellationToken)
        {
            var cat = await _mediator.Send(new GetCategoryByIdQueries(categoryId),cancellationToken);
            return cat;
        }

        public async Task<IEnumerable<Category>> GetAllCategories( CancellationToken cancellationToken)
        {
           var s= await _mediator.Send(new GetCategoryListQueries(),cancellationToken);
            return s;
              
        }

        public async Task<bool> IsExistCategory(int categoryId,CancellationToken cancellationToken)
        {
            return await _mediator.Send(new IsExistCategoryCommand(categoryId),cancellationToken);
        }

        public void RemoveCategory(int categoryId, CancellationToken cancellationToken)
        {
            var cat = _mediator.Send(new DeleteCategoryCommand(categoryId),cancellationToken);

        }

        public async Task<Category> UpdateCategory(Category category, CancellationToken cancellationToken)
        {
            await _mediator.Send(new EditCategoryCommand(category),cancellationToken);
            return category;
        }
    }
}
