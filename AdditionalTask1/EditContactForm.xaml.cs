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
    /// Interaction logic for EditContactForm.xaml
    /// </summary>
    public partial class EditContactForm : Window
    {
        private Contact contact;
        public EditContactForm(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
            DataContext = contact;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = nameTextBox.Text;
            contact.Surname = surnameTextBox.Text;
            contact.PhoneNumber = phoneNumberTextBox.Text;
            contact.Email = emailTextBox.Text;
            Close();
        }
    }
}
