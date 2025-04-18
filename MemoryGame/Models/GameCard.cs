using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Models
{
    public class GameCard : INotifyPropertyChanged
    {
        private bool _isFlipped;

        public string ImagePath { get; set; }
        public int ID { get; set; }

        public bool IsFlipped
        {
            get => _isFlipped;
            set
            {
                if (_isFlipped != value)
                {
                    _isFlipped = value;
                    OnPropertyChanged(nameof(DisplayedImage));
                }
            }
        }

        public string DisplayedImage => IsFlipped
            ? ImagePath
            : "pack://siteoforigin:,,,/Resources/GameCards/QMark.png";

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
