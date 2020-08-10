namespace PokerShowdown
{
    /// <summary>
    /// <c>Suit</c> represents the <c>Card</c> colour and symbol
    /// </summary>
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    /// <summary>
    /// <c>Rank</c> represents the value of a <c>Card</c>
    /// </summary>
    public enum Rank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    /// <summary>
    /// <c>Card</c> represents a typical playing card with a <c>Suit</c> and <c>Rank</c>
    /// </summary>
    public class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
    }
}
