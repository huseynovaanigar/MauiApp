using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Taskplanner.Models
{
    public class TaskModel : INotifyPropertyChanged
    {
        private bool _isCompleted;

        public Guid Id { get; set; } = Guid.NewGuid();

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _dueDate;
        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                if (_dueDate != value)
                {
                    _dueDate = value;
                    OnPropertyChanged();
                }
            }
        }

        // FIX: Gör set PUBLIC så ViewModel kan ändra
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                if (_isCompleted != value)
                {
                    _isCompleted = value;
                    OnPropertyChanged();
                }
            }
        }

        //  Används av ViewModel när man togglar en uppgift
        public void ToggleCompletion()
        {
            IsCompleted = !IsCompleted;
        }

        // Används för validering innan man lägger till
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Title);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
