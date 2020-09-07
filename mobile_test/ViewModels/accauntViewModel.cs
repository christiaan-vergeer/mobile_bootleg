using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using mobile_test.Models;
using mobile_test.Views;

namespace mobile_test.ViewModels
{
    public class accauntViewModel:BaseViewModel
    {

        private string itemId;
        private string fullname;
        private int age;
        private string adress;
        private string city;
        public string Id { get; set; }

        public string Fullname
        {
            get => fullname;
            set => SetProperty(ref fullname, value);
        }

        public int Age
        {
            get => age;
            set => SetProperty(ref age, value);
        }
        public string Adress
        {
            get => adress;
            set => SetProperty(ref adress, value);
        }
        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var items = await DataStore.GetItemsAsync(true);
                foreach (var Item in items)
                {
                    if(Item.useridentivier == 1)
                    {
                        Id = Item.Id;
                        Fullname = Item.firstname + "" + Item.middlename + "" + Item.lastname;
                        Age = Item.age;
                        Adress = Item.adress;
                        City = Item.city;
                    }
                }
                var item = await DataStore.GetItemAsync(itemId);
                
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void gotoaccaunt()
        {

            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }
    }

}
