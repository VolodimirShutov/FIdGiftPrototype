using FindGiftGame;
using GameOffer;
using UnityEngine;

namespace GameOfferTest.VisualTest
{
    public class GameOfferVisualTest : MonoBehaviour
    {
        [SerializeField] private FindGiftGameController Controller;
        [SerializeField] private OfferModel Model;

        public void Awake()
        {
            Controller.SetDataFromServer(Model);
        }
    }
}
