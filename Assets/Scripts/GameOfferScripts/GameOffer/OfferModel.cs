using System;
using UnityEngine;

namespace GameOffer
{
    [Serializable]
    public class OfferModel
    {
        public bool IsGift;
        public bool IsDiscount;
        public OfferModelItem[] OfferModelItems;
    }
}