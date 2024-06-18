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

namespace ToDoList_WPF
{
    /// <summary>
    /// Interaction logic for AddTaskForm.xaml
    /// </summary>
    public partial class AddTaskForm : Window
    {
        public event Action<Task> AddTask;

        public AddTaskForm()
        {
            InitializeComponent();
            DataContext = this;
        }

        public Status SelectedStatus { get; set; } 

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task()
            {
                Name = nameTextBox.Text,
                Status = SelectedStatus
            };

            AddTask?.Invoke(task);
            Close();
        }
    }
}
