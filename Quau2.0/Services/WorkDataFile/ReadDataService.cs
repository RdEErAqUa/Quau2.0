using Quau2._0.Services.WorkDataFile.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.WorkDataFile
{
    class ReadDataService : IReadDataService
    {
        public string ReadData(String PATH)
        {
            if (File.Exists(PATH))
            {
                using (StreamReader reader = new StreamReader(PATH))
                {
                    return reader.ReadToEnd();
                }
            }
            else
                return null;
        }
    }
}
