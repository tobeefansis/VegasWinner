using System;
using UnityEngine;
using UnityEngine.UI;

namespace BonusGameLottery
{
    public class BonusGameLotteryHolderView : MonoBehaviour
    {
        public bool isEmpty;
        public Image coverImage;
        public Sprite coverSprite;
        public Sprite emptySprite;
        public Sprite moneySprite;

        public event Action<BonusGameLotteryHolderView> onClick;
        public void Click()
        {
            onClick?.Invoke(this);
        }
        
    }
}