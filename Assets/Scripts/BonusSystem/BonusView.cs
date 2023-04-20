using TMPro;
using UnityEngine;

namespace BonusSystem
{
    public class BonusView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI bonusText;
        [SerializeField] private TextMeshProUGUI bonusScaleText;
        public void Refresh(int value, int maxValue,int scale)
        {
            bonusText.text = $"{value}/{maxValue} Games";
            bonusScaleText.text = $"X{scale}";
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        } 
        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}