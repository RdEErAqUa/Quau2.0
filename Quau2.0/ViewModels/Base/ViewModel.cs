using Quau2._0.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.ViewModels.Base
{
    /// <summary>
    /// Класс, реализирующий интерфейс INotifyPropertyChanged. Реализация скрытая в NotifyChanged.
    /// Созданный, для переопределения методов и поле для их дальнейшего использования во всех ViewModel.
    /// </summary>
    internal abstract class ViewModel : NotifyChanged
    {
        /// <summary>
        /// 
        /// </summary>
    }
}
