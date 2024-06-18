using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoList_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Task> Tasks { get; }
        public MainWindow()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<Task>()
            {
                new Task(){Name = "Task 1", Status = Status.Completed},
                new Task(){Name = "Task 2", Status = Status.InProgress},
                new Task(){Name = "Task 3", Status = Status.Cancelled}
            };
            tasksListView.ItemsSource = Tasks;
        }

        private void addTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddTaskForm addTaskForm = new AddTaskForm();
            addTaskForm.AddTask += AddTaskForm_AddTask;
            addTaskForm.ShowDialog();
        }

        private void AddTaskForm_AddTask(Task obj)
        {
            Tasks.Add(obj);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Task task = button.Tag as Task;
            if (task != null)
            {
                Tasks.Remove(task);
            }
        }

        private void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Task task = button.Tag as Task;
            if (task != null)
            {
                // Completed -> InProgress -> Cancelled
                task.Status = task.Status == Status.Completed ? Status.InProgress : task.Status == Status.InProgress ? Status.Cancelled : Status.Completed;
            }
        }
    }
    public class Task : INotifyPropertyChanged
    {
        private string _name;
        private Status _status;
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
        public Status Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
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
    public enum Status
    {
        Completed,
        InProgress,
        Cancelled
    }
}