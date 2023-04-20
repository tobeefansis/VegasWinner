using System;
using UnityEngine;

namespace ScreenChanger
{
    public class ScreenView : MonoBehaviour
    {
        public Action<Screens> OnChangeScreen;
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void ChangeScreen(Screens screen)
        {
            OnChangeScreen?.Invoke(screen);
        }

        public void ShowMainMenu() => ChangeScreen(Screens.MainMenu);
        public void ShowGameplay() => ChangeScreen(Screens.Gameplay);
        public void ShowSettings() => ChangeScreen(Screens.Settings);
        public void ShowBonusGame1() => ChangeScreen(Screens. BonusGame1);
        public void ShowBonusGame2() => ChangeScreen(Screens.BonusGame2);
        public void ShowDailyBonus() => ChangeScreen(Screens.DailyBonus);
        public void ShowEmail() => ChangeScreen(Screens.Email);
    }
}
