﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scavenger.Server.Domain
{
    public class Position : INotifyPropertyChanged
    {
        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }
        private double _y;
        private double _x;

        public double X
        {
            get { return _x; }
            set {
                if (_x.Equals(value)) return;
                _x = value;
                NotifyPropertyChanged("X");
            }
        }

        public double Y
        {
            get { return _y; }
            set
            {
                if (_y.Equals(value)) return;
                _y = value;
                NotifyPropertyChanged("Y");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Position);
        }

        private bool Equals(Position other)
        {
            return _y.Equals(other._y) && _x.Equals(other._x);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_y.GetHashCode()*397) ^ _x.GetHashCode();
            }
        }
    }
}
