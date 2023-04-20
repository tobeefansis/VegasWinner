using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BonusGameMemory
{
    public class BonusGameMemoryView : MonoBehaviour
    {
        public List<BonusGameMemoryHolderView> holders = new List<BonusGameMemoryHolderView>();
        public event Action OnRestart;
        public TextMeshProUGUI timerText;
        public TextMeshProUGUI selectBubbleText;
        public GameObject winTitle;
        public GameObject loseTitle;
        public GameObject buttonObject;
        public void Restart()
        {
            OnRestart?.Invoke();
        }
    }
}