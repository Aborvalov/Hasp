using Logic;
using Model;
using ModelEntities;
using System;
using System.Collections.Generic;
using View;

namespace Presenter
{
    public class PresenterClient : IPresenterClient
    {
        private readonly IClientModel clientModel;
        private readonly IEntitesView<ModelViewClient> entitesView;
        
        public PresenterClient(IEntitesView<ModelViewClient> entitesView)
        {
            this.entitesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            clientModel = new ClientModel(new Logics());
            View();
        }
        public void Add(ModelViewClient entity)
        {
            if (entity == null)
                this.entitesView.MessageError("Не удалось создать клиента.");

            if (clientModel.Add(entity))
                View();
            else
                this.entitesView.MessageError("Не удалось создать клиента.");
        }

        public void GetByFeature(ModelViewFeature feature)
        {
            if (feature == null)
                this.entitesView.MessageError("Данноя функциональность пуста.");

            entitesView.Build(clientModel.GetByFeature(feature));
        }

        public void GetByNumberKey(int keyInnerId)
        {
            var client = clientModel.GetByNumberKey(keyInnerId);
            if (client == null)
            {
                entitesView.Build(new List<ModelViewClient>());
                return;
            }
            var clients = new List<ModelViewClient>
            {
                client
            };
            entitesView.Build(clients);
        }

        public void Remove(int id)
        {
            if (id > 0 && clientModel.Remove(id))
                View();
            else
                this.entitesView.MessageError("Не удалось удалить клиента.");
        }

        public void Update(ModelViewClient entity)
        {
            if (entity == null)
                this.entitesView.MessageError("Не удалось обновить клиента.");

            if (clientModel.Update(entity))
                View();
            else
                this.entitesView.MessageError("Не удалось обновить клиента.");
        }

        public void View() => this.entitesView.Build(clientModel.GetAll());
    }
}
