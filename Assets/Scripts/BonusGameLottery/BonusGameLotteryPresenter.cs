using System;
using BonusSystem;

namespace BonusGameLottery
{
    public class BonusGameLotteryPresenter
    {
        private readonly BonusGameLotteryModel _lotteryModel;
        private readonly BonusModel _bonusModel;
        private readonly BonusGameLotteryView _view;
        
        public BonusGameLotteryPresenter(BonusGameLotteryModel lotteryModel,BonusModel bonusModel, BonusGameLotteryView view)
        {
            _lotteryModel = lotteryModel;
            _bonusModel = bonusModel;
            _view = view;

            foreach (var holder in _view.holders)
            {
                holder.onClick += HolderOnClick;
            }
            _view.OnRefresh += Restart;
            Restart();
        }


        private void Restart()
        {
            foreach (var holder in _view.holders)
            {
                holder.isEmpty = true;
                holder.coverImage.sprite = holder.coverSprite;
            }

            _lotteryModel.openCount = 0;

            _view.holders[UnityEngine.Random.Range(0, _view.holders.Count)].isEmpty = false;
        }
        
        private void HolderOnClick(BonusGameLotteryHolderView obj)
        {
            if (_lotteryModel.openCount>= _lotteryModel.maxOpenCount)return;
            obj.coverImage.sprite = obj.isEmpty ? obj.emptySprite : obj.moneySprite;
            _lotteryModel.openCount++;
         

            if (!obj.isEmpty)
            {
                _bonusModel.BonusSpinCount += _lotteryModel.bonusSpinCount;
                _bonusModel.BonusMaxSpinCount += _lotteryModel.bonusSpinCount;
                _bonusModel.Change();
            }
        }
    }
}