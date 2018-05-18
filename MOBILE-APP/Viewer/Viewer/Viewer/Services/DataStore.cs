using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Viewer.Models;


public interface IDataStore<T>
{
    Task<bool> AddItemAsync(T category);
    Task<bool> UpdateItemAsync(T category);
    Task<bool> DeleteItemAsync(T category);
    Task<T> GetItemAsync(int id);
    Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
}


//[assembly: Xamarin.Forms.Dependency(typeof(Viewer.Services.DataStore))]
namespace Viewer.Services
{
    public class DataStore : IDataStore<Category>
    {
        List<Category> categories;

        public DataStore()
        {
            categories = new List<Category>();
            var mockItems = new List<Category>
            {
                new Category { Id = 1, Text = "Koncert"},
                new Category { Id = 2, Text = "Spotkanie"},
                new Category { Id = 3, Text = "Wykład" },
                new Category { Id = 4, Text = "Orkiestra" },
                new Category { Id = 5, Text = "Teatr" },

            };

            foreach (var category in mockItems)
            {
                categories.Add(category);
            }
        }

        public async Task<bool> AddItemAsync(Category category)
        {
            categories.Add(category);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Category category)
        {
            var _category = categories.Where((Category arg) => arg.Id == category.Id).FirstOrDefault();
            categories.Remove(_category);
            categories.Add(category);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Category category)
        {
            var _item = categories.Where((Category arg) => arg.Id == category.Id).FirstOrDefault();
            categories.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Category> GetItemAsync(int id)
        {
            return await Task.FromResult(categories.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Category>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(categories);
        }
    }
}