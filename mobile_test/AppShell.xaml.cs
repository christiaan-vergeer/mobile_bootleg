using System;
using System.Collections.Generic;
using mobile_test.ViewModels;
using mobile_test.Views;
using Xamarin.Forms;

namespace mobile_test
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(accountPage), typeof(accountPage));
            Routing.RegisterRoute(nameof(PersonalDetail), typeof(PersonalDetail));
            //Routing.RegisterRoute(nameof(NewPerson), typeof(NewPerson));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
