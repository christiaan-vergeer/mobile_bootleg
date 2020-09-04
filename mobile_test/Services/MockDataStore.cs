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
                new Item { Id = Guid.NewGuid().ToString(), firstname = "harry", middlename="", lastname="wiedema", age=24, adress="wieberlaan 73", city="Amsterdam" },
                new Item { Id = Guid.NewGuid().ToString(), firstname = "jan", middlename="", lastname="hieber", age=18, adress="harrylaan 7", city="maastricht"  },
                new Item { Id = Guid.NewGuid().ToString(), firstname = "emma", middlename="van den", lastname="bos",  age=34, adress="wieboutstraat 23", city="Amersfoort"  },
                new Item { Id = Guid.NewGuid().ToString(), firstname = "emalien", middlename="", lastname="ziemens",  age=17, adress="amsterdamseweg 17", city="Amstelveen"  },
                new Item { Id = Guid.NewGuid().ToString(), firstname = "jarols", middlename="de", lastname="groot",  age=23, adress="rodeweg 22", city="Delft"  },
                new Item { Id = Guid.NewGuid().ToString(), firstname = "bart", middlename="", lastname="bos",  age=23, adress="zeewegstraat 42", city="Groningen"  },
                new Item { Id = Guid.NewGuid().ToString(), firstname = "maartje", middlename="voor het", lastname="park",  age=18, adress="duinstraat", city="Middelburg" }
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