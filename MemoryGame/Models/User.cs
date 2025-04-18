using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Models
{
    public class User : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Password { get; set; }   
        public string ProfilePicture { get; set; }
        public int GamesWon { get; set; }
        public int GamesPlayed { get; set; }
        public User(string name, string password, string profilePicture)
        {
            Name = name;
            Password = password;
            ProfilePicture = profilePicture;
            GamesWon = 0;
            GamesPlayed = 0;
        }
        public void AddGameWon()
        {
            GamesWon++;
        }
        public void AddGamePlayed()
        {
            GamesPlayed++;
        }
        public override string ToString()
        {
            return $"{Name}\nGames Won: {GamesWon}\nGames Played: {GamesPlayed}\n";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
