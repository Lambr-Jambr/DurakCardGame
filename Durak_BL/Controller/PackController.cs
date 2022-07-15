﻿using Durak_BL.Model;
using Durak_BL.Enums;
using System;
using System.Collections.Generic;

namespace Durak_BL.Controller
{
    public class PackController
    {
        private Random rnd = new Random();

        private List<Card>[] DealedCards;
        public Pack Pack { get; }
        public int FirstStepIndex { get; }

        public PackController(List<PlayerController> players)
        {
            if(players.Count <= 1 || players.Count > 6)
            {
                throw new ArgumentException("Недопустимое количество игроков.", nameof(players.Count));
            }
            Pack = new Pack(GenerateCards());
            Start_DealCards(players.Count);
            FirstStepIndex = CheckForFirstStep();

            for(int i = 0; i < players.Count; i++)
            {
                players[i].Player.Cards = DealedCards[i];
            }
        }

        /// <summary>
        /// Generate pack of cards and shuffles them.
        /// </summary>
        /// <returns></returns>
        private List<Card> GenerateCards()
        {
            int index;
            List<Card> CardsForDeal = new List<Card>();
            List<Card> temp = new List<Card>();
            for (int suit = (int)CardSuit.Diamonds; suit <= (int)CardSuit.Spades; suit++)
            {
                for (int rank = (int)CardRank.Six; rank <= (int)CardRank.Ace; rank++)
                {
                    temp.Add(new Card(suit, rank, false));
                }
            }
            while(temp.Count != 0)
            {
                index = rnd.Next(0, temp.Count);
                CardsForDeal.Add(temp[index]);
                temp.RemoveAt(index);
            }
            return CardsForDeal;
        }

        /// <summary>
        /// Distribution of cards to players.
        /// </summary>
        /// <param name="playersCount"></param>
        private void Start_DealCards(int playersCount)
        {
            DealedCards = new List<Card>[playersCount];
            for(int i = 0; i < DealedCards.Length; i++)
            {
                DealedCards[i] = new List<Card>();
            }
            for (int i = 0; i < DealedCards.Length; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    int cardInd = rnd.Next(0, Pack.Cards.Count);
                    DealedCards[i].Add(Pack.Cards[cardInd]);
                    Pack.Cards.RemoveAt(cardInd);
                }
            }
        }

        private int CheckForFirstStep()
        {
            Card minCard = new Card(Pack.TrumpSuit, (int)CardRank.Ace, true);
            foreach (var cards in DealedCards)
            {
                foreach (var card in cards)
                {
                    if (card < minCard && card.IsTrump)
                        minCard = card;
                }
            }

            for (int i = 0; i < DealedCards.Length; i++)
            {
                if (DealedCards[i].Contains(minCard))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
