
using System;
using UnityEngine.Serialization;

namespace BonusGameLottery
{
    [Serializable]
    public class BonusGameLotteryModel
    {
        public int emptyHolderCount = 5;
        public int bonusSpinCount = 10;
        public int openCount=0;
        public int maxOpenCount=0;
        
    }
}