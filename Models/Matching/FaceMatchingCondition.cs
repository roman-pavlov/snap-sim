namespace SnapSimulator.Models.Matching
{
    public class FaceMatchingCondition : IMatchingCondition
    {
        public bool Match(PlayingCard cardLeft, PlayingCard cardRight)
        {
            return cardLeft.FaceValue == cardRight.FaceValue;
        }
    }
}