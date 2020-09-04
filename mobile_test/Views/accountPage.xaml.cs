using mobile_test.Models;
using mobile_test.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile_test.Views
{
    public partial class accountPage : ContentPage
    {
        accountPageViewModel viewModel;

        public accountPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new accountPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}