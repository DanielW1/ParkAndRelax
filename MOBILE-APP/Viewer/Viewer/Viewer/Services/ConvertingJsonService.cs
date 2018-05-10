using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Viewer.Models;
using Viewer.Services;
using Splat;
using ReactiveUI;
using Newtonsoft.Json;
using System.IO;

namespace Viewer.Services
{

    public interface IConvertingjsonService
    {
        Task<List<Event>> ConvertAllEvents();
    }


    public class ConvertingJsonService: IConvertingjsonService
    {
        public List<Event> _EventList;
        private readonly IAssetReader assetReader = Locator.Current.GetService<IAssetReader>();

        public async Task GetEvents(string path)
        {
            var json = assetReader.GetStreamFromAssets("sfsf");
            using (StreamReader streamReader = new StreamReader(json))
            {
                _EventList = JsonConvert.DeserializeObject<List<Event>>(await streamReader.ReadToEndAsync(), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
            }
        }

        public async Task<List<Event>> ConvertAllEvents()
        {
            if(_EventList == null)
            {
                await GetEvents("sdfsdfsd");
            }
            return _EventList;
        }
        public ConvertingJsonService()
        {

        }
    }
}
