using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using SnapSimulator.Models;
using SnapSimulator.Models.Matching;

namespace SnapSimulator.ViewModels
{
    public class SimulationViewModel : BindableBase, IDataErrorInfo
    {
        private int _cardPacksCount;
        private MatchingConditionViewModel _selectedMatchingCondition;
        private const string TitleFormat = "Player ({0}) cards:";
        private static readonly Random random = new Random();

        public SimulationViewModel()
        {
            Title = "Snap! Simulator";
            PlayerBTitle = PlayerATitle = "Cards:";
            ActivePlayerName = "N/A";
            CardPacksCount = 1;
            IntializeMatchingConditions();
            CanSimulate = true;
            SimulateCommand = new DelegateCommand(OnSimulate);
        }

        private bool _canSimulate;
        public bool CanSimulate
        {
            get { return _canSimulate; }
            set { SetProperty(ref _canSimulate, value); }
        }

        public string Title { get; private set; }

        public int CardPacksCount
        {
            get { return _cardPacksCount; }
            set { SetProperty(ref _cardPacksCount, value); }
        }

        public IList<MatchingConditionViewModel> MatchingConditions
        {
            get; private set;
        }

        public MatchingConditionViewModel SelectedMatchingCondition
        {
            get { return _selectedMatchingCondition; }
            set { SetProperty(ref _selectedMatchingCondition, value); }
        }

        public ICommand SimulateCommand { get; private set; }

        private string _playerATitle;
        public string PlayerATitle
        {
            get { return _playerATitle; }
            set { SetProperty(ref _playerATitle, value); }
        }
        private string _playerBTitle;
        public string PlayerBTitle
        {
            get { return _playerBTitle; }
            set { SetProperty(ref _playerBTitle, value); }
        }

        private string _activePlayerName;
        public string ActivePlayerName
        {
            get { return _activePlayerName; }
            set { SetProperty(ref _activePlayerName, value); }
        }

        private int _playerATotalCards;
        public int PlayerATotalCards
        {
            get { return _playerATotalCards; }
            set { SetProperty(ref _playerATotalCards, value); }
        }
        private int _playerBTotalCards;
        public int PlayerBTotalCards
        {
            get { return _playerBTotalCards; }
            set { SetProperty(ref _playerBTotalCards, value); }
        }
        private string _newFaceUpCardFace;
        public string NewFaceUpCardFace
        {
            get { return _newFaceUpCardFace; }
            set { SetProperty(ref _newFaceUpCardFace, value); }
        }
        private string _topFaceUpCardFace;
        public string TopFaceUpCardFace
        {
            get { return _topFaceUpCardFace; }
            set { SetProperty(ref _topFaceUpCardFace, value); }
        }

        private int _round;
        public int Round
        {
            get { return _round; }
            set { SetProperty(ref _round, value); }
        }
        private int _winnerIndex;
        public int WinnerIndex
        {
            get { return _winnerIndex; }
            set { SetProperty(ref _winnerIndex, value); }
        }

        private async void OnSimulate()
        {
            CanSimulate = false;
            await Task.Run(() => Simulate());
            CanSimulate = true;
        }

        private void Simulate()
        {
            var game = new Game(CardPacksCount, SelectedMatchingCondition.MatchingCondition, "Roman", "Valerie");
            PlayerATitle = string.Format(TitleFormat, game.PlayerA.Name);
            PlayerBTitle = string.Format(TitleFormat, game.PlayerB.Name);
            WinnerIndex = 0;

            // Simulation loop
            while (game.CanPlay())
            {
                game.PlayRound();
                Thread.Sleep(1000);// a pause
                if (game.Snap())
                {
                    game.AwardWithAPile(random.Next(game.PlayersCount));
                }
                UpdateVmState(game);
            }

            if (PlayerATotalCards != PlayerBTotalCards)
            {
                // Determine a winner
                WinnerIndex = PlayerATotalCards > PlayerBTotalCards ? 1 : 2;
            }
        }

        private void UpdateVmState(Game game)
        {
            ActivePlayerName = game.ActivePlayer.Name;
            PlayerATotalCards = game.PlayerA.OwnedCards.Count;
            PlayerBTotalCards = game.PlayerB.OwnedCards.Count;
            Round = game.Round;
            NewFaceUpCardFace = game.NewFaceUpCard.GetFaceValue();
            TopFaceUpCardFace = game.TopFaceUpCard.GetFaceValue();
        }
        private void IntializeMatchingConditions()
        {
            var matchingConditionsList = new List<IMatchingCondition>()
            {
                new FaceMatchingCondition(),
                new SuiteMatchingCondition()
            };

            MatchingConditions = new List<MatchingConditionViewModel>()
            {
                new MatchingConditionViewModel(matchingConditionsList[0], "Face Value"),
                new MatchingConditionViewModel(matchingConditionsList[1], "Suite"),
                new MatchingConditionViewModel(new CompoundMatchingCondition(matchingConditionsList), "Both"),
            };
            SelectedMatchingCondition = MatchingConditions[0];
        }

        #region IDataErrorInfo
        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
                var result = String.Empty;
                if (columnName == "CardPacksCount" && (CardPacksCount < 1))
                {
                    result = "Set cards pack > 0";
                }
                return result;
            }
        }
        #endregion
    }
}
