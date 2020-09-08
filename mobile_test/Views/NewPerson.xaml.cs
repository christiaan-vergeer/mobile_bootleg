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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPerson : ContentPage
    {
        public Person person { get; set; }
        public NewPerson()
        {
            InitializeComponent();
            BindingContext = new NewPersonView();
        }
    }
}