using Logic;
using Model;
using ModelEntities;
using System;
using View;

namespace Presenter
{
    public class PresenterHaspKey : IPresenterHaspKey
    {
        private readonly IHaspKeyModel haspKeyModel;
        private readonly IEntitiesView<ModelViewHaspKey> entitesView;

        public PresenterHaspKey(IEntitiesView<ModelViewHaspKey> entitesView)
        {
            this.entitesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            haspKeyModel = new HaspKeyModel(new Logics());
            View();
        }

        public void Add(ModelViewHaspKey entity)
        {
            if (entity == null)
                entitesView.MessageError("Не удалось создать Hasp-ключ.");

            if (haspKeyModel.Add(entity))
                View();
            else
                entitesView.MessageError("Не удалось создать Hasp-ключ.");
        }

        public void GetByActive() => entitesView.Bind(haspKeyModel.GetByActive());

        public void GetByClient(ModelViewClient client)
        {
            if (client == null)
                entitesView.MessageError("Данный клиент имеет пустые значения.");

            entitesView.Bind(haspKeyModel.GetByClient(client));
        }

        public void GetByPastDue() => entitesView.Bind(haspKeyModel.GetByPastDue());

        public void Remove(int id)
        {
            if (id > 0 && haspKeyModel.Remove(id))
                View();
            else
                entitesView.MessageError("Не удалось удалить Hasp-ключ.");
        }

        public void Update(ModelViewHaspKey entity)
        {
            if (entity == null)
                entitesView.MessageError("Не удалось обновить Hasp-ключ.");

            if (haspKeyModel.Update(entity))
                View();
            else
                entitesView.MessageError("Не удалось обновить Hasp-ключ.");
        }

        public void View() => entitesView.Bind(haspKeyModel.GetAll());
    }
}
