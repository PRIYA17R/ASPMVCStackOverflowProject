using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using stackOverflow.ViewModels;
using StackOverflow.DomainModel;
using StackOverflow.Repositories;

namespace StackOverflow.ServiceLayer
{
    public interface ICategoryService
    {
        void InsertCategory(CategoriesViewModel cvm);
        void UpdateCategory(CategoriesViewModel cvm);
        List<CategoriesViewModel> GetCategories();

        void DeleteCategory(int cID);
        CategoriesViewModel GetCategoryByID(int cid);


    }
   public class CategoryService : ICategoryService
    {
        CategoriesRepository cr;

        CategoryService()
        {
            cr = new CategoriesRepository();
        }

        public void DeleteCategory(int cID)
        {
            cr.DeleteCategory(cID);
        }

        public List<CategoriesViewModel> GetCategories()
        {
            List<Category> c = cr.GetCategories();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Category, Category>(); cfg.IgnoreUnMapped(); });
            IMapper mapper = config.CreateMapper();
            List<CategoriesViewModel> cvm = mapper.Map<List<Category>, List<CategoriesViewModel>>(c);
            return cvm;
        }

        public CategoriesViewModel GetCategoryByID(int cid)
        {
           Category c = cr.GetCategoryByCategoryID(cid).FirstOrDefault();
            CategoriesViewModel cvm = null;
            if (c != null)
            { 
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Category, Category>(); cfg.IgnoreUnMapped(); });
            IMapper mapper = config.CreateMapper();
            cvm = mapper.Map<Category,CategoriesViewModel>(c);
            }
            return cvm;
        }

        public void InsertCategory(CategoriesViewModel cvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CategoriesViewModel, Category>(); cfg.IgnoreUnMapped(); });
            IMapper mapper = config.CreateMapper();
            Category c = mapper.Map<CategoriesViewModel, Category>(cvm);
            cr.InsertCategory(c);
        }

        public void UpdateCategory(CategoriesViewModel cvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CategoriesViewModel, Category>(); cfg.IgnoreUnMapped(); });
            IMapper mapper = config.CreateMapper();
            Category c = mapper.Map<CategoriesViewModel, Category>(cvm);
            cr.UpdateCategory(c);
        }
    }
}
