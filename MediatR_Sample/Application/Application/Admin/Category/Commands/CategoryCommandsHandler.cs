using Application.Application.Admin.Category.Commands;
using MediatR;
using Models.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Application.Admin.tbl_Category.Commands
{
    public class CategoryCommandsHandler : IRequestHandler<AddCategoryCommand, Models.Models.Category>,
        IRequestHandler<EditCategoryCommand, bool>,
        IRequestHandler<DeleteCategoryCommand,bool>
    {
        private readonly CustomContext _context;
        public CategoryCommandsHandler(CustomContext context)
        {
            _context = context;
        }


        public async Task<Models.Models.Category> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            await _context.tbl_Categories.AddAsync(request.Category);

            await _context.SaveChangesAsync(cancellationToken);
            return request.Category;
        }

        public async Task<bool> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            _context.tbl_Categories.Update(request.Category);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var cat = await _context.tbl_Categories.FindAsync(request.Id);
            _context.tbl_Categories.Remove(cat);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        
    }
}
