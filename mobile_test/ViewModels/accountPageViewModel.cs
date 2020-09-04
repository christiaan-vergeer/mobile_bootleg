using mobile_test.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobile_test.ViewModels
{
    class accountPageViewModel : BaseViewModel
    {
            private Person _selectedItem;
            public Command LoadItemsCommand { get; }
            public Command AddItemCommand { get; }
            public Command<Item> ItemTapped { get; }

            public accountPageViewModel()
            {
                Title = "Browse";
                LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

                ItemTapped = new Command<Item>(OnItemSelected);

                AddItemCommand = new Command(OnAddItem);
            }

            async Task ExecuteLoadItemsCommand()
            {
                IsBusy = true;

                try
                {
                    Person.Clear();
                    var items = await DataStore.GetItemsAsync(true);
                    foreach (var item in items)
                    {
                        Person.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;
                }
            }

            public void OnAppearing()
            {
                IsBusy = true;
                SelectedItem = null;
            }

            public Item SelectedItem
            {
                get => _selectedItem;
                set
                {
                    SetProperty(ref _selectedItem, value);
                    OnItemSelected(value);
                }
            }

            private async void OnAddItem(object obj)
            {
                await Shell.Current.GoToAsync(nameof(NewItemPage));
            }

            async void OnItemSelected(Item item)
            {
                if (item == null)
                    return;

                // This will push the ItemDetailPage onto the navigation stack
                await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
            }
        }
}
