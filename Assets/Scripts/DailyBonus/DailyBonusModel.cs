using System;
using System.Collections.Generic;
using UnityEngine;

namespace DailyBonus
{
    [Serializable]
    public class DailyBonusModel
    {
        public List<DayBonus> DayBonusList = new List<DayBonus>();
        public int spinCount;
        public event Action OnChange;

        public void Change()
        {
            OnChange?.Invoke();
        }
    }
}