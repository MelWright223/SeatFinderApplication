using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FindYourSeatsApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppHomePage : ContentPage
    {
        public AppHomePage()
        {
            InitializeComponent();
        }
        async void OnButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new TrainHomePage());
        }
    }
}