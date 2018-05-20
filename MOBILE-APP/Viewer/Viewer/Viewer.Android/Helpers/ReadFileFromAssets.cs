using System.IO;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Viewer.Services;

namespace Viewer.Droid.Helpers
{
    class ReadFileFromAssets : IAssetReader
    {
        private readonly Context _context;

        public ReadFileFromAssets()
        {
            _context = Application.Context;
        }

        public Stream GetStreamFromAssets(string filename)
        {
            AssetManager assetManager = _context.Assets;
            return assetManager.Open(filename);
        }
    }
}