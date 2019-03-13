using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CategoryBusiness
    {
        private EazyCartContext eazyCartContext;

        public List<Category> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Categories.ToList();
            }
        }

        public Category Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Categories.Find(id);
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

        public void Update(Category category)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var categoryToUpdate = eazyCartContext.Categories.Find(category.Id);
                if (categoryToUpdate != null)
                {
                    eazyCartContext.Entry(categoryToUpdate).CurrentValues.SetValues(category);
                    eazyCartContext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var category = eazyCartContext.Categories.Find(id);
                if (category != null)
                {
                    eazyCartContext.Categories.Remove(category);
                    eazyCartContext.SaveChanges();
                }
            }
        }
    }
}
