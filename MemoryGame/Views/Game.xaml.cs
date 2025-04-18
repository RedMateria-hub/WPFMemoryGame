using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MemoryGame.Models;
using MemoryGame.ViewModels;

namespace MemoryGame.Views
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private GameViewModel _viewModel;
        public Game(User user = null)
        {
            InitializeComponent();
            _viewModel = new GameViewModel(user);
            _viewModel.CloseAction = Close;
            DataContext = _viewModel;
            this.Closed += OnWindowClosed;
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            _viewModel.StopTimer(); 
        }

        private void Close(bool? result)
        {
            DialogResult = result;
            Close();
        }

        private void Command_StartGame(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as GameViewModel;
            var time = new ChooseTime();
            time.ShowDialog();
            if (time.seconds <= 0)
                return;
            vm.StartGame(time.seconds);
        }

        private void Command_SaveGame(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as GameViewModel;
            vm.SaveGame();
        }

        private void Command_LoadGame(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as GameViewModel;
            vm.LoadGame();
        }

        private void Command_About(object sender, RoutedEventArgs e)
        {
            var about = new AboutWindow();
            about.Show();
        }

        private void Command_Stats(object sender, RoutedEventArgs e)
        {
            var stats = new StatisticsWindow();
            stats.Show();
        }
    }
}
