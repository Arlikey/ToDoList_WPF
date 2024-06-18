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

namespace ToDoList_WPF.AdditionalTask1
{
    /// <summary>
    /// Interaction logic for AddContactForm.xaml
    /// </summary>
    public partial class AddContactForm : Window
    {
        public event Action<Contact> AddContact;
        public AddContactForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Surname = surnameTextBox.Text,
                PhoneNumber = phoneNumberTextBox.Text,
                Email = emailTextBox.Text,
            };

            AddContact?.Invoke(contact);
            Close();
        }
    }
}
