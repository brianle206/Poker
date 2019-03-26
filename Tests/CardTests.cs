using CsharpPoker;
using System;
using System.Linq;
using Xunit;

public class CardTests
{
	[Fact]
    public void CanCreateCardWithValue()
    {
        var card = new Card(CardValue.Ace, CardSuit.Clubs);
        Assert.Equal(CardSuit.Clubs, card.Suit);
        Assert.Equal(CardValue.Ace, card.Value);
    }

    [Fact]
    public void CanDescribeCard()
    {
        var card = new Card(CardValue.Ace, CardSuit.Spades);

        Assert.Equal("Ace of Spades", card.ToString());
    }

    [Fact]
    public void CanCreatehand()
    {
        var hand = new Hand();
        Assert.False(hand.Cards.Any());
    }

    [Fact]
    public void CanHandDrawCard()
    {
        var card = new Card(CardValue.Ace, CardSuit.Spades);
        var hand = new Hand();

        hand.Draw(card);
        Assert.Equal(hand.Cards.First(), card);
    }

    [Fact]
    public void CanGetHighCard()
    {
        var hand = new Hand();
        hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));
        Assert.Equal(CardValue.King, hand.HighCard().Value);
    }
}
