namespace PokerShowdown
{
    /// <summary>
    /// <c>Player</c> represents a player, can have a <c>Name</c> and <c>Hand</c>
    /// </summary>
    public class Player
    {
        public Hand Hand { get; set; }
        public string Name { get; set; }
    }
}
