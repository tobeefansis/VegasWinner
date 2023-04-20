using UnityEngine;

namespace PlayerWallet
{
    public class PlayerWalletPresenter
    {
        private PlayerWalletModel _model;
        private IPlayerWalletView _view;
        
        public PlayerWalletPresenter(PlayerWalletModel model, IPlayerWalletView view)
        {
            _model = model;
            model.OnChange += Refresh;
            _view = view;
            
        }

        private void Refresh()
        {
          
            _view.Set(_model.Bubbles);
        }
        public void Init()
        {
            Refresh();
        }
    }
}