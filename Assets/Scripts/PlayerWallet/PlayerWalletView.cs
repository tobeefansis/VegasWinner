using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayerWallet
{
    public class PlayerWalletView : MonoBehaviour, IPlayerWalletView
    {
        public List<BubbleHolderView> bubbleHolders = new List<BubbleHolderView>();

        public void Set(List< Bubble> bubbles)
        {
           
            foreach (var holder in bubbleHolders)
            {
                holder.countText.text =bubbles.Find(n=>n.type==holder.type).value.ToString();
            }
        }
    }
}