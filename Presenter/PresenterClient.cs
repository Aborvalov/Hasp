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
        private readonly IEntitiesView<ModelViewClient> entitшesView;

        private const string errorAdd = "Не удалось создать клиента.";
        private const string errorUpdate = "Не удалось обновить клиента.";
        private const string errorDelete = "Не удалось удалить клиента.";
        private const string errorEmptyFeature = "Данноя функциональность пуста.";

        public PresenterClient(IEntitiesView<ModelViewClient> entitesView)
        {
            this.entitшesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            clientModel = new ClientModel(new Logics());
            Display();
        }

        public ModelViewClient Entities { get; set; } = null;

        public void Add(ModelViewClient entity)
        {
            if (entity == null)
                entitшesView.MessageError(errorAdd);

            if (clientModel.Add(entity))
                Display();
            else
                entitшesView.MessageError(errorAdd);
        }

        public void GetByFeature(ModelViewFeature feature)
        {
            if (feature == null)
                entitшesView.MessageError(errorEmptyFeature);

            entitшesView.Bind(clientModel.GetByFeature(feature));
        }

        public void GetByNumberKey(int keyInnerId)
        {
            var client = clientModel.GetByNumberKey(keyInnerId);
            if (client == null)
            {
                entitшesView.Bind(new List<ModelViewClient>());
                return;
            }
            var clients = new List<ModelViewClient>
            {
                client
            };
            entitшesView.Bind(clients);
        }

        public void Remove(int id)
        {
            if (id > 0 && clientModel.Remove(id))
                Display();
            else
                entitшesView.MessageError(errorDelete);
        }

        public void Update(ModelViewClient entity)
        {
            if (entity == null)
                entitшesView.MessageError(errorUpdate);

            if (clientModel.Update(entity))
                Display();
            else
                entitшesView.MessageError(errorUpdate);
        }

        public void Display() => entitшesView.Bind(clientModel.GetAll());

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
