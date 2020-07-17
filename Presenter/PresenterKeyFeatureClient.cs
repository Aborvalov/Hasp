using Logic;
using Model;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using View;

namespace Presenter
{
    public class PresenterKeyFeatureClient : IPresenterKeyFeatureClient
    {
        private readonly IEntitiesModel<ModelViewClient> clientModel;
        private readonly IKeyFeatureClientModel keyFeatureClientModel;
        
        private readonly IKeyFeatureClientView entitiesView;
        public PresenterKeyFeatureClient(IKeyFeatureClientView entitiesView)
        {
            this.entitiesView = entitiesView ?? throw new ArgumentNullException(nameof(entitiesView));

            clientModel = new ClientModel(new Logics());
            keyFeatureClientModel = new KeyFeatureClientModel(new Logics());

            DisplayClient();
        }
        public void DisplayClient() => entitiesView.BindClient(clientModel.GetAll());

        public void DisplayHaspKeyAtClient(int idClient) 
            => entitiesView
                .BindKey(keyFeatureClientModel.GetAllAtClient(idClient));
        
        public void Dispose()
        {
            clientModel.Dispose();
            keyFeatureClientModel.Dispose();
        }

        public void Edit(List<ModelViewKeyFeatureClient> keyClient)
        {
            if (keyClient == null)
                throw new ArgumentNullException(nameof(keyClient));

            Delete(keyClient);
            Add(keyClient);
            Update(keyClient);

            DisplayHaspKeyAtClient(keyClient[0].IdClient);            
            entitiesView.DataChange();
        }

        private void Update(List<ModelViewKeyFeatureClient> keyClient)
        {
            var update = keyClient
                            .Where(x => x.Id != 0 &&
                                        x.IdClient != 0 &&
                                        x.IdKeyFeature != 0 &&
                                        !string.IsNullOrEmpty(x.Initiator) &&
                                        x.Selected);
            if (update.Any())
            {
                keyFeatureClientModel.Update(update, out string error);
                if (!string.IsNullOrEmpty(error))
                    entitiesView.MessageError(error);
            }
        }

        private void Add(List<ModelViewKeyFeatureClient> keyClient)
        {
            var add = keyClient
                        .Where(x => x.Id == 0 &&
                                    x.IdClient != 0 &&
                                    x.IdKeyFeature != 0 &&
                                    !string.IsNullOrEmpty(x.Initiator) &&
                                    x.Selected);
            if (add.Any())
            {
                keyFeatureClientModel.Add(add, out string error);
                if (!string.IsNullOrEmpty(error))
                    entitiesView.MessageError(error);
            }
        }

        private void Delete(List<ModelViewKeyFeatureClient> keyClient)
        {
            var delete = keyClient
                            .Where(x => x.Id != 0 && !x.Selected)
                            .Select(x => x.Id);
            if (delete.Any())
            {
                keyFeatureClientModel.Remove(delete, out string error);
                if (!string.IsNullOrEmpty(error))
                    entitiesView.MessageError(error);
            }
        }

        public bool CheckInputData(List<ModelViewKeyFeatureClient> item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            int numverRow = 0;
            bool error = true;
            foreach (var i in item)
            {
                error &= CheckInputData(i, numverRow);
                numverRow++;
            }
            return error;
        }
        public bool CheckInputData(ModelViewKeyFeatureClient item, int numverRow)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (string.IsNullOrEmpty(item.Initiator) &&
                item.Selected)
            {
                entitiesView.ErrorRow(numverRow);
                return false;
            }
            return true;
        }
    }
}
