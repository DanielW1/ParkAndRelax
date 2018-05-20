using System.IO;

namespace Viewer.Services
{
    public interface IAssetReader
    {
        Stream GetStreamFromAssets(string filename);
    }
}