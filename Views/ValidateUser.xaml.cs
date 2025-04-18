using System;
using System.Collections.ObjectModel;
using System.Windows;
using MemoryGame.Models;
using MemoryGame.ViewModels;

namespace MemoryGame
{
    public partial class ValidateUser : Window
    {
        public User NewUser => ((ValidateUserViewModel)DataContext).NewUser;

        public ValidateUser(ObservableCollection<User> users, User user = null)
        {
            InitializeComponent();

            var vm = new ValidateUserViewModel(users, user);
            vm.CloseAction = Close;
            DataContext = vm;
        }

        private void PrevImage_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ValidateUserViewModel vm)
                vm.PreviousPicture();
        }

        private void NextImage_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ValidateUserViewModel vm)
                vm.NextPicture();
        }

        private void Close(bool? result)
        {
            DialogResult = result;
            Close();
        }

        public bool UserValidated()
        {
            if (DataContext is ValidateUserViewModel vm)
            {
                return vm.IsValidated;
            }
            return false;
        }
    }
}
