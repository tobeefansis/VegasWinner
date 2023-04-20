using System;
using PlayerWallet;
using TMPro;
using Wheel;

namespace BonusSystem
{
    public class BonusShowPresenter
    {
        private readonly BonusModel _model;
        private readonly BonusView _view;
        public BonusShowPresenter(BonusModel model, BonusView view)
        {
            _model = model;
            _view = view;
            model.OnChange+= ModelOnOnChange;
            ModelOnOnChange();
        }

        private void ModelOnOnChange()
        {
            var value = _model.BonusMaxSpinCount - _model.BonusSpinCount;
            if (_model.BonusSpinCount==0)
            {
                _view.Hide();
            }
            else
            {
                _view.Show();
                _view.Refresh( value,_model.BonusMaxSpinCount,_model.BonusScale);
            }
        }
    }
}