using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile_test.Services;
using mobile_test.Views;

namespace mobile_test
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();  
        }

        protected override async void OnStart()
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
