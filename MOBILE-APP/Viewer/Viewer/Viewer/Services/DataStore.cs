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
        List<Item> items;

        public DataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Category { Id = 1, Text = "Koncert"},
                new Category { Id = 2, Text = "Spotkanie"},
                new Category { Id = 3, Text = "Wykład" },
                new Category { Id = 4, Text = "Orkiestra" },
                new Category { Id = 5, Text = "Teatr" },

            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}