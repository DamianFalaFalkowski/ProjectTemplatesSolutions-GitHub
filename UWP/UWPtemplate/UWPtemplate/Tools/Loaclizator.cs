using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace $safeprojectname$.Tools
{
    // class to localize device position
    public static class Localizator
    {
        private const int OffsetInSeconds = 60;

        private static bool IsLocationServicesAllowed = true;

        private static bool isGeolocatorBusy { get; set; }

        private static DateTime lastUpdate = DateTime.MinValue;

        public static Geopoint Possition
        {
            get
            {
                return possition != null ?
                new Geopoint(possition.Coordinate.Point.Position) :
                new Geopoint(new BasicGeoposition() { Latitude = 0, Longitude = 0, Altitude = 0 });
            }
            private set { }
        }

        private static Geoposition possition { get; set; }

        public static async Task<Geoposition> GetPossition()
        {
            IsLocationServicesAllowed = await checkPermission();
            if (IsLocationServicesAllowed)
            {
                if (!isGeolocatorBusy)
                {
                    if (lastUpdate == DateTime.MinValue || lastUpdate - DateTime.Now > TimeSpan.FromSeconds(OffsetInSeconds))
                    {
                        await localize();
                    }
                    if (possition != null)
                    {
                        return possition;
                    }
                    return null;
                }
                else
                {
                    if (possition != null)
                    {
                        return possition;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        private static async Task localize()
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;
            try
            {
                isGeolocatorBusy = true;
                Geoposition geoposition = await geolocator.GetGeopositionAsync();
                possition = geoposition;
                isGeolocatorBusy = false;
                lastUpdate = DateTime.Now;
            }
            catch (Exception)
            {
                throw new NotImplementedException("geolocalizating failed");
            }
        }

        private static async Task<bool> checkPermission()
        {
            var status = await Geolocator.RequestAccessAsync();
            if (status == GeolocationAccessStatus.Allowed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
