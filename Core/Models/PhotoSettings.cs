using System.IO;
using System.Linq;

namespace Stamps.Core.Models
{
    public class PhotoSettings
    {
        public int MaxFileSize { get; set; }
        public string[] AcceptedFileTypes { get; set; }

        public bool IsFileTypeAccepted(string fileName) {
            return AcceptedFileTypes.Any(
                f => f == Path.GetExtension(fileName).ToLower());
        }
    }
}