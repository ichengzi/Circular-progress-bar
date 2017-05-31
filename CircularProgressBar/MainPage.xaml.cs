using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.ComponentModel;

namespace CircularProgressBar
{
    public partial class MainPage : UserControl, INotifyPropertyChanged
    {
        private double _value = 100.0;

        public double Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChanged("Value"); }
        }

        private DispatcherTimer _timer;

        public MainPage()
        {
            InitializeComponent();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(50);
            _timer.Tick += new EventHandler(Timer_Tick);
            _timer.Start();

            this.DataContext = this;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (pauseButton.IsChecked != null && pauseButton.IsChecked.Value)
                return;

            //double newValue = Value + 0.7;
            //if (newValue > 100)
            //    newValue = 0;
            //Value = newValue;
            double newValue = Value - 0.7;
            if (newValue < 0)
                newValue = 100;
            Value = newValue;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion
    }
}
