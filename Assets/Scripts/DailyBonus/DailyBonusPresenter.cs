using System;
using System.Linq;
using BonusGameMemory;
using BonusSystem;

namespace DailyBonus
{
    public class DailyBonusPresenter
    {
        private readonly DailyBonusModel _dailyBonusModel;
        private readonly BonusModel _bonusModel;
        private readonly DailyBonusView _view;

        public DailyBonusPresenter(DailyBonusModel dailyBonusModel, BonusModel bonusModel, DailyBonusView view)
        {
            _dailyBonusModel = dailyBonusModel;
            _bonusModel = bonusModel;
            _view = view;
            if (_dailyBonusModel.DayBonusList.Count==0)
            {

                DateTime time = DateTime.Now;
                
                for (int i = 0; i < _view.toggles.Count; i++)
                {
                    _dailyBonusModel.DayBonusList.Add(
                        new DayBonus(time)
                        );
                    time = time.AddDays(1);
                }
                 
                
            }
            _view.OnClaim += ViewOnClaim;
            Refresh();
        }

        public void Refresh()
        {
            for (var index = 0; index < _view.toggles.Count&& index < _dailyBonusModel.DayBonusList.Count; index++)
            {
                var toggle = _view.toggles[index];
                var dayBonus = _dailyBonusModel.DayBonusList[index];
                toggle.isOn = dayBonus.isTookIt;
            }
        }
        private void ViewOnClaim()
        {
            var now = DateTime.Now;
            DayBonus bonus = null;
            foreach (var dayBonus in _dailyBonusModel.DayBonusList.Where(dayBonus => dayBonus.OpenDay < now && !dayBonus.isTookIt))
            {
                bonus = dayBonus;
            }
            if (bonus==null) return;
            bonus.isTookIt = true;
            _bonusModel.BonusSpinCount += _dailyBonusModel.spinCount;
            _bonusModel.BonusMaxSpinCount += _dailyBonusModel.spinCount;
            _bonusModel.Change();
            _dailyBonusModel.Change();
            Refresh();
        }
    }
}