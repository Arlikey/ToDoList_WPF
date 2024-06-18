using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ToDoList_WPF.AdditionalTask1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Contact> Contacts { get; }
        public MainWindow()
        {
            InitializeComponent();
            Contacts = new ObservableCollection<Contact>() 
            {
                new Contact(){ Name = "Nazar", Surname = "Melnik", PhoneNumber = "458634636", Email="arkeyfast@gmail.com"},
                new Contact(){ Name = "Tolik", Surname = "Klimchuk", PhoneNumber = "4347567856", Email="tolklim@gmail.com"},
                new Contact(){ Name = "Anton", Surname = "Sneej", PhoneNumber = "4634637523", Email="sneej@gmail.com"},
            };
            contactsListView.ItemsSource = Contacts;
        }

        private void addContactButton_Click(object sender, RoutedEventArgs e)
        {
            AddContactForm addContactForm = new AddContactForm();
            addContactForm.AddContact += AddContactForm_AddContact;
            addContactForm.ShowDialog();
        }

        private void AddContactForm_AddContact(Contact obj)
        {
            Contacts.Add(obj);
        }

        private void editContactButton_Click(object sender, RoutedEventArgs e)
        {
            EditContactForm editContactForm = new EditContactForm(contactsListView.SelectedItem as Contact);
            editContactForm.ShowDialog();
        }

        private void deleteContactButton_Click(object sender, RoutedEventArgs e)
        {
            Contact[] selectedContacts = contactsListView.SelectedItems.Cast<Contact>().ToArray();
            foreach (Contact contact in selectedContacts)
            {
                Contacts.Remove(contact);
            }
        }
    }

    public class Contact : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _phoneNumber;
        private string _email;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged();
                }
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
