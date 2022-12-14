using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfApp2
{
    
    public class Customer : INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        //Данные о задаче
        private string name;
        private string task;
        private int price;
        private DateTime deadline;
        private bool isSolved;

        public Customer(string name, string task, int price, DateTime deadline)
        {
            this.name = name;
            this.task = task;
            this.price = price;
            this.deadline = deadline;
            this.isSolved = false;
        }

        //Getters and Setters

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Task
        {
            get
            {
                return this.task;
            }
        }

        public int Price
        {
            get
            {
                return this.price;
            }
        }

        public string DeadlineString
        {
            get
            {
                return $"{this.deadline.Day}.{this.deadline.Month}.{this.deadline.Year}";
            }
        }


        public bool IsSolved
        {
            get
            {
                return this.isSolved;
            }
            set
            {
                this.isSolved = value;
                OnPropertyChanged("IsSolved"); //Если свойство меняется, вызывается метод, который уведомляет об изменении модели
                OnPropertyChanged("Color"); //Если изменено несколько значений, можно вызвать дополнительный метод
            }
        }


        public string Color
        {
            get
            {
                //Если задача решена, будет возвращён синий цвет, иначе он будет зависеть от того, прошёл ли дедлайн
                return this.isSolved ? "Blue" : DateTime.Now.CompareTo(this.deadline) == -1 ? "Black" : "Red";
                // (condition) ? if true : else
            }
        }

        public event PropertyChangedEventHandler PropertyChanged; //Событие, которое будет вызвано при изменении модели

        //Метод, который скажет ViewModel, что нужно передать виду новые данные
        public void OnPropertyChanged([CallerMemberName] string prop = "")     
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
