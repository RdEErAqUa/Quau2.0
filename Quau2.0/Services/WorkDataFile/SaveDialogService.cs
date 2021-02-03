using Microsoft.Win32;
using Quau2._0.Services.WorkDataFile.Interfaces;

namespace Quau2._0.Services.WorkDataFile
{
    internal class SaveDialogService : ISaveDialogService
    {
        public string FilePath { get; set; }

        public bool OpenFileDialog()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }

            return false;
        }
    }
}