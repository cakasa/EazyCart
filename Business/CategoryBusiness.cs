using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Business
{
    public class CategoryBusiness
    {
        private EazyCartContext eazyCartContext;
        private ProductBusiness productBusiness = new ProductBusiness();

        public void Add(string categoryName, int categoryId)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var category = new Category
                {
                    Id = categoryId,
                    Name = categoryName
                };

                eazyCartContext.Categories.Add(category);
                try
                {
                    eazyCartContext.SaveChanges();
                }
                catch
                {
                    throw new ArgumentException($"Category with ID {categoryId} already exists.");
                }               
            }
        }

        public Category Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Categories.Find(id);
            }
        }

        public void Update(string categoryName, int categoryId)
        {
            Category category = new Category()
            {
                Name = categoryName,
                Id = categoryId
            };

            using (eazyCartContext = new EazyCartContext())
            {
                var categoryToUpdate = eazyCartContext.Categories.Find(categoryId);
                eazyCartContext.Entry(categoryToUpdate).CurrentValues.SetValues(category);
                eazyCartContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var category = eazyCartContext.Categories.Find(id);
                if(productBusiness.GetAll().Any(x=>x.CategoryId == category.Id))
                {
                    throw new ArgumentException("One or more products are related to this category.");
                }

                eazyCartContext.Categories.Remove(category);
                eazyCartContext.SaveChanges();
            }
        }

        //  ----------------------------------------------------------------------------

        public List<Category> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Categories.ToList();
            }
        }

        public List<string> GetAllNames()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var allCategories = eazyCartContext.Categories.ToList();
                var allNames = new List<string>();
                allNames.Add("Category");
                
                foreach(var category in allCategories)
                {
                    allNames.Add(category.Name);
                }

                return allNames;
            }
        }

       

        public void Add(Category category)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                eazyCartContext.Categories.Add(category);
                eazyCartContext.SaveChanges();
            }
        }

        

        
    }
}
