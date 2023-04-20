using System;
using System.Collections.Generic;
using PlayerWallet;
using UnityEngine;
using UnityEngine.UI;

namespace DailyBonus
{
    public class DailyBonusView : MonoBehaviour
    {
        public List<Toggle> toggles = new List<Toggle>();

        public GameObject claimButton;

        public event Action OnClaim;

        public void Claim()
        {
            OnClaim?.Invoke();
        }
    }
}