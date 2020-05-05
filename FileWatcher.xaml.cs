using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Lab10
{
    /// <summary>
    /// Logika interakcji dla klasy FileWatcher.xaml
    /// </summary>
    public partial class FileWatcher : Window
    {
        private FileContent _fIleContent = new FileContent();
        private FileSystemWatcher _watcher = new FileSystemWatcher();
        public FileWatcher()
        {
            InitializeComponent();
            fileContentTextBox.DataContext = _fIleContent;
            _watcher.NotifyFilter = NotifyFilters.LastWrite;
            _watcher.Changed += _watcher_Changed;
        }
        private void _watcher_Changed(object sender, FileSystemEventArgs e)
        {
            LoadFile();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Wybierz plik do obserwowania",
                Filter= "Textfile|*.txt" //filter na pliki tekstowe (sprawdz czemu textfile na poczatkuw  nazwie a nie sama*.txt
            };
            var result=openFileDialog.ShowDialog(this);//przyjmuje ownera czyli this (czyli ze chyba ma wyswietlic wyszukiwanie pliku jako czesc fileWatcher.xaml.cs
            if (!result.HasValue|| !result.Value)//=>!(result.HasValue&&result.Value) #PTC
            {
                return;
            }
            _fIleContent.Path = openFileDialog.FileName;
            _watcher.Path = openFileDialog.FileName.Replace(openFileDialog.SafeFileName, string.Empty); ///chce katalog stad ten replace
            _watcher.EnableRaisingEvents = true;
            LoadFile( );

        }
        private void LoadFile()
        {
            var text = File.ReadAllText(_fIleContent.Path);
            //fileContentTextBox.Text = text;
            _fIleContent.Content = text; //powizane z_fIleContent na gorze + konstruktor 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoadFile();

        }
    }
}
