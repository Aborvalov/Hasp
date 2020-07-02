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
        private readonly IEntitesView<ModelViewHaspKey> entitesView;

        public PresenterHaspKey(IEntitesView<ModelViewHaspKey> entitesView)
        {
            this.entitesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            haspKeyModel = new HaspKeyModel(new Logics());
            View();
        }

        public void Add(ModelViewHaspKey entity)
        {
            if (entity == null)
                this.entitesView.MessageError("Не удалось создать Hasp-ключ.");

            if (haspKeyModel.Add(entity))
                View();
            else
                this.entitesView.MessageError("Не удалось создать Hasp-ключ.");
        }

        public void GetByActive() => this.entitesView.Build(haspKeyModel.GetByActive());

        public void GetByClient(ModelViewClient client)
        {
            if (client == null)
                this.entitesView.MessageError("Данный клиент имеет пустые значения.");

            entitesView.Build(haspKeyModel.GetByClient(client));
        }

        public void GetByPastDue() => this.entitesView.Build(haspKeyModel.GetByPastDue());

        public void Remove(int id)
        {
            if (id > 0 && haspKeyModel.Remove(id))
                View();
            else
                this.entitesView.MessageError("Не удалось удалить Hasp-ключ.");
        }

        public void Update(ModelViewHaspKey entity)
        {
            if (entity == null)
                this.entitesView.MessageError("Не удалось обновить Hasp-ключ.");

            if (haspKeyModel.Update(entity))
                View();
            else
                this.entitesView.MessageError("Не удалось обновить Hasp-ключ.");
        }

        public void View() => this.entitesView.Build(haspKeyModel.GetAll());
    }
}
