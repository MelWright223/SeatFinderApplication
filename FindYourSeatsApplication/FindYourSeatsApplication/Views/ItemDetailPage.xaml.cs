using FindYourSeatsApplication.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FindYourSeatsApplication.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}