using mobile_test.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace mobile_test.ViewModels
{
    [QueryProperty(nameof(PersonId), nameof(PersonId))]
    public class PersonDetailViewModel : BaseViewModel
    {
        private string personId;
        private int Age;
        private string firstName;
        private string lastName;
        private string bio;
        private string gender;
        private string preffrerence;
        public string Id { get; set; }

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        public int age
        {
            get => Age;
            set => SetProperty(ref Age, value);
        }

        public string Bio
        {
            get => bio;
            set => SetProperty(ref bio, value);
        }

        public string Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }

        public string Prefference
        {
            get => preffrerence;
            set => SetProperty(ref preffrerence, value);
        }

        public string PersonId
        {
            get
            {
                return personId;
            }
            set
            {
                personId = value;
                LoadPersonId(value);
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        public async void LoadPersonId(string PersonId)
        {
            try
            {
                var person = await PersonDataStore.GetPersonIDAsync(PersonId);
                Id = person.Id;
                FirstName = person.FirstName;
                LastName = person.LastName;
                Bio = person.Bio;
                age = person.Age;
                Gender = person.gender.ToString();
                Prefference = person.prefference.ToString();
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }

}
