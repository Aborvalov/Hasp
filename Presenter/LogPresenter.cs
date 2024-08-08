using Logic;
using Model;
using ModelEntities;
using System;
using System.Collections.Generic;
using ViewContract;

namespace Presenter
{
    public class LogPresenter : ILogPresenter
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
