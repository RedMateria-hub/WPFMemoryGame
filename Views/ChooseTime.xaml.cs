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

namespace MemoryGame.Views
{
    /// <summary>
    /// Interaction logic for ChooseTime.xaml
    /// </summary>
    public partial class ChooseTime : Window
    {
        public int seconds = 0;
        public ChooseTime()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TimeBlock.Text, out seconds))
            {
                if (seconds <= 0)
                {
                    MessageBox.Show("Please enter a time greater than 0");
                    return;
                }
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric time");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
