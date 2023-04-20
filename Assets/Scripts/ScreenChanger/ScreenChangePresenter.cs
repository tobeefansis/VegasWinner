using System;

namespace ScreenChanger
{
    public class ScreenChangePresenter
    {
        private readonly ScreenChangerModel _model;
        private readonly ScreenView _view;
        
        public ScreenChangePresenter(ScreenChangerModel model, ScreenView view)
        {
            if (model == null) return;
            if (view == null) return;
            _model = model;
            _view = view;
            
            view.OnChangeScreen += OnChangeScreen;
        }

        private void OnChangeScreen(Screens screen)
        {
            HildeAll();
            switch (screen)
            {
                case Screens.MainMenu:
                    _model.mainMenu.Show();
                    _model.wallet.Show();
                    break;
                case Screens.Gameplay:
                    _model.gameplay.Show();
                    _model.wallet.Show();
                    break;
                case Screens.Settings:
                    _model.settings.Show();
                    break;
                case Screens.BonusGame1:
                    _model.bonusGame1.Show();
                    break;
                case Screens.BonusGame2:
                    _model.bonusGame2.Show();
                    break;
                case Screens.DailyBonus:
                    _model.dailyBonus.Show();
                    break;
                case Screens.Email:
                    _model.email.Show();
                    break;
                case Screens.Rools:
                    _model.rools.Show();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(screen), screen, null);
            }
        }

        private void HildeAll()
        {
            _model.wallet?.Hide();
            _model.mainMenu?.Hide();
            _model.gameplay?.Hide();
            _model.settings?.Hide();
            _model.bonusGame1?.Hide();
            _model.bonusGame2?.Hide();
            _model.dailyBonus?.Hide();
            _model.email?.Hide();
            _model.rools?.Hide();
        }
    }
}