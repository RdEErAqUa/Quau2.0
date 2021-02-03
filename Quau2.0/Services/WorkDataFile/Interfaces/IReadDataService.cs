namespace Quau2._0.Services.WorkDataFile.Interfaces
{
    internal interface IReadDataService
    {
        /// <summary>
        ///     Класс считывает данные из файла по пути PATH как строку.
        /// </summary>
        string ReadData(string PATH);
    }
}