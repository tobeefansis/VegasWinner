using System;
using System.Collections.Generic;
namespace PlayerWallet
{
    [System.Serializable]
    public class PlayerWalletModel
    {


        public List< Bubble> Bubbles = new()
        {
            new Bubble(Bubble.Type.Blue),
            new Bubble( Bubble.Type.Aqua),
            new Bubble( Bubble.Type.Green),
            new Bubble(Bubble.Type.Orange),
            new Bubble(Bubble.Type.Purple),
            new Bubble(Bubble.Type.Yellow),
            new Bubble(Bubble.Type.Red),
        };


        public event Action OnChange;

       
        public void Change()
        {
            
            OnChange?.Invoke();
        }
    }
}