using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System;
using System.IO;
using MemoryGame.Models;
using MemoryGame;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Timers;
using Newtonsoft.Json;

namespace MemoryGame.ViewModels;

public class GameViewModel : INotifyPropertyChanged
{
    public ObservableCollection<GameCard> Cards { get; set; }
    private User ActiveUser { get; set; }
    private bool GameStarted { get; set; } = false;

    public ICommand FlipCardCommand { get; }

    private bool _canFlip = true;
    private GameCard _firstFlippedCard = null;
    private GameCard _secondFlippedCard = null;

    private System.Timers.Timer _timer;
    private int _remainingSeconds;
    private int StartingSeconds = 120;
    public string ElapsedTime => TimeSpan.FromSeconds(_remainingSeconds).ToString(@"mm\:ss");

    public Action<bool?> CloseAction { get; set; }

    public GameViewModel(User activeUser)
    {
        FlipCardCommand = new RelayCommand(FlipCard, CanFlipCard);
        ActiveUser = activeUser;
        LoadPictures();
    }

    public void StartGame(int seconds)
    {
        GameStarted = true;
        StartingSeconds = seconds;
        StartTimer();
    }

    public void SaveGame()
    {
        var gameState = new
        {
            ActiveUser = ActiveUser.Name,
            Cards = Cards,
            RemainingTime = _remainingSeconds,
            FirstFlippedCard = _firstFlippedCard?.ID,
            SecondFlippedCard = _secondFlippedCard?.ID
        };

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "SavedGames", $"{ActiveUser.Name}_game.json");

        string directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        string json = JsonConvert.SerializeObject(gameState, Formatting.Indented);
        File.WriteAllText(filePath, json);
        MessageBox.Show("Game saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    public bool LoadGame()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "SavedGames", $"{ActiveUser.Name}_game.json");

        if (!File.Exists(filePath))
        {
            MessageBox.Show("No saved game found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false; 
        }

        string json = File.ReadAllText(filePath);
        var gameState = JsonConvert.DeserializeObject<dynamic>(json);

        if (gameState == null)
        {
            return false;
        }

        GameStarted = true;
        StartingSeconds = gameState.RemainingTime;

        _firstFlippedCard = null;
        _secondFlippedCard = null;

        var savedCards = ((IEnumerable<dynamic>)gameState.Cards).Select(c => new GameCard
        {
            ID = (int)c.ID,
            IsFlipped = c.IsFlipped,
            ImagePath = c.ImagePath
        }).ToList();

        foreach (var card in Cards)
        {
            var savedCard = savedCards.FirstOrDefault(c => c.ID == card.ID);
            if (savedCard != null)
            {
                card.IsFlipped = savedCard.IsFlipped;
            }
        }

        StartTimer();

        return true;
    }


    private bool CanFlipCard(object parameter)
    {
        return GameStarted && _canFlip && parameter is GameCard card && !card.IsFlipped;
    }

    private async void FlipCard(object parameter)
    {
        if (!_canFlip || parameter is not GameCard card || card.IsFlipped)
            return;

        card.IsFlipped = true;

        if (_firstFlippedCard == null)
        {
            _firstFlippedCard = card;
        }
        else if (_secondFlippedCard == null && card != _firstFlippedCard)
        {
            _secondFlippedCard = card;
            _canFlip = false;

            await Task.Delay(800);

            if (_firstFlippedCard.ID == _secondFlippedCard.ID)
            {
                _firstFlippedCard = null;
                _secondFlippedCard = null;
            }
            else
            {
                _firstFlippedCard.IsFlipped = false;
                _secondFlippedCard.IsFlipped = false;
                _firstFlippedCard = null;
                _secondFlippedCard = null;
            }

            _canFlip = true;
            CheckForWin();
        }

        CommandManager.InvalidateRequerySuggested();
    }

    private void LoadPictures()
    {
        string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "GameCards");

        if (Directory.Exists(imageFolder))
        {
            var imageFiles = Directory.GetFiles(imageFolder, "*.*")
                .Where(f =>
                    (f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                     f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)) &&
                    !string.Equals(Path.GetFileNameWithoutExtension(f), "QMark", StringComparison.OrdinalIgnoreCase))
                .OrderBy(_ => Guid.NewGuid())
                .ToList();

            var items = new ObservableCollection<GameCard>();

            for (int i = 0; i < imageFiles.Count; i++)
            {
                var path = imageFiles[i];
                items.Add(new GameCard { ID = i, ImagePath = path });
                items.Add(new GameCard { ID = i, ImagePath = path });
            }

            var shuffled = items.OrderBy(_ => Guid.NewGuid()).ToList();
            Cards = new ObservableCollection<GameCard>(shuffled);
        }
        else
        {
            Cards = new ObservableCollection<GameCard>();
        }
    }

    private void GameOver()
    {
        _canFlip = false;

        App.Current.Dispatcher.Invoke(() =>
        {
            System.Windows.MessageBox.Show("Time's up! Game over.");
            ActiveUser.GamesPlayed++;
            CloseAction?.Invoke(true);
        });
    }

    private void StartTimer()
    {
        _remainingSeconds = StartingSeconds;
        OnPropertyChanged(nameof(ElapsedTime));

        _timer = new System.Timers.Timer(1000); // 1 second
        _timer.Elapsed += (s, e) =>
        {
            _remainingSeconds--;
            OnPropertyChanged(nameof(ElapsedTime));

            if (_remainingSeconds <= 0)
            {
                _timer.Stop();
                _timer.Dispose();
                _timer = null;

                GameOver();
            }
        };
        _timer.Start();
    }

    public void StopTimer()
    {
        _timer?.Stop();
        _timer?.Dispose();
        _timer = null;
    }

    private void CheckForWin()
    {
        if (Cards.All(c => c.IsFlipped))
        {
            StopTimer();
            App.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show("You won the game!");
                ActiveUser.GamesWon++;
                ActiveUser.GamesPlayed++;
                CloseAction?.Invoke(true);
            });
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
