using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SnapSimulator.Models
{
    public class CardsStandardPack : List<PlayingCard>
    {
        public CardsStandardPack()
        {
            IntializePack();
        }

        private void IntializePack()
        {
            // Loop all suites and face values
            foreach (var suite in Enum.GetValues(typeof(CardSuite)).Cast<CardSuite>())
            {
                foreach (var faceValue in Enum.GetValues(typeof(CardFaceValue)).Cast<CardFaceValue>())
                {
                    Add(new PlayingCard(faceValue, suite));
                }
            }
            Debug.Assert(Count == 52);
        }

        public void Shuffle()
        {
            var rng = new Random();
            var index = Count;
            while (index > 1)
            {
                index--;
                var randIndex = rng.Next(index + 1);
                var card = this[randIndex];
                this[randIndex] = this[index];
                this[index] = card;
            }
        }
    }
}
