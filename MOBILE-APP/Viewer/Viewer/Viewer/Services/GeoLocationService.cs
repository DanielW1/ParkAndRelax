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
            
            try
            {
                string basicurl = "https://maps.googleapis.com/maps/api/geocode/json";
                var response = await _httpClient.GetStringAsync("https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=AIzaSyAkjyQKYUny2WPtnPpHRAyF6WOTbBrNMa0");
                var coordinates = JsonConvert.DeserializeObject<EventOnMapModel>(response);
            }
              catch(Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine("sdfffffffffffffffffffffffffffffffffffffdfsddsfssdsfdf");
            }
            double lat = 0;
            double lng = 0;


            return (lat,lng);
        }

        public async Task<List<Event>> GetAllEvents(string category)
        {
            try
            {
                string basicurl = "https://parkandriderest.azurewebsites.net/Events/search?category=";
                string url = basicurl + category;
                var response = await _httpClient.GetStringAsync(url);

               // Thread.Sleep(6000);
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
