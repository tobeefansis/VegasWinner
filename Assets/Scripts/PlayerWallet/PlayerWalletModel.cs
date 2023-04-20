using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayerWallet
{
    [System.Serializable]
    public class PlayerWalletModel
    {
       


        public UnityEngine.Rendering.SerializedDictionary <Bubble.Type, Bubble> Bubbles = new()
        {
            {Bubble.Type.Blue, new Bubble()},
            {Bubble.Type.Aqua, new Bubble()},
            {Bubble.Type.Green, new Bubble()},
            {Bubble.Type.Orange, new Bubble()},
            {Bubble.Type.Purple, new Bubble()},
            {Bubble.Type.Yellow, new Bubble()},
            {Bubble.Type.Red, new Bubble()},
        };


        public event Action OnChange;

       
        public void Change()
        {
            OnChange?.Invoke();
        }
    }
}