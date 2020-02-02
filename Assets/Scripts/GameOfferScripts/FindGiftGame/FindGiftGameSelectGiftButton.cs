using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FindGiftGame
{
    public class FindGiftGameSelectGiftButton : MonoBehaviour
    {
        [SerializeField] private GameObject TextWin;
        [SerializeField] private GameObject TextLost;
        [SerializeField] private TextMeshProUGUI TextWinText;
        [SerializeField] private TextMeshProUGUI TextLostText;
        
        [SerializeField] private Animation OpenGift;

        public Action<FindGiftGameSelectGiftButton> OnButtonClick;
        public int ButtonId { get; set; }

        public bool ButtonSelected = false;
        
        public void OnClick()
        {
            if (OnButtonClick != null && !ButtonSelected)
            {
                OnButtonClick.Invoke(this);
                ButtonSelected = true;
            }
        }

        public void SetTextWin(long value)
        {
            if(TextWinIsAvalible())
                TextWinText.text = value.ToString();
        }
        
        public void SetTextLost(long value)
        {
            if(TextLostIsAvalible())
                TextLostText.text = value.ToString();
        }

        public void PlayWin()
        {
            if(TextWinIsAvalible())
                TextWin.gameObject.SetActive(true);
            if(TextLostIsAvalible())
                TextLost.gameObject.SetActive(false);
            PlayOpenGift();
        }

        public void PlayLost()
        {
            if(TextWinIsAvalible())
                TextWin.gameObject.SetActive(false);
            if(TextLostIsAvalible())
                TextLost.gameObject.SetActive(true);
        }
        
        private bool TextWinIsAvalible()
        {
            if (TextWin != null)
            {
                return true;
            }
            else
            {
                Debug.LogWarning("FindGiftGameSelectGiftButton TextWin is null");
                return false;
            }
        }
        
        private bool TextLostIsAvalible()
        {
            if (TextWin != null)
            {
                return true;
            }
            else
            {
                Debug.LogWarning("FindGiftGameSelectGiftButton TextLost is null");
                return false;
            }
        }

        private void PlayOpenGift()
        {
            if (OpenGift != null)
            {
                OpenGift.Play();
            }
        }
    }
}