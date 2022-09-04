using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Categories
{
    public interface ICategoryService
    {
        Task<Category> AddCategory(Category category,CancellationToken cancellationToken);
        Task<Category> UpdateCategory(Category category, CancellationToken cancellationToken);
        Task<Category> FindCategoryById(int categoryId, CancellationToken cancellationToken);
        void RemoveCategory(int categoryId, CancellationToken cancellationToken);
        Task<IEnumerable<Category>> GetAllCategories(CancellationToken cancellationToken);
        Task<bool> IsExistCategory(int categoryId, CancellationToken cancellationToken);
    }
}
