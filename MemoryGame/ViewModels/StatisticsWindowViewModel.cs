using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MemoryGame.Models;
using MemoryGame.Services;

namespace MemoryGame.ViewModels
{
    class StatisticsWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public StatisticsWindowViewModel()
        {
            var loadedUsers = UserStorageService.LoadUsers();
            Users = new ObservableCollection<User>(loadedUsers);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
