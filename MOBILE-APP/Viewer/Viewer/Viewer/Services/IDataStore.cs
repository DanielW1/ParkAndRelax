using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Viewer.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T category);
        Task<bool> UpdateItemAsync(T category);
        Task<bool> DeleteItemAsync(T category);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
