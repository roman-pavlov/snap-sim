namespace SnapSimulator.Models.Matching
{
    public class SuiteMatchingCondition : IMatchingCondition
    {
        public bool Match(PlayingCard cardLeft, PlayingCard cardRight)
        {
            return cardLeft.Suite == cardRight.Suite;
        }
    }
}