using System;

using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace Respond
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> listUsers = new ObservableCollection<User>();
        
//        private List<User> listUsers = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
            //users.Add(new User() { Name = "Петя",LastName="Петров" });
            //users.Add(new User() { Name = "Коля",LastName="Сидоров" });
            listUsers.Add(new User() { Name = "Петя", LastName = "Петров" });
            listUsers.Add(new User() { Name = "Коля", LastName = "Сидоров" });
            //lbUsers.ItemsSource = users;
            lbUsers.ItemsSource = listUsers;
        }
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
           // users.Add(new User() { Name = "Вася",LastName="Васичкин" });
           listUsers.Add(new User() { Name = "Вася", LastName = "Васичкин" });
        }
        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
                (lbUsers.SelectedItem as User).Name = "12Иван";
        }
        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
                listUsers.Remove(lbUsers.SelectedItem as User);
        }
    }



    public class User: INotifyPropertyChanged
    {
        private string name;
        private string lastName;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (this.lastName != value)
                {
                    this.lastName = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Name + " " + LastName;
        }
    }

}

