using System;
using System.Collections.Generic;
using PlayerWallet;
using UnityEngine;

namespace Wheel
{
    [Serializable]
    public class WheelModel
    {
        public Dictionary<Bubble.Type, Bubble> Bubbles = new()
        {
            {Bubble.Type.Yellow ,new Bubble(Bubble.Type.Yellow,1)},//4
            {Bubble.Type.Aqua,new Bubble(Bubble.Type.Aqua,2)},//2
            {Bubble.Type.Purple,new Bubble(Bubble.Type.Purple,3)},//22
            {Bubble.Type.Green,new Bubble(Bubble.Type.Green,4)},//6

            {Bubble.Type.Blue,new Bubble(Bubble.Type.Blue,5)},//8
            {Bubble.Type.Orange,new Bubble(Bubble.Type.Orange,6)},//6
            {Bubble.Type.Red ,new Bubble(Bubble.Type.Red,7)},//12
            {Bubble.Type.Empty ,new Bubble(Bubble.Type.Empty,8)},//0
        };

        public AnimationCurve curve;
        public int SpinCount = 5;
        public bool IsSpinning;
    }
}