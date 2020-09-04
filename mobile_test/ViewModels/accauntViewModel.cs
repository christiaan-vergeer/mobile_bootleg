using mobile_test.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using mobile_test.Models;


namespace mobile_test.ViewModels
{
    public class accauntViewModel:BaseViewModel
    {
        public Command gotocommand { get; }

        public accauntViewModel()
        {
            Title = "My Accaunt";
            gotocommand = new Command(gotoaccaunt);

        }
        private async void gotoaccaunt()
        {
           
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }
    }
}
