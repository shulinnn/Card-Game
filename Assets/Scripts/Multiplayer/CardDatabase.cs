using Assets.Scripts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{




    [Serializable]
    public class CardDatabaseObject
    {
        public string Name;
        public List<Card> Cards = new List<Card>();
    }

    [CreateAssetMenu(fileName = "New Card Database", menuName = "Card Shuffle/Card Database")]
    public class CardDatabase : ScriptableObject
    {

        public List<Card> AllCardsInGame = new List<Card>();

        public CardDatabaseObject[] databases;

        #region singleton
        private static CardDatabase m_Instance;
        public static CardDatabase Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = Resources.Load("CardDatabase") as CardDatabase;

                return m_Instance;
            }
        }
        #endregion

        public Card GetRandomCardFromDeck(PlayerDeckObject playerDeckObject)
        {

            Debug.Log(playerDeckObject);

            CardDatabaseObject cardDatabaseObject = databases.First(item => item.Name == playerDeckObject.ToString());
            return cardDatabaseObject.Cards[UnityEngine.Random.Range(0, cardDatabaseObject.Cards.Count)];
        }

        public CardDatabaseObject GetCardDatabaseObjectByDeckName(string deckName) => databases.First(item => item.Name == deckName);

        public string GetCardLayerMask(Card card) => LayerMask.LayerToName(LayerMask.NameToLayer(card.targetType.ToString()));

        public Card GetCardByName(string str) => AllCardsInGame.First(item => item.name == str);
    }
}
