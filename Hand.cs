using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsharpPoker;


namespace CsharpPoker
{
    public class Hand
    {
        
        private readonly List<Card> cards = new List<Card>();

        public IEnumerable<Card> Cards => cards;

        public void Draw(Card card) => cards.Add(card);


        public Card HighCard() => Cards.Aggregate((result, nextCard) => result.Value > nextCard.Value ? result : nextCard);
        

        public HandRank GetHandRank()
        {
            if (HasRoyalFlush()) return HandRank.RoyalFlush;
            if (HasFlush()) return HandRank.Flush;
            if (HasFourOfAKind()) return HandRank.FourOfAKind;
            if (HasFullHouse()) return HandRank.FullHouse;
            if (HasThreeOfAKind()) return HandRank.ThreeOfAKind;
            if (HasPair()) return HandRank.Pair;
        
            return HandRank.HighCard;
        }
        private bool HasFlush() => Cards.All(c => Cards.First().Suit == c.Suit);
        private bool HasRoyalFlush() => HasFlush() && Cards.All(c => c.Value > CardValue.Nine);
        private bool HasOfAKind(int num) => cards.ToKindAndQuantities().Any(c => c.Value == num);
        private bool HasPair() => HasOfAKind(2);
        private bool HasThreeOfAKind() => HasOfAKind(3);
        private bool HasFourOfAKind() => HasOfAKind(4);
        private bool HasFullHouse() => HasPair() && HasThreeOfAKind();
        private bool HasStraight()
        {
            var hand = Cards.OrderByDescending(c => c.Value).Reverse();
            var re = hand.Select((i,j) => i.Value-j.Value).Distinct().Skip(1).Any();
            
        }

       
    }
}
