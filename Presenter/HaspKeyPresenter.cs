using Logic;
using Model;
using ModelEntities;
using System;
using ViewContract;

namespace Presenter
{
    public class HaspKeyPresenter : IPresenterHaspKey
    {
        private readonly IHaspKeyModel haspKeyModel;
        private readonly IEntitiesView<ModelViewHaspKey> entitiesView;

        private const string errorAdd = "Не удалось создать Hasp-ключ.";
        private const string errorUpdate = "Не удалось обновить Hasp-ключ.";
        private const string errorDelete = "Не удалось удалить Hasp-ключ.";
        private const string errorEmptyClient = "Данный клиент имеет пустые значения.";
        private const string errorHaspKey = "\u2022 Неверное значение внутреннего ключа, должно быть числом. \n";
        private const string errorEmptyTypeKey = "\u2022 Не выбран тип ключа. \n";
        private const string errorEmptyNumber = "\u2022 Не заполнено поля \"Номер\", не должно быть пустым. \n";
        private const string nullDB = "База данных не найдена.";

        public HaspKeyPresenter(IEntitiesView<ModelViewHaspKey> entitesView)
        {
            this.entitiesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            try
            {
                haspKeyModel = new HaspKeyModel(new Logics());
            }
            catch (ArgumentNullException)
            {
                entitiesView.MessageError(nullDB);
            }            
            Display();
        }

        public ModelViewHaspKey Entities { get; set; } = null;

        public void Add(ModelViewHaspKey entity)
        {
            if (entity == null)
            {
                entitiesView.MessageError(errorAdd);
                return;
            }

            if (haspKeyModel.Add(entity))
            {
                entitiesView.DataChange();
                Display();
            }
            else
                entitiesView.MessageError(errorAdd);
        }

        public void GetByActive() => entitiesView.Bind(haspKeyModel.GetByActive());

        public void GetByClient(ModelViewClient client)
        {
            if (client == null)
            {
                entitiesView.MessageError(errorEmptyClient);
                return;
            }
            entitiesView.Bind(haspKeyModel.GetByClient(client));
        }

        public void GetByPastDue() => entitiesView.Bind(haspKeyModel.GetByPastDue());

        public void Remove(int id)
        {
            if (id > 0 && haspKeyModel.Remove(id))
            {
                entitiesView.DataChange();
                Display();
            }
            else
                entitiesView.MessageError(errorDelete);
        }

        public void Update(ModelViewHaspKey entity)
        {
            if (entity == null)
            {
                entitiesView.MessageError(errorUpdate);
                return;
            }

            if (haspKeyModel.Update(entity))
            {
                entitiesView.DataChange();
                Display();
            }
            else
                entitiesView.MessageError(errorUpdate);
        }

        public void Display() => entitiesView.Bind(haspKeyModel.GetAll());

        public void Dispose() => haspKeyModel.Dispose();

        public void FillInputItem(ModelViewHaspKey item)
        {
            Entities = item ?? throw new ArgumentNullException(nameof(item));
            entitiesView.BindItem(item);
        }

        public void FillModel(ModelViewHaspKey item)
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
                        
            if (string.IsNullOrWhiteSpace(Entities.Number))
                errorMess += errorEmptyNumber;

            if (errorMess != string.Empty)
            {
                entitiesView.MessageError(errorMess.Trim());
                return false;
            }

            return true;
        }

    }
}
