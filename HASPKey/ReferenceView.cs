﻿using Presenter;
using ViewContract;

namespace HASPKey
{
    public partial class ReferenceView : DevExpress.XtraEditors.XtraForm, IBindItemView<string>
    {
        private readonly IPresenterView presenterRefernce;
        public ReferenceView()
        {
            InitializeComponent();
            presenterRefernce = new ReferencePresenter(this);
        }
        public void BindItem(string text) 
            => labelReference.Text = text;
    }
}
