﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Business
{
    /// <summary>
    /// This business logic class is responsible for managing the
    /// categories from the database.
    /// </summary>
    public class CategoryBusiness
    {
        private EazyCartContext eazyCartContext;

        public CategoryBusiness()
        {
            this.eazyCartContext = new EazyCartContext();
        }

        public CategoryBusiness(EazyCartContext eazyCartContext)
        {
            this.eazyCartContext = eazyCartContext;
        }

        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <returns>A List of all categories.</returns>
        public List<Category> GetAll()
        {
            return eazyCartContext.Categories.ToList();
        }

        /// <summary>
        /// Return a certain category by given Id.
        /// </summary>
        /// <param name="id">Id of the category.</param>
        /// <returns>A category, corresponding to the given Id.</returns>
        public Category Get(int id)
        {
            return eazyCartContext.Categories.Find(id);
        }

        /// <summary>
        /// Get a list containing all categories' names.
        /// </summary>
        /// <returns>A List of type string, containing all names of categories.</returns>
        public List<string> GetAllNames()
        {
            var allCategories = eazyCartContext.Categories.ToList();
            var allNames = new List<string>();

            foreach (var category in allCategories)
            {
                allNames.Add(category.Name);
            }

            return allNames;
        }

        /// <summary>
        /// Add a new category.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <param name="categoryId">Id of the category.</param>
        public void Add(string categoryName, int categoryId)
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

        /// <summary>
        /// Update certain category's fields.
        /// </summary>
        /// <param name="categoryName">Give the name of the category.</param>
        /// <param name="categoryId">Give the id of the category.</param>
        public void Update(string categoryName, int categoryId)
        {
            // // Set the new category's fields.
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

        /// <summary>
        /// Delete a category by a given Id.
        /// </summary>
        /// <param name="id">Id of the supplier to delete.</param>
        public void Delete(int id)
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
}
