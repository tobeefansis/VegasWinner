using System;
using PlayerWallet;

namespace BonusGameMemory
{
    [Serializable]
    public class BonusGameMemoryModel
    {

        public State gameState;
        public Bubble.Type selectType;
        public float timeToView;
        public float timeToOpen;
        public int openCount;
        public int maxOpenCount;
        public int spinCount;
        public enum State
        {
            View,
            Opening,
            Close
        }
    }
}