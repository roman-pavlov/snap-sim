using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SnapSimulator.Models.Matching
{
    public class CompoundMatchingCondition : IMatchingCondition
    {
        private readonly IList<IMatchingCondition> _conditions;

        public CompoundMatchingCondition(IList<IMatchingCondition> conditions)
        {
            _conditions = conditions;
        }
        public bool Match(PlayingCard cardLeft, PlayingCard cardRight)
        {
            return _conditions.All(mc => mc.Match(cardLeft, cardRight));
        }
    }
}