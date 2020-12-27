using Quau2._0.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Infrastructure.Commands.Base.NotifyChangedBaseCommand
{
    /// <summary>
    /// Класс, реализирующий интерфейс INotifyPropertyChanged. Реализация скрытая в NotifyChanged.
    /// Созданный, для переопределения методов и поле для их дальнейшего использования во всех Model.
    /// </summary>
    internal abstract class NotifyChangedCommand : NotifyChanged
    {
        /// <summary>
        /// 
        /// </summary>
    }
}
