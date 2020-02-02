using System;

namespace GameOffer
{
    [Serializable]
    public class OfferModelItem
    {
        public long Coins;
        public long Discount;
        public long PriceNew;
        public long PriceOld;
        public int TrysCount;
        public long Time;
        public string Action;
        public string ActionParams;
    }
}