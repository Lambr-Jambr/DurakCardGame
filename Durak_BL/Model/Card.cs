using System;
using System.Collections.Generic;
using Durak_BL.Enums;


namespace Durak_BL.Model
{
    public class Card : IComparable<Card>
    {
        //Pack - колода
        // Beat - бита (бить карту)
        public int Suit { get; }
        public int Rank { get; }
        public bool IsTrump { get; private set; }

        public Card(int suit, int rank, bool isTrump)
        {
            if (suit < 0 && suit > 3)
            {
                throw new ArgumentException("Недопустимое значение", nameof(suit));
            }
            if (rank < 6 && rank > 14)
            {
                throw new ArgumentException("Недопустимое значение", nameof(rank));
            }
            Suit = suit;
            Rank = rank;
            IsTrump = isTrump;
        } 

        public static void SpecifyTrump(List<Card> cards, int trumpSuit)
        {
            foreach(var card in cards)
            {
                card.IsTrump = true ? (card.Suit == trumpSuit) : false;
            }
        }

        #region Override Methods
        public static bool operator <(Card firstCard, Card secondCard)
        {
            var result = false;
            if (!secondCard.IsTrump)
            {
                result = true ? (firstCard == secondCard &&
                firstCard.Rank < secondCard.Rank) : false;
            }
            else
            {
                if (firstCard.IsTrump)
                {
                    result = true ? (firstCard.Rank < secondCard.Rank) : false;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }

        public static bool operator >(Card firstCard, Card secondCard)
        {
            var result = false;
            if (!firstCard.IsTrump)
            {
                result = true ? (firstCard == secondCard &&
                firstCard.Rank > secondCard.Rank) : false;
            }
            else
            {
                if (secondCard.IsTrump)
                {
                    result = true ? (firstCard.Rank > secondCard.Rank) : false;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }

        public static bool operator ==(Card firstCard, Card secondCard) =>
            true ? (firstCard.Suit == secondCard.Suit) : false;
        public static bool operator !=(Card firstCard, Card secondCard) =>
            true ? (firstCard.Suit != secondCard.Suit) : false;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return Suit ^ Rank;
        }

        public override string ToString()
        {
            return ((CardSuit)Suit).ToString() + " " + ((CardRank)Rank).ToString();
        }

        int IComparable<Card>.CompareTo(Card other)
        {
            if (other is null) throw new ArgumentNullException("", nameof(other));
            else
            {
                return (Suit).CompareTo(other.Suit);
            }
        }

        #endregion
    }
}
