using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Quau2._0.Infrastructure.Async
{
    public static class AsyncAddInObservableCollection
    {
        /// <summary>
        ///     Добавление в коллекцию данных на потоке UI.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="observableCollection"></param>
        /// <param name="value"></param>
        public static void Add<T>(ObservableCollection<T> observableCollection, T value)
        {
            Application.Current.Dispatcher.BeginInvoke((Action) delegate { observableCollection.Add(value); });
        }
    }
}