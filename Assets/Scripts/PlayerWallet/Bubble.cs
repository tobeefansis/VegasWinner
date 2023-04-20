using System;
using UnityEngine.Serialization;

namespace PlayerWallet
{
    [Serializable]
    public class Bubble
    {
        public int value;
        public Type type;
        public Bubble( Type type, int value=0)
        {
            this.type = type;
            this.value = value;
        }
        public enum Type
        {
            Yellow,
            Aqua,
            Purple,
            Green,
            Blue,
            Orange,
            Red,
            Empty,
        }
            
    }
}