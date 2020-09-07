using mobile_test.Models;
using mobile_test.Services;
using mobile_test.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile_test.Views
{
    public partial class PersonalDetail : ContentPage
    {
        PersonDetailViewModel _viewModel;
        public PersonalDetail()
        {
            BindingContext = _viewModel = new PersonDetailViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}