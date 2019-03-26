using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpPoker
{
    public class Hand
    {
        public Hand()
        {
            Cards = new List<Card>();
        }
        public List<Card> Cards { get; }

        public void Draw(Card card)
        {
            Cards.Add(card);
        }

        public Card HighCard()
        {

            return Cards.OrderByDescending(x => x.Value).FirstOrDefault();
        }
    }
}
