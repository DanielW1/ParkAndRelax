using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
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
        Task <(double latitude, double longtitude)> GetLatitudeandLongtitude(string locationName);
        Task <List<Event>> GetAllEvents(string category);

    }
    public class GeoLocationService : IGeoLocationService
    {
        private List<Event> _events;
        private readonly HttpClient _httpClient = new HttpClient();
        public async Task<(double latitude, double longtitude)> GetLatitudeandLongtitude(string locationName)
        {
            double latitude;
            double longtitude;
            try
            {
                string basicurl = "https://maps.googleapis.com/maps/api/geocode/json";
                var response = await _httpClient.GetStringAsync("https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=AIzaSyAIek0_YxK1JGXqlAR7GTaXhjABmINIsNI");
                GeoCoderModel dataResult = JsonConvert.DeserializeObject<GeoCoderModel>(response);
                latitude = dataResult.results[0].geometry.location.lat;
                longtitude = dataResult.results[0].geometry.location.lng;
            }
              catch(Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e.Message);
                latitude = 0;
                longtitude = 0;
            }



            return (latitude, longtitude);
        }

        public async Task<List<Event>> GetAllEvents(string category)
        {
            try
            {
                string basicurl = "https://parkandriderest.azurewebsites.net/Events/search?category=";
                string url = basicurl + category;
                var response = await _httpClient.GetStringAsync(url);

                _events = JsonConvert.DeserializeObject<List<Event>>(response);

                    return _events;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return null;
        }


        
    }

   
}
