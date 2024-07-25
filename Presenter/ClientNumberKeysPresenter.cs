using Logic;
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
        private readonly IClientNumberKeysView entitiesclnkView;
        private readonly IClientNumberKeysModel clientNumberKeysModel;
        private const string nullDB = "База данных не найдена.";
        private const string errorUpdate = "Не удалось обновить клиента.";
        private const string errorDelete = "Не удалось удалить клиента.";
        private const string errorEmptyName = "\u2022 Не заполнено поля \"Наименование\", не должно быть пустым. \n";
        private const string errorAdd = "Не удалось создать клиента.";

        public ClientNumberKeysPresenter(IClientNumberKeysView entitiesclnkView)
        {
            this.entitiesclnkView = entitiesclnkView ?? throw new ArgumentNullException(nameof(entitiesclnkView));
            try
            {
                clientNumberKeysModel = new ClientNumberKeysModel(new Logics());
            }
            catch (ArgumentNullException)
            {
                entitiesclnkView.MessageError(nullDB);
            }
            Display();
        }

        public ModelViewClientNumberKeys Entities { set; get; } = null;

        public void Display() => entitiesclnkView.Bind(clientNumberKeysModel.NumberKeys());

        public void Dispose() => clientNumberKeysModel.Dispose();

        public void Edit(List<ModelViewClientNumberKeys> keyClient)
        {
            if (keyClient == null)
                throw new ArgumentNullException(nameof(keyClient));

            Delete(keyClient);
            Display();
            
            Add(keyClient);
            Display();

            Update(keyClient);
            Display();

            entitiesclnkView.DataChange();
        }

        public void Update(ModelViewClientNumberKeys entity)
        {
            if (entity == null)
            {
                entitiesclnkView.MessageError(errorUpdate);
                return;
            }
            if (clientNumberKeysModel.Update(entity)) 
            {
                entitiesclnkView.DataChange();
                Display();
            }
            else
                entitiesclnkView.MessageError(errorUpdate);
        }

        public void Update(List<ModelViewClientNumberKeys> keyClient)
        {
            var update = keyClient
                            .Where(x => x.Id != 0 &&
                                        !string.IsNullOrEmpty(x.Name) &&
                                        x.NumberKeys != -1);
            if (update.Any())
            {
                clientNumberKeysModel.Update(update, out string error);
                if (!string.IsNullOrEmpty(error))
                    entitiesclnkView.MessageError(error);
            }
        }

        public void Add(List<ModelViewClientNumberKeys> keyClient)
        {
            var add = keyClient
                        .Where(x => x.Id != 0 &&
                                    !string.IsNullOrEmpty(x.Name) &&
                                    x.NumberKeys == -1 && x.NumberFeatures == -1);
            if (add.Any())
            {
                clientNumberKeysModel.Add(add, out string error);
                if (!string.IsNullOrEmpty(error))
                    entitiesclnkView.MessageError(error);
            }
        }

        public void Delete(List<ModelViewClientNumberKeys> keyClient)
        {
            var delete = keyClient
                            .Where(x => x.Id != 0 && x.NumberKeys != -1);
            if (delete.Any())
            {
                clientNumberKeysModel.Remove(delete, out string error);
                if (!string.IsNullOrEmpty(error))
                    entitiesclnkView.MessageError(error);
            }
        }

        public void Remove(int id)
        {
            if (id > 0 && clientNumberKeysModel.Remove(id))
            {
                entitiesclnkView.DataChange();
                Display();
            }
            else
                entitiesclnkView.MessageError(errorDelete);
        }

        public bool CheckInputData()
        {
            string errorMess = String.Empty;
            if (string.IsNullOrWhiteSpace(Entities.Name))
                errorMess += errorEmptyName;
            if (errorMess != string.Empty)
            {
                entitiesclnkView.MessageError(errorMess.Trim());
                return false;
            }
            return true;
        }

        public void FillInputItem(ModelViewClientNumberKeys item)
        {
            Entities = item ?? throw new ArgumentNullException(nameof(item));
            entitiesclnkView.BindItem(item);
        }

        public void FillModel(ModelViewClientNumberKeys item)
        {
            Entities = item ?? throw new ArgumentNullException(nameof(item));
            if (!CheckInputData())
                return;
            if (Entities.Id < 1)
                Add(Entities);
            else
                Update(Entities);
        }

        public void Add(ModelViewClientNumberKeys entity)
        {
            if (entity == null)
            {
                entitiesclnkView.MessageError(errorAdd);
                return;
            }

            if (clientNumberKeysModel.Add(entity))
            {
                entitiesclnkView.DataChange();
                Display();
            }
            else
                entitiesclnkView.MessageError(errorAdd);
        }

        public bool CheckInputData(List<ModelViewClientNumberKeys> item)
        {
            string errorMess = string.Empty;

            if (string.IsNullOrWhiteSpace(item.ToString()))
                errorMess += errorEmptyName;

            if (errorMess != string.Empty)
            {
                entitiesclnkView.MessageError(errorMess.Trim());
                return false;
            }
            return true;
        }
    }
}
