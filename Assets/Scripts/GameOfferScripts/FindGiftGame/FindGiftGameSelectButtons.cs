using System;
using System.Collections;
using GameOffer;
using UnityEngine;

namespace FindGiftGame
{
    public class FindGiftGameSelectButtons : MonoBehaviour
    {
        [SerializeField] private FindGiftGameSelectGiftButton[] Buttons;

        public Action AllButtonsSelected;
        public int GoodGiftCount = 1;
        private int LastSelectedButton;
        private int SelectedButtonCount;
        public BaseGameOfferStorage Storage { get; set; }
        
        
        public int GiftCounts
        {
            get { return Buttons.Length; }
        }

        public void Awake()
        {
            InitButtons();
        }

        private void InitButtons()
        {
            int counter = 0;
            foreach (FindGiftGameSelectGiftButton button in Buttons)
            {
                button.ButtonId = counter;
                counter++;
                button.OnButtonClick += ButtonSelected;
            }
        }

        private void ButtonSelected(FindGiftGameSelectGiftButton button)
        {
            SelectedButtonCount++;
            if (Storage.MultiplePickItem.GoodItems.Count <= SelectedButtonCount - 1)
            {
                return;
            }
            
            long currentValue = Storage.MultiplePickItem.GoodItems[SelectedButtonCount - 1];
            button.SetTextWin(currentValue);
            button.PlayWin();
            if (Storage.ActiveModelItem.TrysCount <= SelectedButtonCount)
            {
                StartCoroutine(FinishCollected());
            }
        }

        private IEnumerator FinishCollected()
        {
            yield return new WaitForSeconds(1f);
            OpenClosedGifts();
            
            yield return new WaitForSeconds(1f);
            AllButtonsSelected.Invoke();
        }

        private void OpenClosedGifts()
        {
            int badCount = 0;
            foreach (FindGiftGameSelectGiftButton button in Buttons)
            {
                if (!button.ButtonSelected)
                {
                    long currentValue = Storage.MultiplePickItem.BadItems[badCount];
                    button.SetTextLost(currentValue);
                    button.PlayLost();
                    badCount++;
                }
            }
        }
        
        public void OnDestroy()
        {
            RemoveListeners();
        }

        private void RemoveListeners()
        {
            foreach (FindGiftGameSelectGiftButton button in Buttons)
            {
                button.OnButtonClick -= ButtonSelected;
            }
        }
    }
}