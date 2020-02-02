using System;
using GameOffer;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FindGiftGame
{
    public class FindGiftGameController : GameOfferBaseController
    {
        [SerializeField] private FindGiftGameSelectButtons ButtonsController;
        [SerializeField] private MainInfoPanelController InfoPanelController;
        [SerializeField] private CollectController CollectController;
        
        private BaseGameOfferStorage Storage = new BaseGameOfferStorage();

        private void Awake()
        {
            CollectController.gameObject.SetActive(false);
            if (ButtonsController != null)
            {
                ButtonsController.AllButtonsSelected += AllButtonsSelected;
            }
        }

        public void SetDataFromServer(OfferModel newModel)
        {
            Storage.Model = newModel;

            ButtonsController.Storage = Storage;
            
            SelectActiveModelItem();

            if (DetectDiscount())
            {
                RandomizeDiscount();
                InfoPanelController.SetGift(Storage.ActiveModelItem);
                CollectController.SetStateBuy(false);
            }
            else
            {
                RandomizeCoins();
                DetectGiftOrOffer();
            }

            StartGame();
        }

        private bool DetectDiscount()
        {
            bool discount = Storage.Model.IsDiscount;
            return discount;
        }

        private void RandomizeDiscount()
        {
            long value = Storage.ActiveModelItem.Discount;
            int goodItemsCount = Storage.ActiveModelItem.TrysCount;
            int itemsCount = ButtonsController.GiftCounts;

            Storage.MultiplePickItem = CalculateMultiplePick.Calculate(value, itemsCount, goodItemsCount);
        }
        
        private void SelectActiveModelItem()
        {
            OfferModelItem[] OfferModelItems = Storage.Model.OfferModelItems;
            int count = OfferModelItems.Length;
            int position = Random.Range(0, count - 1);
            Storage.ActiveModelItem = OfferModelItems[position];
        }
        
        private void DetectGiftOrOffer()
        {
            if (Storage.Model.IsGift)
            {
                InfoPanelController.SetGift(Storage.ActiveModelItem);
                CollectController.SetStateBuy(false);
            }
            else
            {
                InfoPanelController.SetOffer(Storage.ActiveModelItem);
                CollectController.SetStateBuy(true);
            }
        }

        private void RandomizeCoins()
        {
            long value = Storage.ActiveModelItem.Coins;
            int goodItemsCount = Storage.ActiveModelItem.TrysCount;
            int itemsCount = ButtonsController.GiftCounts;

            Storage.MultiplePickItem = CalculateMultiplePick.Calculate(value, itemsCount, goodItemsCount);
        }

        private void StartGame()
        {
            CollectController.SetCollectInfo(Storage.ActiveModelItem);
        }

        private void AllButtonsSelected()
        {
            CollectController.gameObject.SetActive(true);
        }
    }
}