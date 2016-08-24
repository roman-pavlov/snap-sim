namespace SnapSimulator.Models.Matching
{
    public interface IMatchingCondition
    {
        bool Match(PlayingCard cardLeft, PlayingCard cardRight);
    }
}