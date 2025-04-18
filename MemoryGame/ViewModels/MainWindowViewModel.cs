using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MemoryGame.Models;
using System.Windows.Input;
using System.Windows;
using MemoryGame.Services;
using MemoryGame.Views;

namespace MemoryGame.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private User _currentUser;

    public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

    public User CurrentUser
    {
        get => _currentUser;
        set
        {
            _currentUser = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsUserSelected));
            OnPropertyChanged(nameof(LogText));
            OnPropertyChanged(nameof(NumGamesWon));
            OnPropertyChanged(nameof(NumGamesPlayed));
            OnPropertyChanged(nameof(CurrentProfilePicture));
        }
    }

    public bool IsUserSelected => CurrentUser != null;

    public string LogText => CurrentUser != null ? $"Logged in as: {CurrentUser.Name}" : "No one is logged in.";
    public string NumGamesWon => CurrentUser != null ? $"Games Won: {CurrentUser.GamesWon}" : string.Empty;
    public string NumGamesPlayed => CurrentUser != null ? $"Games Played: {CurrentUser.GamesPlayed}" : string.Empty;

    public string CurrentProfilePicture => CurrentUser != null ? CurrentUser.ProfilePicture : string.Empty;

    public ICommand AddUserCommand { get; }
    public ICommand RemoveUserCommand { get; }
    public ICommand StartGameCommand { get; }
    public ICommand ExitCommand { get; }

    public MainWindowViewModel()
    {
        var loadedUsers = UserStorageService.LoadUsers();
        Users = new ObservableCollection<User>(loadedUsers);
        AddUserCommand = new RelayCommand(_ => AddUser());
        RemoveUserCommand = new RelayCommand(_ => RemoveUser());
        StartGameCommand = new RelayCommand(_ => StartGame());
        ExitCommand = new RelayCommand(_ => ExitApp());
    }

    private void AddUser()
    {
        var user = new ValidateUser(Users); 
        user.ShowDialog();
        if (user.NewUser != null)
        {
            Users.Add(user.NewUser);
            UserStorageService.SaveUsers(Users.ToList());
        }
    }

    private void RemoveUser()
    {
        if (!IsUserSelected)
        {
            MessageBox.Show("No user selected to remove.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (MessageBox.Show($"Are you sure you want to delete user {CurrentUser.Name}?",
            "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            Users.Remove(CurrentUser);
            UserStorageService.SaveUsers(Users.ToList());
            CurrentUser = null;
        }
    }

    private void StartGame()
    {
        //MessageBox.Show("Game started!");
        if (!IsUserSelected)
        {
            MessageBox.Show("Please select a user to start the game.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        var game = new Game(CurrentUser);
        game.ShowDialog();
        OnPropertyChanged(nameof(NumGamesWon));
        OnPropertyChanged(nameof(NumGamesPlayed));
        UserStorageService.SaveUsers(Users.ToList());
    }

    private void ExitApp()
    {
        Application.Current.Shutdown();
    }

    public void SelectUser(User selectedUser)
    {
        var dialog = new ValidateUser(Users, selectedUser);
        bool? result = dialog.ShowDialog();

        if (result == true && dialog.UserValidated())
        {
            CurrentUser = selectedUser;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}