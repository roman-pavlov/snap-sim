using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnapSimulator.Models.Matching;

namespace SnapSimulator.Models
{
    public class Game
    {
        private readonly IMatchingCondition _matchingCondition;
        private readonly IList<Player> _players;
        private readonly IList<CardsStandardPack> _cardPacks;
        private int _activePlayerIndex;

        public Stack<PlayingCard> FaceDownPile { get; private set; }
        public Stack<PlayingCard> FaceUpPile { get; private set; }
        public Player ActivePlayer { get; private set; }
        public Player PlayerA => _players[0];
        public Player PlayerB => _players[1];
        public PlayingCard NewFaceUpCard { get; private set; }
        public PlayingCard TopFaceUpCard { get; private set; }
        public int Round { get; private set; }

        public int PlayersCount => 2;

        public Game(int cardPacksCount, IMatchingCondition matchingCondition, string playerA, string playerB)
        {
            if (cardPacksCount <= 0)
                throw new ArgumentException("cardPacksCount");
            if (matchingCondition == null)
                throw new ArgumentNullException("matchingCondition");

            _matchingCondition = matchingCondition;

            //Setup card packs
            _cardPacks = new List<CardsStandardPack>(cardPacksCount);
            for (var i = 0; i < cardPacksCount; i++)
                _cardPacks.Add(new CardsStandardPack());

            // Setup players
            _players = new List<Player>(PlayersCount);
            _players.Add(new Player(playerA));
            _players.Add(new Player(playerB));

            // Setup game
            ShuffleCards();
            DealCards();

        }

        public void PlayRound()
        {
            Round++;
            ActivePlayer = GetNextPlayer();
            NewFaceUpCard = FaceDownPile.Pop();

            if (FaceUpPile.Count > 0)
            {
                TopFaceUpCard = FaceUpPile.Peek();
            }
            FaceUpPile.Push(NewFaceUpCard);
        }

        public bool CanPlay()
        {
            return FaceDownPile.Count > 0;
        }
        public bool Snap()
        {
            return (Round > 0) && _matchingCondition.Match(TopFaceUpCard, NewFaceUpCard);
        }

        public void AwardWithAPile(int playerIndex)
        {
            if (playerIndex < 0 || playerIndex >= _players.Count)
                throw new ArgumentException("playerIndex");

            var awardingPlayer = _players[playerIndex];
            awardingPlayer.TakePile(FaceUpPile);

            FaceUpPile.Clear();
        }

        private void ShuffleCards()
        {
            Parallel.ForEach(_cardPacks, pack => pack.Shuffle());
        }

        private void DealCards()
        {
            FaceDownPile = new Stack<PlayingCard>(_cardPacks.SelectMany(pack => pack));
            FaceUpPile = new Stack<PlayingCard>();
        }

        private Player GetNextPlayer()
        {
            _activePlayerIndex = (++_activePlayerIndex == _players.Count) ? 0 : _activePlayerIndex;
            return _players[_activePlayerIndex];
        }

    }
}


