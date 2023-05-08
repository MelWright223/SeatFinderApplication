using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FindYourSeatsApplication.Controller;
using FindYourSeatsApplication.Models;
using Xamarin.Essentials;
using System.Threading;
using System.Net.Http;
using Newtonsoft.Json;

namespace FindYourSeatsApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainHomePage : ContentPage
    {
       //dbConnection conn = new dbConnection();
        StationData data = new StationData();
        degreeConverter con = new degreeConverter();
        AppShell shell = new AppShell();
        private string SearchStation;
        static readonly HttpClient client = new HttpClient();
        private int StationId;
        private string StationName;
        private int MaxCarriages;
        private double StationLat;
        private double StationLong;
        private List<StationData> stationData = new List<StationData>();
        private ObservableCollection<StationData> _station;
        private ObservableCollection<JourneyData> _journey;
        private List<JourneyData> journeyData = new List<JourneyData>();

        private string getStationName;
        private int getPlatformNumber;
        public string GetStationName
        {
            get { return getStationName; }
            set { getStationName = value;
                OnPropertyChanged(nameof(GetStationName));
            }
        }

        public int GetPlatformNumber
        {
            get { return getPlatformNumber; }
            set
            {
                getPlatformNumber = value;
                OnPropertyChanged(nameof(GetPlatformNumber));
            }
        }


        public TrainHomePage()
        {
            InitializeComponent();

            //var loc = Compare();

            // GetStations();
           
            

            _station = new ObservableCollection<StationData>();
            _journey = new ObservableCollection<JourneyData>();
            GetData();
            

            //client = new HttpClient();
            Title = "Train HomePage";
         
        }
        




        //GetStationName = response;

        //}
        public string RemoveHTMLTags(string str)
        {
            System.Text.RegularExpressions.Regex rx =
            new System.Text.RegularExpressions.Regex("/<[^>]*> /g");
           rx.Replace(str, "");
            
            return str;
        }
        public ObservableCollection<StationData> Stations
        {
            get { return _station; }
            set { _station = value; }
            
        }
        public ObservableCollection<JourneyData> Journeys
        {
            get { return _journey; }
            set { _journey = value; }
        }
        public async Task<int> GetData()
        {
            var getCurrentLat = await getLat();
            var getCurrentLong = await getLong();
           // var getDeg = await getLatMin();
           // int Longdeg;
           // int LatDeg;
            int CurrentLatDeg;
            int LongMin;
            int LatMin;
            int currentLongMin;
            int currentLatMin;


            HttpResponseMessage message = await client.GetAsync("http://192.168.1.127:44326/api/Station");
            
            Console.WriteLine(message.Content.ReadAsStringAsync());
            stationData = JsonConvert.DeserializeObject<List<StationData>>(await message.Content.ReadAsStringAsync());
            Location currentLoc = new Location(getCurrentLat, getCurrentLong);
            //string responseBody = await message.Content.ReadAsStringAsync();
            if (message.IsSuccessStatusCode)
            {


                Console.WriteLine(stationData);
                foreach(StationData station in stationData)
                { 
                    Stations.Add(station);
                  

                   Location _station = new Location(station.StationLat,station.StationLong);
                    double distance = Location.CalculateDistance(currentLoc, _station, DistanceUnits.Miles);
                    Console.WriteLine(distance);
                    
                   if (distance < 3)
                   {

                      BindingContext = this;
                      GetStationName = station.StationName;
                      Console.WriteLine(station.StationName);
                        getJourneys(station.StationID);
                        return station.StationID;

                       
                   }
                   
                }

               
            }
            return StationId;
            
        }
        public async void getJourneys(int stationID)
        {
            
            HttpResponseMessage message = await client.GetAsync("http://192.168.1.127:44326/api/Station/JourneyID?stationId=" + stationID);

            Console.WriteLine(message.Content.ReadAsStringAsync());
            if (message.IsSuccessStatusCode)
            {
                journeyData = JsonConvert.DeserializeObject<List<JourneyData>>(await message.Content.ReadAsStringAsync());

                foreach (JourneyData journey in journeyData)
                {
                    Journeys.Add(journey);

                    //Console.WriteLine(journey.JourneyID);
                    if (journey.DestinationID == stationID)
                    {
                        BindingContext = this;
                        GetPlatformNumber = journey.PlatformNumber;
                    }

                }

            }                                       
            ;
        }
      
    
        public async Task<Location> GetCurrentLocation()
        {


            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(5));
            CancellationTokenSource cts = new CancellationTokenSource();
            var location = await Geolocation.GetLocationAsync(request, cts.Token);

            return (location);

        }
       
       
        public async Task<double> getLat()
        {
            var location =  await shell.GetCurrentLocation();
            Console.WriteLine(location);
            
            var latDeg = location.Latitude;
            Console.WriteLine(latDeg);
            return latDeg;
        }
        public async Task<double> getLong()
        {
           
                var location = await shell.GetCurrentLocation();
                Console.WriteLine(location);

                var longDeg = location.Longitude;
                Console.WriteLine( longDeg);
                return longDeg;
            
        }
        
    }
}