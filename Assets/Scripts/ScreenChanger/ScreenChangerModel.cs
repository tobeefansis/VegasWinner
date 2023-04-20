using System;

namespace ScreenChanger
{
    [Serializable]
    public class ScreenChangerModel
    {
        public ScreenView mainMenu;
        public ScreenView gameplay;
        public ScreenView settings;
        public ScreenView bonusGame1;
        public ScreenView bonusGame2;
        public ScreenView dailyBonus;
        public ScreenView email;
        public ScreenView rools;
        public ScreenView wallet;

    }
    public enum Screens
    {
        MainMenu,
        Gameplay,
        Settings,
        BonusGame1,
        BonusGame2,
        DailyBonus,
        Email,
        Rools,
    }
}
