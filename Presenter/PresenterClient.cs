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
        private readonly IClientView entitiesView;

        private const string errorAdd = "Не удалось создать клиента.";
        private const string errorUpdate = "Не удалось обновить клиента.";
        private const string errorDelete = "Не удалось удалить клиента.";
        private const string errorEmptyFeature = "Данноя функциональность пуста.";
        private const string errorInnerId = "Некорректный номер ключа.";
        private const string errorEmptyName = "\u2022 Не заполнено поля \"Наименование\", не должно быть пустым. \n";
        private const string errorEmptyAddress = "\u2022 Не заполнено поля \"Адрес\", не должно быть пустым. \n";

        public PresenterClient(IClientView entitesView)
        {
            this.entitiesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            clientModel = new ClientModel(new Logics());
            Display();
        }

        public ModelViewClient Entities { get; set; } = null;

        public void Add(ModelViewClient entity)
        {
            if (entity == null)
            { 
                entitiesView.MessageError(errorAdd);
                return;
            }

            if (clientModel.Add(entity))
            {
                entitiesView.DataChange();
                Display();
            }
            else
                entitiesView.MessageError(errorAdd);
        }

        public void GetByFeature(ModelViewFeature feature)
        {
            if (feature == null)
            {
                entitiesView.MessageError(errorEmptyFeature);
                return;
            }
            entitiesView.Bind(clientModel.GetByFeature(feature));
        }

        public void GetByNumberKey(int keyInnerId)
        {
            if (keyInnerId < 1)
            {
                entitiesView.MessageError(errorInnerId);
                return;
            }
            var client = clientModel.GetByNumberKey(keyInnerId);
            if (client == null)
            {
                entitiesView.Bind(new List<ModelViewClient>());
                return;
            }
            var clients = new List<ModelViewClient>
            {
                client
            };
            entitiesView.Bind(clients);
        }

        public void Remove(int id)
        {
            if (id > 0 && clientModel.Remove(id))
            {
                entitiesView.DataChange();
                Display();
            }
            else
                entitiesView.MessageError(errorDelete);
        }

        public void Update(ModelViewClient entity)
        {
            if (entity == null)
            {
                entitiesView.MessageError(errorUpdate);
                return;
            }

            if (clientModel.Update(entity))
            {
                entitiesView.DataChange();
                Display();
            }
            else
                entitiesView.MessageError(errorUpdate);
        }

        public void Display() => entitiesView.Bind(clientModel.GetAll());
        public void Dispose() => clientModel.Dispose();
              
        public void FillInputItem(ModelViewClient row)
        {
            if (row == null)
                return;

            Entities = new ModelViewClient
            {
                Id = row.Id
            };
            entitiesView.NameClient = row.Name;
            entitiesView.Address = row.Address;
            entitiesView.ContactPerson = row.ContactPerson;
            entitiesView.Phone = row.Phone;
        }
        public void FillModel()
        {
            if (!CheckInputData())
                return;

            Entities.Name = entitiesView.NameClient;
            Entities.Address = entitiesView.Address;
            Entities.Phone = entitiesView.Phone;
            Entities.ContactPerson = entitiesView.ContactPerson;

            if (Entities.Id < 1)
                Add(Entities);
            else
                Update(Entities);
        }
        private bool CheckInputData()
        {
            string errorMess = string.Empty;
            if (string.IsNullOrWhiteSpace(entitiesView.NameClient))
                errorMess += errorEmptyName;
            if (string.IsNullOrWhiteSpace(entitiesView.Address))
                errorMess += errorEmptyAddress;

            if (errorMess != string.Empty)
            {
                entitiesView.MessageError(errorMess.Trim());
                return false;
            }

            return true;
        }
    }
}
