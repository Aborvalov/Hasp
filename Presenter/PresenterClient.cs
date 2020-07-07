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
        private readonly IEntitiesView<ModelViewClient> entitesView;
        
        public PresenterClient(IEntitiesView<ModelViewClient> entitesView)
        {
            this.entitesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            clientModel = new ClientModel(new Logics());
            View();
        }

        public ModelViewClient Entities { get; set; } = null;

        public void Add(ModelViewClient entity)
        {
            if (entity == null)
                entitesView.MessageError("Не удалось создать клиента.");

            if (clientModel.Add(entity))
                View();
            else
                entitesView.MessageError("Не удалось создать клиента.");
        }

        public void GetByFeature(ModelViewFeature feature)
        {
            if (feature == null)
                entitesView.MessageError("Данноя функциональность пуста.");

            entitesView.Bind(clientModel.GetByFeature(feature));
        }

        public void GetByNumberKey(int keyInnerId)
        {
            var client = clientModel.GetByNumberKey(keyInnerId);
            if (client == null)
            {
                entitesView.Bind(new List<ModelViewClient>());
                return;
            }
            var clients = new List<ModelViewClient>
            {
                client
            };
            entitesView.Bind(clients);
        }

        public void Remove(int id)
        {
            if (id > 0 && clientModel.Remove(id))
                View();
            else
                entitesView.MessageError("Не удалось удалить клиента.");
        }

        public void Update(ModelViewClient entity)
        {
            if (entity == null)
                entitesView.MessageError("Не удалось обновить клиента.");

            if (clientModel.Update(entity))
                View();
            else
                entitesView.MessageError("Не удалось обновить клиента.");
        }

        public void View() => entitesView.Bind(clientModel.GetAll());
    }
}
