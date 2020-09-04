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
        accountPageViewModel _viewModel;
        public accountPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new accountPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}