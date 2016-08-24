using Prism.Mvvm;
using SnapSimulator.Models.Matching;

namespace SnapSimulator.ViewModels
{
    public class MatchingConditionViewModel : BindableBase
    {
        public MatchingConditionViewModel(IMatchingCondition matchingCondition, string title)
        {
            MatchingCondition = matchingCondition;
            Title = title;
        }
        public IMatchingCondition MatchingCondition { get; private set; }

        public string Title { get; private set; }
    }
}