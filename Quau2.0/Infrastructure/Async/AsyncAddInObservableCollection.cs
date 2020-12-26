using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Infrastructure.Async
{
    public static class AsyncAddInObservableCollection
    {
        /// <summary>
        /// Добавление в коллекцию данных на потоке UI.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="observableCollection"></param>
        /// <param name="value"></param>
        public static void Add<T>(ObservableCollection<T> observableCollection, T value)
        {
            App.Current.Dispatcher.BeginInvoke((Action)delegate ()
            {
                observableCollection.Add(value);
            });
        }
    }
}
