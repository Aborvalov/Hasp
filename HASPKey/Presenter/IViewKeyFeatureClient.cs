using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASPKey
{
    public interface IViewKeyFeatureClient
    {
        /// <summary>
        /// Вывод списка ключей-фич клиента.
        /// </summary>
        void View();
        /// <summary>
        /// Ввод нового значения.
        /// </summary>
        KeyFeatureClient ValueInput { get; }
        /// <summary>
        /// Событие ввода.
        /// </summary>
        event EventHandler<EventArgs> SetKeyFeatureClient;
    }
}
