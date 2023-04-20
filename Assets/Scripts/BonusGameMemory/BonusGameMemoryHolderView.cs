using System;
using PlayerWallet;
using UnityEngine;
using UnityEngine.UI;

namespace BonusGameMemory
{
    public class BonusGameMemoryHolderView : MonoBehaviour
    {
        [SerializeField] private GameObject closeObject;
        [SerializeField] private GameObject openObject;

        public Bubble.Type bubbleType;
        public Image openImage;

        public Sprite yellow;
        public Sprite cyan;
        public Sprite purple;
        public Sprite green;
        public Sprite blue;
        public Sprite orange;
        public Sprite red;

        
        public event Action<BonusGameMemoryHolderView> OnClick;

        public void SetType(Bubble.Type type)
        {
            bubbleType = type;
            switch (type)
            {
                case Bubble.Type.Yellow:
                    openImage.sprite = yellow;
                    break;
                case Bubble.Type.Aqua:
                    openImage.sprite = cyan;
                    break;
                case Bubble.Type.Purple:
                    openImage.sprite = purple;
                    break;
                case Bubble.Type.Green:
                    openImage.sprite = green;
                    break;
                case Bubble.Type.Blue:
                    openImage.sprite = blue;
                    break;
                case Bubble.Type.Orange:
                    openImage.sprite = orange;
                    break;
                case Bubble.Type.Red:
                    openImage.sprite = red;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        public void SetClose()
        {
            closeObject.SetActive(true);
            openObject.SetActive(false);
        }
        public void SetOpen()
        {
            closeObject.SetActive(false);
            openObject.SetActive(true);
        }
        public void Click()
        {
            OnClick?.Invoke(this);
        }
    }
}