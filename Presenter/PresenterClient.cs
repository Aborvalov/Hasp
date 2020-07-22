using Logic;
using Model;
using ModelEntities;
using System;
using System.Collections.Generic;
using ViewContract;

namespace Presenter
{
    public class PresenterClient : IPresenterReference
    {
        private readonly IClientModel clientModel;
        private readonly IEntitiesView<ModelViewClient> entitiesView;

        private const string errorAdd = "Не удалось создать клиента.";
        private const string errorUpdate = "Не удалось обновить клиента.";
        private const string errorDelete = "Не удалось удалить клиента.";
        private const string errorEmptyFeature = "Данноя функциональность пуста.";
        private const string errorInnerId = "Некорректный номер ключа.";
        private const string errorEmptyName = "\u2022 Не заполнено поля \"Наименование\", не должно быть пустым. \n";
        private const string errorEmptyAddress = "\u2022 Не заполнено поля \"Адрес\", не должно быть пустым. \n";
        private const string nullDB = "База данных не найдена.";

        public PresenterClient(IEntitiesView<ModelViewClient> entitesView)
        {
            this.entitiesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));
            
            try
            {
                clientModel = new ClientModel(new Logics());
            }
            catch (ArgumentNullException)
            {
                entitiesView.MessageError(nullDB);
            }            
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
              
        public void FillInputItem(ModelViewClient item)
        {
            Entities = item ?? throw new ArgumentNullException(nameof(item));
            entitiesView.BindItem(item);
        }
        public void FillModel(ModelViewClient item)
        {
            Entities = item ?? throw new ArgumentNullException(nameof(item));

            if (!CheckInputData())
                return;

            if (Entities.Id < 1)
                Add(Entities);
            else
                Update(Entities);
        }
        private bool CheckInputData()
        {
            string errorMess = string.Empty;
            if (string.IsNullOrWhiteSpace(Entities.Name))
                errorMess += errorEmptyName;
            if (string.IsNullOrWhiteSpace(Entities.Address))
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
