using BonusSystem;
using UnityEngine;

namespace PlayerWallet
{
    public static class PlayerWalletAddBubble
    {
        
        public static void AddBubble(PlayerWalletModel model, BonusModel bonusModel, Bubble bubble)
        {
            var value = bubble.value;
            if (bonusModel.BonusSpinCount>0)
            {
                bonusModel.BonusSpinCount--;
                value *= bonusModel.BonusScale;
                bonusModel.Change();
            }

            var modelBubble = model.Bubbles.Find(n => n.type == bubble.type);
           
            modelBubble.value += value;
            model.Change();
        }
    }
}