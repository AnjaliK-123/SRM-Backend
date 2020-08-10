using UserRegistration2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration2.Services
{
    public interface ICategoryRepo
    {
        bool SaveChanges();
        IEnumerable<Category> GetCategory();
        Category GetCategoryById(int Id);

        void CreateCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(Category category);
    }
}
