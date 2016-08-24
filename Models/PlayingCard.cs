namespace SnapSimulator.Models
{
    public struct PlayingCard
    {
        public PlayingCard(CardFaceValue faceValue, CardSuite suite)
        {
            FaceValue = faceValue;
            Suite = suite;
        }

        public CardFaceValue FaceValue { get; private set; }
        public CardSuite Suite { get; private set; }
        public string GetFaceValue()
        {
            return $"{Suite.ToString()[0]} ({FaceValue})";
        }
    }

    public enum CardFaceValue
    {
        Ace = 1,
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
        King
    }

    public enum CardSuite
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
}