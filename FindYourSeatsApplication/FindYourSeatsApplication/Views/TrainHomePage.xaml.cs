using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FindYourSeatsApplication.Controller;

namespace FindYourSeatsApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainHomePage : ContentPage
    {
        dbConnection conn = new dbConnection();
     
        public TrainHomePage()
        {
            InitializeComponent();
            conn.connectDb();

            
        }
        
    }
}