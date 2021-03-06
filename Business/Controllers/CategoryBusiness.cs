﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Business.Controllers
{
    /// <summary>
    /// This business logic class is responsible for managing the
    /// categories from the database.
    /// </summary>
    public class CategoryBusiness
    {
        private EazyCartContext eazyCartContext;

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
            return this.eazyCartContext.Categories.ToList();
        }

        /// <summary>
        /// Return a certain category by given Id.
        /// </summary>
        /// <param name="id">Id of the category.</param>
        /// <returns>A category, corresponding to the given Id.</returns>
        public Category Get(int id)
        {
            return this.eazyCartContext.Categories.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Get all categories' names.
        /// </summary>
        /// <returns>A List of type string, containing the name of each category.</returns>
        public List<string> GetAllNames()
        {
            var allCategories = this.eazyCartContext.Categories.ToList();
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

            var allCountriesWithGivenId = this.eazyCartContext.Categories.Where(x => x.Id == categoryId);

            if (allCountriesWithGivenId.Count() > 0)
            {
                throw new ArgumentException($"Category with ID {categoryId} already exists.");
            }

            this.eazyCartContext.Categories.Add(category);
            this.eazyCartContext.SaveChanges();
        }

        /// <summary>
        /// Update certain category's fields.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <param name="categoryId">Id of the category.</param>
        public void Update(string categoryName, int categoryId)
        {
            var categoryToUpdate = eazyCartContext.Categories.FirstOrDefault(x => x.Id == categoryId);
            categoryToUpdate.Name = categoryName;

            this.eazyCartContext.SaveChanges();
        }

        /// <summary>
        /// Delete a category by a given Id.
        /// </summary>
        /// <param name="id">Id of the supplier to delete.</param>
        public void Delete(int id)
        {
            var category = this.eazyCartContext.Categories.FirstOrDefault(x => x.Id == id);
            var allProducts = this.eazyCartContext.Products.ToList();

            foreach (var product in allProducts)
            {
                if (product.CategoryId == category.Id)
                {
                    throw new ArgumentException("One or more products are related to this category.");
                }
            }

            // Remove the chosen category and save the changes in the context.
            this.eazyCartContext.Categories.Remove(category);
            this.eazyCartContext.SaveChanges();
        }
    }
}
