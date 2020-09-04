using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mobile_test.Models;

namespace mobile_test.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), firstname = "harry", age=24 },
                new Item { Id = Guid.NewGuid().ToString(), firstname = "jan", age=18 },
                new Item { Id = Guid.NewGuid().ToString(), firstname = "emma", age=34 },
                new Item { Id = Guid.NewGuid().ToString(), firstname = "emalien", age=17 },
                new Item { Id = Guid.NewGuid().ToString(), firstname = "jarols", age=23 },
                new Item { Id = Guid.NewGuid().ToString(), firstname = "bart", age=23 },
                new Item { Id = Guid.NewGuid().ToString(), firstname = "maartje", age=18}
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

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