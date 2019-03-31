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

        /// <summary>
        /// Return all categories.
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAll()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Categories.ToList();
            }
        }

        /// <summary>
        /// Return a certain category.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category Get(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                return eazyCartContext.Categories.Find(id);
            }
        }

        /// <summary>
        /// Return a list containing all categories' names.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllNames()
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var allCategories = eazyCartContext.Categories.ToList();
                var allNames = new List<string>();

                foreach (var category in allCategories)
                {
                    allNames.Add(category.Name);
                }

                return allNames;
            }
        }

        /// <summary>
        /// Add a new category.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="categoryId"></param>
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

        /// <summary>
        /// Update certain category's fields.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="categoryId"></param>
        public void Update(string categoryName, int categoryId)
        {         
            using (eazyCartContext = new EazyCartContext())
            {
                // // Update the category's fields.
                var newCategory = new Category()
                {
                    Name = categoryName,
                    Id = categoryId
                };

                var categoryToUpdate = eazyCartContext.Categories.Find(categoryId);

                // Set the updated category's fields.
                eazyCartContext.Entry(categoryToUpdate).CurrentValues.SetValues(newCategory);
                eazyCartContext.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a certain category.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (eazyCartContext = new EazyCartContext())
            {
                var category = eazyCartContext.Categories.Find(id);
                var allProducts = eazyCartContext.Products.ToList();
                foreach (var product in allProducts)
                {
                    if (product.CategoryId == category.Id)
                    {
                        throw new ArgumentException("One or more products are related to this category.");
                    }
                }

                // Remove the chosen category and save the changes in the context.
                eazyCartContext.Categories.Remove(category);
                eazyCartContext.SaveChanges();
            }
        }

        /// <summary>
        /// Add a new category.
        /// </summary>
        /// <param name="category"></param>
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
