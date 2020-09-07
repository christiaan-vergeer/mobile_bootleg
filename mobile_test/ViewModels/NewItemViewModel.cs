using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using mobile_test.Models;
using mobile_test.Views;
using Xamarin.Forms;

namespace mobile_test.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string firstname;
        private string middlename;
        private string lastname;
        private string email;
        private string password;
        private int age;
        private string adress;
        private string city;
        private int useridentivier;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave); 
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(firstname)
                && !String.IsNullOrWhiteSpace(lastname)
                && !String.IsNullOrWhiteSpace(email)
                && !String.IsNullOrWhiteSpace(password)
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

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
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

        public int Useridentivier
        {
            get => useridentivier;
            set => SetProperty(ref useridentivier, value);
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
                email = email,
                password = password,
                age = age,
                adress = adress,
                city = city,
                useridentivier = 1 
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            //await Shell.Current.GoToAsync("..");
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
