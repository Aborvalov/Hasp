using Model;
using ModelEntities;
using System;
using View;

namespace Presenter
{
    public class PresenterSelectedDataBase : IPresenterView
    {
        private readonly ISelectedDataBaseView selectedDataBaseView;
        private readonly IItemModel<TypeDateBase> selectedDBModel;
        public PresenterSelectedDataBase(ISelectedDataBaseView selectedDataBaseView)
        {
            this.selectedDataBaseView = selectedDataBaseView ?? throw new ArgumentNullException(nameof(selectedDataBaseView));

            this.selectedDBModel = new SelectedDataBaseModel();
            Display();
        }
        public void Display() => selectedDataBaseView.BindItem(selectedDBModel.GetItem());
    }
}
