using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using MemoryGame.Models;

namespace MemoryGame.ViewModels
{
    public class ValidateUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private string _password;
        private bool _canSetName;
        private bool _IsValidated;
        private string _title;
        private string _okButtonText;
        private ObservableCollection<User> Users { get; set; }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public bool CanSetName
        {
            get => _canSetName;
            set { _canSetName = value; OnPropertyChanged(); }
        }

        public bool IsValidated
        {
            get => _IsValidated;
            set { _IsValidated = value; OnPropertyChanged(); }
        }

        public string TitleText
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }

        public string OkButtonText
        {
            get => _okButtonText;
            set { _okButtonText = value; OnPropertyChanged(); }
        }

        public User ExistingUser { get; }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public Action<bool?> CloseAction { get; set; }

        public User NewUser { get; private set; }

        public ValidateUserViewModel(ObservableCollection<User> users, User user = null)
        {
            ExistingUser = user;
            SubmitCommand = new RelayCommand(_ => Submit());
            CancelCommand = new RelayCommand(_ => CloseAction?.Invoke(false));
            IsValidated = false;
            Users = users;
            LoadProfilePictures();

            if (user == null)
            {
                CanSetName = true;
                TitleText = "Enter a new user";
                OkButtonText = "Add";
            }
            else
            {
                CanSetName = false;
                TitleText = "Please enter password:";
                OkButtonText = "OK";
                Name = user.Name;
            }
        }

        private void Submit()
        {
            if (CanSetName)
            {
                if (Users.Any(u => u.Name.Equals(Name, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("A user with this name already exists. Please choose a different name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Password))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                NewUser = new User(Name, Password, SelectedProfilePicture);
                MessageBox.Show("User has been successfully added.");
                CloseAction?.Invoke(true);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Password))
                {
                    MessageBox.Show("Please fill in the password.");
                    return;
                }

                if (Password != ExistingUser.Password)
                {
                    MessageBox.Show("Password is incorrect.");
                    return;
                }

                IsValidated = true;
                NewUser = ExistingUser;
                CloseAction?.Invoke(true);
            }
        }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public ObservableCollection<string> ProfilePictures { get; set; }
        private int _currentPicIndex;
        public string SelectedProfilePicture
        {
            get => ProfilePictures.Count > 0 ? ProfilePictures[_currentPicIndex] : null;
        }

        public void NextPicture()
        {
            if (ProfilePictures.Count == 0) return;
            _currentPicIndex = (_currentPicIndex + 1) % ProfilePictures.Count;
            UpdateSelectedPicture();
        }

        public void PreviousPicture()
        {
            if (ProfilePictures.Count == 0) return;
            _currentPicIndex = (_currentPicIndex - 1 + ProfilePictures.Count) % ProfilePictures.Count;
            UpdateSelectedPicture();
        }

        private void UpdateSelectedPicture()
        {
            if (NewUser != null) NewUser.ProfilePicture = SelectedProfilePicture;
            OnPropertyChanged(nameof(SelectedProfilePicture));
        }

        private void LoadProfilePictures()
        {
            ProfilePictures = new ObservableCollection<string>();

            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ProfilePics");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            foreach (var file in Directory.GetFiles(folderPath))
            {
                string extension = Path.GetExtension(file).ToLower();
                if (extension == ".png" || extension == ".jpg" || extension == ".jpeg")
                {
                    string fileName = Path.GetFileName(file);
                    ProfilePictures.Add($"pack://siteoforigin:,,,/Resources/ProfilePics/{fileName}");
                }
            }

            _currentPicIndex = 0;
        }

    }
}
