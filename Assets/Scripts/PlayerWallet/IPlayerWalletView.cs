using System.Collections.Generic;

namespace PlayerWallet
{
    public interface IPlayerWalletView
    {
         void Set(Dictionary<Bubble.Type, Bubble> bubbles);
    }
}