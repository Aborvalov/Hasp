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
        private readonly IHaspKeyView entitiesView;

        private const string errorAdd = "Не удалось создать Hasp-ключ.";
        private const string errorUpdate = "Не удалось обновить Hasp-ключ.";
        private const string errorDelete = "Не удалось удалить Hasp-ключ.";
        private const string errorEmptyClient = "Данный клиент имеет пустые значения.";
        private const string errorHaspKey = "\u2022 Неверное значение внутреннего ключа, должно быть числом. \n";
        private const string errorEmptyTypeKey = "\u2022 Не выбран тип ключа. \n";
        private const string errorEmptyNumber = "\u2022 Не заполнено поля \"Номер\", не должно быть пустым. \n";
        
        public PresenterHaspKey(IHaspKeyView entitesView)
        {
            this.entitiesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            haspKeyModel = new HaspKeyModel(new Logics());
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

        public void FillInputItem(ModelViewHaspKey row)
        {
            if (row == null)
                return;
            Entities = new ModelViewHaspKey
            {
                Id = row.Id
            };
            entitiesView.InnerNumber = row.InnerId.ToString();
            entitiesView.Number = row.Number;
            entitiesView.TypeKey = row.TypeKey;
            entitiesView.IsHome = row.IsHome;
        }

        public void FillModel()
        {
            if (!CheckInputData(out int innNumber))
                return;

            Entities.InnerId = innNumber;
            Entities.Number = entitiesView.Number;
            Entities.TypeKey = entitiesView.TypeKey;
            Entities.IsHome = entitiesView.IsHome;

            if (Entities.Id < 1)
                Add(Entities);
            else
                Update(Entities);
        }
        private bool CheckInputData(out int innNumber)
        {
            string errorMess = string.Empty;

            if (!int.TryParse(entitiesView.InnerNumber, out innNumber))
            {
                errorMess = errorHaspKey;
                entitiesView.InnerNumber = string.Empty;
            }  

            if (string.IsNullOrWhiteSpace(entitiesView.Number))
                errorMess += errorEmptyNumber;

            if (errorMess != string.Empty)
            {
                entitiesView.MessageError(errorMess.Trim());
                return false;
            }

            return true;
        }

        public void FillModel(ModelViewHaspKey item)
        {
            throw new NotImplementedException();
        }
    }
}
