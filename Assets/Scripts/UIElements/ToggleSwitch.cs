using UnityEngine;
using UnityEngine.Events;

namespace UIElements
{
    public class ToggleSwitch : MonoBehaviour
    {
        public bool isActive;
        [SerializeField] private GameObject onText;
        [SerializeField] private GameObject offText;
        [SerializeField] private GameObject onCheckmark;
        [SerializeField] private GameObject offCheckmark;
        [SerializeField] private UnityEvent<bool> OnChange;
        
        public void Click()
        {
            isActive = !isActive;
            onCheckmark.SetActive(isActive);   
            offCheckmark.SetActive(!isActive);    
            onText.SetActive(isActive);   
            offText.SetActive(!isActive);   
            OnChange.Invoke(isActive);
        }

    }
}
