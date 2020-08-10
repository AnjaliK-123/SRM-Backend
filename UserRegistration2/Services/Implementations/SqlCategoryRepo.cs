using Microsoft.EntityFrameworkCore;
using UserRegistration2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration2.Services.Implementations
{
    public class SqlCategoryRepo : ICategoryRepo
    {
        private readonly SRMContext _context;

        public SqlCategoryRepo(SRMContext context)
        {
            _context = context;
        }

        public void CreateCategory(Category category)
        {
           if(category== null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _context.Category.Add(category);
        }

       

        public void DeleteCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _context.Category.Remove(category);
        }

       

        public IEnumerable<Category> GetCategory()
        {
            return _context.Category.ToList();
        }

       

        public Category GetCategoryById(int Id)
        {
              var category = _context.Category.Include(cat => cat.Department).Where(cat => cat.Id == Id).FirstOrDefault();
                                            
            return category;
        }

        

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCategory(Category category)
        {
            
        }

       
    }
}
