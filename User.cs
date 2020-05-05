using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class User: INotifyPropertyChanged
    {
        public User(int id, string login, string pass, int points)
        {
            Id = id;
            Login = login;
            Password = pass;
            Points = points;
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        //public int Points { get; set; }
        private  int _points;

        public int Points
        {
            get { return _points; }
            set {
                if (_points != value )
                {
                    _points = value;
                    //sprawdzić działanie ?.Invoke <--- wywołuje to funkcje, ale czym sie rozni od normalengo wywołania
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Points"));
                }
               }
        }


        public event PropertyChangedEventHandler PropertyChanged; // za kazdym razem gdy ten event jest uruchamiany to interejs otrzymuej informacje ze dane sie zmieniły i trzeba to odświeżyć
    }
}
