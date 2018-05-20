using System.Collections.Generic;
using System.Threading.Tasks;
using Viewer.Models;
using Splat;
using Newtonsoft.Json;
using System.IO;

namespace Viewer.Services
{

    public interface IConvertingjsonService
    {
        Task<List<ParkRide>> GetAllParkings();
    }


    public class ConvertingJsonService : IConvertingjsonService
    {
        private List<ParkRide> _Parkings;
        private readonly IAssetReader _assetReader;
        private readonly string _filename;

        public async Task GetEvents(string filename)
        {
            var json = _assetReader.GetStreamFromAssets(filename);
            using (StreamReader streamReader = new StreamReader(json))
            {
                _Parkings = JsonConvert.DeserializeObject<List<ParkRide>>(await streamReader.ReadToEndAsync(), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
            }
        }

        public async Task<List<ParkRide>> GetAllParkings()
        {
            if (_Parkings == null)
            {
                await GetEvents(_filename);
            }
            return _Parkings;
        }
        public ConvertingJsonService(string filename)
        {
            _assetReader = Locator.Current.GetService<IAssetReader>();
            _filename = filename;
        }
    }
}