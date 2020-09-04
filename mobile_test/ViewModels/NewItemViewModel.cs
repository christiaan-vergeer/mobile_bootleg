using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using mobile_test.Models;
using Xamarin.Forms;

namespace mobile_test.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string firstname;
        private string middlename;
        private string lastname;
        private int age;
        private string adress;
        private string city;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave); //, ValidateSave
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(firstname)
                && !String.IsNullOrWhiteSpace(lastname)
                //&& !String.IsNullOrWhiteSpace(description);
                && !String.IsNullOrWhiteSpace(adress)
                && !String.IsNullOrWhiteSpace(city);
        }

        public string Firstname
        {
            get => firstname;
            set => SetProperty(ref firstname, value);
        }

        public string Middlename
        {
            get => middlename;
            set => SetProperty(ref middlename, value);
        }
        public string Lastname
        {
            get => lastname;
            set => SetProperty(ref lastname, value);
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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                firstname = firstname,
                middlename = middlename,
                lastname = lastname,
                age = age,
                adress = adress,
                city = city
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
