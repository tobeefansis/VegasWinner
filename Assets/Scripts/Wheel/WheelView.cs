using System;
using System.Collections.Generic;
using PlayerWallet;
using UnityEngine;

namespace Wheel
{
    public class WheelView : MonoBehaviour
    {
        public List<BubbleHolderView> bubbleHolders = new List<BubbleHolderView>();
        public Transform wheel;
        public event Action OnSpin;

        public void Set(Dictionary<Bubble.Type, Bubble> bubbles)
        {
            foreach (var holder in bubbleHolders)
            {
                var bubble = bubbles[holder.type];
                holder.countText.text = bubble.value == 0 ? "" : bubble.value.ToString();
            }
        }

        public void Spin()
        {
            OnSpin?.Invoke();
        }
    }
}