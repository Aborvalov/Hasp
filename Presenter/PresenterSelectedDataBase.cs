using Model;
using ModelEntities;
using System;
using ViewContract;

namespace Presenter
{
    public class PresenterSelectedDataBase : IPresenterSelectedDataBase
    {
        private readonly IBindItemView<TypeDataBase> selectedDataBaseView;
        private readonly ISelectedDataBaseModel selectedDBModel;
        private readonly IUpdateDataBaseMain updateDataBaseMain;
        public PresenterSelectedDataBase(IBindItemView<TypeDataBase> selectedDataBaseView, IUpdateDataBaseMain updateDataBaseMain)
        {
            this.selectedDataBaseView = selectedDataBaseView ?? throw new ArgumentNullException(nameof(selectedDataBaseView));
            this.updateDataBaseMain = updateDataBaseMain ?? throw new ArgumentNullException(nameof(updateDataBaseMain));
            this.selectedDBModel = new SelectedDataBaseModel();
            Display();
        }
        public void Display() => selectedDataBaseView.BindItem(selectedDBModel.GetItem());

        public void Edit(TypeDataBase dateBase)
        {
            selectedDBModel.EditItem(dateBase);
            updateDataBaseMain.UpdateDataBaseMain();
        }
    }
}
