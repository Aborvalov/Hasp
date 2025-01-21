using Logic;
using Model;
using System;
using ViewContract;

namespace Presenter
{
    public class LogPresenter
    {
        private readonly ILogView entitiesLogView;
        private readonly ILogModel logModel;

        private const string nullDB = "База данных не найдена.";

        public LogPresenter(ILogView entitiesLogView)
        {
            this.entitiesLogView = entitiesLogView ?? throw new ArgumentNullException(nameof(entitiesLogView));
            try
            {
                logModel = new LogModel(new Logics());
            }
            catch (ArgumentNullException)
            {
                entitiesLogView.MessageError(nullDB);
            }
            Display();
        }

        public void Display() => entitiesLogView.Bind(logModel.GetAll());
    }
}
