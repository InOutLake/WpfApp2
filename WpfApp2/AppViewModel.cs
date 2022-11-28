using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfApp2
{

    public class AppViewModel: INotifyPropertyChanged
    {

        private Customer selectedCustomer;
        private ObservableCollection<Customer> customers;

        public AppViewModel()
        {
            customers = new ObservableCollection<Customer>() //Добавление данных для тестирования
            {
                new Customer("John", "Fix printer", 500, new DateTime(2022, 5, 11)),
                new Customer("Josh", "Install fax", 350, new DateTime(2022, 6, 15)),
                new Customer("Tyler", "Update soft", 100, new DateTime(2022, 9, 17)),
                new Customer("Nico", "Install antivirus", 400, new DateTime(2022, 9, 19)),
                new Customer("Tyler", "Fix printer", 500, new DateTime(2022, 9, 21)),
                new Customer("Nico", "Update soft", 200, new DateTime(2022, 10, 27))
            };
        }

        public Customer SelectedCustomer
        {SelectedCustomer
            get
            {
                return this.selectedCustomer;
            }

            set
            {
                this.selectedCustomer = value;
                OnPropertyChanged("");
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return this.customers;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
