using FindYourSeatsApplication.ViewModels;
using FindYourSeatsApplication.Views;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using FindYourSeatsApplication.Controller;

namespace FindYourSeatsApplication
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            GetCurrentLocation();    
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//HomePage");
        }
        public async Task GetCurrentLocation()
        {
            degreeConverter getDeg = new degreeConverter();
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                getDeg.calcDegrees(location.Longitude);
                getDeg.calcDegrees(location.Latitude);
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

    }
}
