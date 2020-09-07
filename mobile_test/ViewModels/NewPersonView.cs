using mobile_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

using Xamarin.Forms;

namespace mobile_test.ViewModels
{
    public class NewPersonView : BaseViewModel
    {
        private int Age;
        private string FirstName;
        private string LastName;
        private string Bio;
        private string gender;
        private string Prefference;

        public NewPersonView()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(FirstName)
                && !String.IsNullOrWhiteSpace(LastName)
                && !String.IsNullOrWhiteSpace(Bio)
                && !String.IsNullOrWhiteSpace(gender)
                && !String.IsNullOrWhiteSpace(Prefference);
        }

        public string firstName
        {
            get => FirstName;
            set => SetProperty(ref FirstName, value);
        }

        public string lastName
        {
            get => LastName;
            set => SetProperty(ref LastName, value);
        }

        public string bio
        {
            get => Bio;
            set => SetProperty(ref Bio, value);
        }

        public string Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }
        public string prefference
        {
            get => Prefference;
            set => SetProperty(ref Prefference, value);
        }
        public int age
        {
            get => Age;
            set => SetProperty(ref Age, value);
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
            Person newPerson = new Person()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Bio = bio,
                gender = Models.Gender.Neutral,
                prefference = Models.Prefference.Neutral
            };

            await PersonDataStore.AddPersonAsync(newPerson);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}