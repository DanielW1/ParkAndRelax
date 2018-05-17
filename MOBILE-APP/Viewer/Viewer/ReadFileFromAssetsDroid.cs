using System.IO;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Viewer.Services;

namespace Viewer.Droid.Helpers
{
    class ReadFileFromAssetsDroid : IAssetReader
    {
        private readonly Context _context;

        public ReadFileFromAssetsDroid()
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