using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DailyBonus
{
    [Serializable]
    public class DayBonus
    {
        [SerializeField] private string openDay;
        public bool isTookIt;
        public DateTime OpenDay
        {
            get=>DateTime.Parse(openDay);
            set => openDay = value.ToString();
            
        }

        public DayBonus(DateTime dateTime)
        {
            OpenDay = dateTime;
        }
    }
}