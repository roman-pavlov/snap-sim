using System.Collections.Generic;

namespace SnapSimulator.Models
{
    public class Player
    {
        public Player(string name)
        {
            OwnedCards = new List<PlayingCard>();
            Name = name;
        }
        public void TakePile(IEnumerable<PlayingCard> pile)
        {
            foreach (var card in pile)
                OwnedCards.Add(card);
        }

        public ICollection<PlayingCard> OwnedCards { get;  }
        public string Name { get; private set; }
    }
}
