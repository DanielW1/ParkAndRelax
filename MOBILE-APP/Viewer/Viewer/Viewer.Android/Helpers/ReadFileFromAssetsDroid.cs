using System.IO;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Viewer.Services;

namespace Viewer.Droid.Helpers
{
    class ReadFileFromAssetsDroid: IAssetReader
    {
        private readonly Context _context;

        public ReadFileFromAssetsDroid()
        {
            _context = Application.Context;
        }
        public Stream GetStream(string filename)
        {
            AssetManager assetManager = _context.Assets;
            return assetManager.Open(filename);
        }

        public Stream GetStreamFromAssets(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}