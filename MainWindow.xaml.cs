using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab10
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> _users = new ObservableCollection<User>(); //nie obserwuje czy obiekt był edytowany
        public MainWindow()
        {
            InitializeComponent();
            UserList.ItemsSource = _users;
            new FileWatcher().Show(); //pokazuje nowe okno

        }

        //potrojny slesh co to oznacza dla kodu?
        /// <summary>
        /// dodaj
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var counter = 1;
            if (_users.Any())
            {
                counter = _users.Max(x => x?.Id + 1 ?? 1); //jezeli by nie było ifa to wywala wyjatek bo za pierwsyzm uruchomieniem w kolekcji users nie ma nic
            }
            _users.Add(new User(
                counter,
                $"login{counter}",
                $"password{counter}",
                0));
        }
        /// <summary>
        /// Edytuj
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_users.Any())
            {
                var user = _users[0];
                user.Points += 100;
            }
        }
        /// <summary>
        /// Usuń
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (_users.Any())
            {
                _users.RemoveAt(0);
            }
        }
    }
}
