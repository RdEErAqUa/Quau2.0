namespace Quau2._0.Services.WorkDataFile.Interfaces
{
    internal interface ISaveDialogService
    {
        /// <summary>
        ///     Путь к файлу, который пользователь выбрал в диалоговом окне.
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        ///     Открывает диалоговое окно для выбора пути к файлу.
        /// </summary>
        bool OpenFileDialog();
    }
}