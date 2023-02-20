using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FindYourSeatsApplication.Controller;
using FindYourSeatsApplication.Models;

namespace FindYourSeatsApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainHomePage : ContentPage
    {
        databaseConn conn = new databaseConn();
        StationData data = new StationData();
        degreeConverter con = new degreeConverter();
        AppShell shell = new AppShell();
     
        public TrainHomePage()
        {
            InitializeComponent();
            // conn.DatabaseConn();
           var StationName = data.StationName = "Par";
           var StationLat = data.StationLat = 50.3560;
           var StationLong = data.StationLong = -4.7044;
           // var stationLat = con.calcDegrees(data.StationLat);
           // var stationLong = con.calcDegrees(data.StationLong);

          // var userLoc = shell.GetCurrentLocation();

            int deg = con.calcDegrees(StationLat);
            var min = con.CalMinutes(StationLat, deg);
            Console.WriteLine("Par Degrees Lat - " + deg);
            Console.WriteLine("Par MInutes Lat - " + min);


           // var getUserDeg = con.calcDegrees();
            





        }

    }
}