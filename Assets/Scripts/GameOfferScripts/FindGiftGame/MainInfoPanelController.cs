using System;
using GameOffer;
using TMPro;
using UnityEngine;

namespace FindGiftGame
{
    public class MainInfoPanelController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI InfoText;
        
        [SerializeField] private string BuyText;
        [SerializeField] private string GiftText;

        public void SetGift(OfferModelItem model)
        {
            InfoText.text = String.Format(GiftText, model.TrysCount);
        }

        public void SetOffer(OfferModelItem model)
        {
            InfoText.text = String.Format(BuyText, model.TrysCount);
        }
    }
}