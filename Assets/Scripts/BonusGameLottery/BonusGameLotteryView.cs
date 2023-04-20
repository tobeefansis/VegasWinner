using System;
using System.Collections.Generic;
using UnityEngine;

namespace BonusGameLottery
{
    public class BonusGameLotteryView : MonoBehaviour
    {
        public List<BonusGameLotteryHolderView> holders = new List<BonusGameLotteryHolderView>();
        public event Action<BonusGameLotteryHolderView> OnChange;
        public event Action OnRefresh;

        public void Refresh()
        {
            OnRefresh?.Invoke();
        }
    }
}