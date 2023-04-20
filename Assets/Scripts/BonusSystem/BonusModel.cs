using System;

namespace BonusSystem
{
    [Serializable]
    public class BonusModel
    {
        public int BonusSpinCount;
        public int BonusMaxSpinCount;
        public int BonusScale=2;
        public event Action OnChange;
        
        public void Change()
        {
            OnChange?.Invoke();
        }
    }
}