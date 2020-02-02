using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameOffer
{
    public class CollectController : MonoBehaviour
    {

        [SerializeField] private GameObject ButtonCollect;
        [SerializeField] private GameObject InfoPanel;
        [SerializeField] private GameObject WinPanel;
        [SerializeField] private GameObject DiscountPanel;
        
        
        [SerializeField] private Text ButtonCollectText;
        [SerializeField] private Text InfoPanelText;
        [SerializeField] private Text InfoPanelOldPriceText;
        [SerializeField] private Text InfoWinTwxt;
        [SerializeField] private Text DiscountText;
        
        [SerializeField] private string BuyText;
        [SerializeField] private string CollectText;
        [SerializeField] private string InfoText;
        [SerializeField] private string OldPriceInfoText;
        [SerializeField] private string WinText;
        

        private bool _isBuyOffer = true;

        public void Awake()
        {
            Activate();
        }

        public void SetStateBuy(bool value)
        {
            _isBuyOffer = value;
            if (value)
            {
                ButtonCollectText.text = BuyText;
            }
            else
            {
                ButtonCollectText.text = CollectText;
            }
        }

        public void SetCollectInfo(OfferModelItem offerModel)
        {
            InfoPanelText.text =  String.Format(InfoText, offerModel.PriceNew);
            InfoPanelOldPriceText.text =  String.Format(OldPriceInfoText, offerModel.PriceOld);
            InfoWinTwxt.text =  String.Format(WinText, offerModel.Coins);
        }

        public void Activate()
        {
            ButtonCollect.SetActive(true);
            if (_isBuyOffer)
            {
                InfoPanel.SetActive(true);
            }
            else
            {
                InfoPanel.SetActive(false);
            }
        }

        public void CollectClick()
        {
            if (_isBuyOffer)
            {
                Debug.Log("buy");
            }
            else
            {
                Debug.Log("collect");
            }
        }
    }
}