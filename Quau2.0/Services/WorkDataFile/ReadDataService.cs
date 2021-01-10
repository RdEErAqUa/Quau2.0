using System.IO;
using Quau2._0.Services.WorkDataFile.Interfaces;

namespace Quau2._0.Services.WorkDataFile
{
    internal class ReadDataService : IReadDataService
    {
        public string ReadData(string PATH)
        {
            if (File.Exists(PATH))
                using (var reader = new StreamReader(PATH))
                {
                    return reader.ReadToEnd();
                }

            return null;
        }
    }
}