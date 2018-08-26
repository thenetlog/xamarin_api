using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Report.Models;

namespace Report.Services
{
    public interface IDataStores<T>
    {
        Task<bool> AddItemAsynce(T item);
        Task<bool> UpdateItemAsynce(T item);
        Task<bool> DeleteItemAsynce(string id);
        Task<T> GetItemAsynce(string id);
        Task<IEnumerable<T>> GetItemsAsynce(bool forceRefresh = false);
        
    }
}
