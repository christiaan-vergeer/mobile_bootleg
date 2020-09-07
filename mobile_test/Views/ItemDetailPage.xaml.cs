using System.ComponentModel;
using Xamarin.Forms;
using mobile_test.ViewModels;

namespace mobile_test.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            BindingContext = new ItemDetailViewModel();
        }
    }
}