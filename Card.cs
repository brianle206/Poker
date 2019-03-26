using CsharpPoker;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPoker
{
    public class Card
    {
        public Card(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }
        public CardValue Value { get; }
        public CardSuit Suit { get; }
        public override string ToString() => $"{Value} of {Suit}";
       
    }
}
