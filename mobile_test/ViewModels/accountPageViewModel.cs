using mobile_test.Models;
using mobile_test.Services;
using mobile_test.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using mobile_test.ViewModels;

namespace mobile_test.ViewModels
{
    class accountPageViewModel : BaseViewModel
    {
        public Person _selectedPerson;
        public ObservableCollection<Person> Persons { get; }
        public Command LoadPersonsCommand { get; }
        public Command AddPersonCommand { get; }
        public Command<Person> PersonTapped { get; }

        public accountPageViewModel()
        {
            Title = "People";
            Persons = new ObservableCollection<Person>();
            LoadPersonsCommand = new Command(async () => await ExecuteLoadPersonsCommand());

            PersonTapped = new Command<Person>(OnPersonSelected);

            AddPersonCommand = new Command(OnAddPerson);
        }

        async Task ExecuteLoadPersonsCommand()
        {
            IsBusy = true;

            try
            {
                Persons.Clear();
                var persons = await PersonDataStore.GetPersonsAsync(true);
                foreach (var person in persons)
                {
                    Persons.Add(person);
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
            SelectedPerson = null;
        }

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                SetProperty(ref _selectedPerson, value);
                OnPersonSelected(value);
            }
        }

        private async void OnAddPerson(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewPerson));
        }

        async void OnPersonSelected(Person person)
        {
            if (person == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(PersonalDetail)}?{nameof(PersonDetailViewModel.PersonId)}={person.Id}");
        }
    }
}
