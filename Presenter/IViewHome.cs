using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public interface IViewHome
    {
        /// <summary>
        /// Вывод списка ключей-фич клиента.
        /// </summary>
        void View();
        /// <summary>
        /// Ввод нового значения.
        /// </summary>
        HomeView ValueInput { get; }
        /// <summary>
        /// Событие ввода.
        /// </summary>
        event EventHandler<EventArgs> SetKeyFeatureClient;

    }
}
