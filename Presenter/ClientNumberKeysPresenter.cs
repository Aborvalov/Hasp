﻿using Logic;
using Model;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewContract;


namespace Presenter
{
    public class ClientNumberKeysPresenter : IClientNumberKeysPresenter
    {
        private readonly IClientNumberKeysView entitiesClientNumberKeysView;
        private readonly IClientModel clientNumberKeysModel;

        private const string nullDB = "База данных не найдена.";
        private const string errorUpdate = "Не удалось обновить клиента.";
        private const string errorDelete = "Не удалось удалить клиента.";
        private const string errorEmptyName = "\u2022 Не заполнено поля \"Наименование\", не должно быть пустым. \n";
        private const string errorAdd = "Не удалось создать клиента.";
        private const string errorEmptyId = "Данный id пустой.";

        public ClientNumberKeysPresenter(IClientNumberKeysView entitiesClientNumberKeysView)
        {
            this.entitiesClientNumberKeysView = entitiesClientNumberKeysView ?? throw new ArgumentNullException(nameof(entitiesClientNumberKeysView));
            try
            {
                clientNumberKeysModel = new ClientModel(new Logics());
            }
            catch (ArgumentNullException)
            {
                entitiesClientNumberKeysView.MessageError(nullDB);
            }
            Display();
        }

        public ModelViewClient Entities { set; get; } = null;

        public void Display() => entitiesClientNumberKeysView.Bind(clientNumberKeysModel.GetNumberOfKeysAndFeatures());

        public void Dispose() => clientNumberKeysModel.Dispose();

        public void Edit(List<ModelViewClient> keyClient)
        {
            if (keyClient == null)
                throw new ArgumentNullException(nameof(keyClient));

            Delete(keyClient);
            Add(keyClient);
            Update(keyClient);

            Display();

            entitiesClientNumberKeysView.DataChange();
        }

        public void Update(ModelViewClient entity)
        {
            if (entity == null)
            {
                entitiesClientNumberKeysView.MessageError(errorUpdate);
                return;
            }
            if (clientNumberKeysModel.Update(entity)) 
            {
                entitiesClientNumberKeysView.DataChange();
                Display();
            }
            else
                entitiesClientNumberKeysView.MessageError(errorUpdate);
        }

        public void Update(List<ModelViewClient> keyClient)
        {
            if (keyClient == null)
            {
                throw new ArgumentException(nameof(keyClient));
            }
  
            var update = keyClient.Where(x => x.Id > 0 && !string.IsNullOrEmpty(x.Name));
            if (update.Any())
            {
                clientNumberKeysModel.Update(update, out string error);
                if (!string.IsNullOrEmpty(error))
                    entitiesClientNumberKeysView.MessageError(error);
            }
        }

        public void Add(List<ModelViewClient> keyClient)
        {
            if (keyClient == null)
            {
                throw new ArgumentException(nameof(keyClient));
            }
            var add = keyClient
                        .Where(x => x.Id == -1 && !string.IsNullOrEmpty(x.Name));
            if (add.Any())
            {
                clientNumberKeysModel.Add(add, out string error);
                if (!string.IsNullOrEmpty(error))
                    entitiesClientNumberKeysView.MessageError(error);
            }
        }

        public void Delete(List<ModelViewClient> keyClient)
        {
            if (keyClient == null)
            {
                throw new ArgumentException(nameof(keyClient));
            }
            var delete = keyClient.Where(x => x.Id > 0);
            if (delete.Any())
            {
                clientNumberKeysModel.Remove(delete, out string error);
                if (!string.IsNullOrEmpty(error))
                    entitiesClientNumberKeysView.MessageError(error);
            }
        }

        public void Remove(int id)
        {
            if (id > 0 && clientNumberKeysModel.Remove(id))
            {
                entitiesClientNumberKeysView.DataChange();
                Display();
            }
            else
                entitiesClientNumberKeysView.MessageError(errorDelete);
        }

        public bool CheckInputData()
        {
            string errorMess = string.Empty;
            if (string.IsNullOrWhiteSpace(Entities.Name))
                errorMess += errorEmptyName;
            if (errorMess != string.Empty)
            {
                entitiesClientNumberKeysView.MessageError(errorMess.Trim());
                return false;
            }
            return true;
        }

        public void FillInputItem(ModelViewClient item)
        {
            Entities = item ?? throw new ArgumentNullException(nameof(item));
            entitiesClientNumberKeysView.BindItem(item);
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

        public void Add(ModelViewClient entity)
        {
            if (entity == null)
            {
                entitiesClientNumberKeysView.MessageError(errorAdd);
                return;
            }

            if (clientNumberKeysModel.Add(entity))
            {
                entitiesClientNumberKeysView.DataChange();
                Display();
            }
            else
                entitiesClientNumberKeysView.MessageError(errorAdd);
        }

        public bool CheckInputData(List<ModelViewClient> item)
        {
            string errorMess = string.Empty;

            if (string.IsNullOrWhiteSpace(item.ToString()))
                errorMess += errorEmptyName;

            if (errorMess != string.Empty)
            {
                entitiesClientNumberKeysView.MessageError(errorMess.Trim());
                return false;
            }
            return true;
        }

        public void GetByFeature(int id)
        {
            if (id <= 0)
            {
                entitiesClientNumberKeysView.MessageError(errorEmptyId);
                return;
            }
            entitiesClientNumberKeysView.Bind(clientNumberKeysModel.GetByFeature(id));
        }

        public void GetByInnerId(int id) 
        {
            if (id <= 0)
            {
                entitiesClientNumberKeysView.MessageError(errorEmptyId);
                return;
            }
            entitiesClientNumberKeysView.Bind(clientNumberKeysModel.GetByInnerId(id));
        }
    }
}
