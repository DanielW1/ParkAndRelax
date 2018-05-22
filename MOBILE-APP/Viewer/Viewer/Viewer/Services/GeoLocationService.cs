using System.Threading.Tasks;
using Flurl;
using Flurl.Util;
using Newtonsoft.Json;
using Splat;
using Viewer.Models;

namespace Viewer.Services
{
    public interface IGeoLocationService
    {
        Task<(double latitude, double longtitude)> GetLatitudeandLongtitude(string locationName);
    }
    public class GeoLocationService : IGeoLocationService
    {
        private readonly IRequestService _requestService = Locator.CurrentMutable.GetService<IRequestService>();
        public async Task<(double latitude, double longtitude)> GetLatitudeandLongtitude(string locationName)
        {
            double latitude = 0;
            double longtitude = 0;

            var requestUrl = GetGeoLocatorRequestUrl(locationName);
            var jsonResponse = await _requestService.HttpRequest(requestUrl);
            var coordinates = JsonConvert.DeserializeObject<EventOnMapModel>(jsonResponse);
            return(coordinates.Latitude, coordinates.Longtitude);
        }


        private static string GetGeoLocatorRequestUrl(string locationName)
        {
            var requestUrl = new Url("https://maps.googleapis.com/maps/api/geocode/json").SetQueryParams(new
            {
                address = "Toledo",
                region = "pl",
                key = "AIzaSyAkjyQKYUny2WPtnPpHRAyF6WOTbBrNMa0"
            });
            return requestUrl;
        }
    }

   
}
