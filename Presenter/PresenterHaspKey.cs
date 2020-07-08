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
        private readonly IEntitiesView<ModelViewHaspKey> entitiesView;

        private const string errorAdd = "Не удалось создать Hasp-ключ.";
        private const string errorUpdate = "Не удалось обновить Hasp-ключ.";
        private const string errorDelete = "Не удалось удалить Hasp-ключ.";
        private const string errorEmptyСдшуте = "Данный клиент имеет пустые значения.";
               
        public PresenterHaspKey(IEntitiesView<ModelViewHaspKey> entitesView)
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
                Display();
            else
                entitiesView.MessageError(errorAdd);
        }

        public void GetByActive() => entitiesView.Bind(haspKeyModel.GetByActive());

        public void GetByClient(ModelViewClient client)
        {
            if (client == null)
            {
                entitiesView.MessageError(errorEmptyСдшуте);
                return;
            }
            entitiesView.Bind(haspKeyModel.GetByClient(client));
        }

        public void GetByPastDue() => entitiesView.Bind(haspKeyModel.GetByPastDue());

        public void Remove(int id)
        {
            if (id > 0 && haspKeyModel.Remove(id))
                Display();
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
                Display();
            else
                entitiesView.MessageError(errorUpdate);
        }

        public void Display() => entitiesView.Bind(haspKeyModel.GetAll());

        public void Dispose() => haspKeyModel.Dispose();

        public void FillInputItem(ModelViewHaspKey row)
        {
            throw new NotImplementedException();
        }
    }
}
