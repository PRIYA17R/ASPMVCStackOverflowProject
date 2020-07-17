using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflow.DomainModel;

namespace StackOverflow.Repositories
{
    public interface ICategoriesRepository
    {
        void InsertCategory(Category c);
        void UpdateCategory(Category c);

        void DeleteCategory(int cid);
        List<Category> GetCategories();

        List<Category> GetCategoryByCategoryID(int categoryId);

    }

    public class CategoriesRepository : ICategoriesRepository
    {
        StackeOverflowDBContext db;
     
        public CategoriesRepository()
        {
            db = new StackeOverflowDBContext();
        }

        public void DeleteCategory(int cid)
        {
           Category c = db.Categories.Where(t => t.CategoryID == cid).FirstOrDefault();
            if (c != null) { 
                  db.Categories.Remove(c);
                  db.SaveChanges();
            }
        }

        public List<Category> GetCategories()
        {
            List<Category> cat = db.Categories.ToList();
            return cat;
        }

        public List<Category> GetCategoryByCategoryID(int categoryID)
        {
            List<Category> cat = db.Categories.Where(t => t.CategoryID == categoryID).ToList();
            return cat;
        }

        public void InsertCategory(Category c)
        {
            db.Categories.Add(c);
            db.SaveChanges();
        }

        public void UpdateCategory(Category c)
        {
            Category cat = db.Categories.Where(t => t.CategoryID == c.CategoryID).FirstOrDefault();
            if (cat != null)
            {
                cat.CategoryName = c.CategoryName;
                db.SaveChanges();
            }
        }
    }
}
