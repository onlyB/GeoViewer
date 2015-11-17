using System.IO;
using System.Linq;

namespace GeoViewer.Utils
{
    public static class FileUtils
    {
        public static long CountTotalLines(string file)
        {
            return File.ReadLines(file).LongCount();
        }

        public static long CountTotalFolderLines(string folder)
        {
            return Directory.GetFiles(folder).Sum(file => File.ReadLines(file).LongCount());
        }

        public static long FolderSize(string folderPath)
        {
            var folder =new DirectoryInfo(folderPath);
            return folder.GetFiles().Sum(file => file.Length);
        }
    }
}
