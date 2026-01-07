using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Taskplanner.Data;
using Taskplanner.Models;
using Microsoft.Maui.Dispatching;

namespace Taskplanner.ViewModels
{
    public class TasksViewModel : INotifyPropertyChanged
    {
        private static readonly TaskRepository _repo = new();

        private bool _isBusy;

        public ObservableCollection<TaskModel> Tasks { get; } = new();

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ToggleCommand { get; }
        public ICommand LoadDataCommand { get; }

        public TasksViewModel()
        {
            AddCommand = new Command<TaskModel>(async t => await AddAsync(t));
            DeleteCommand = new Command<TaskModel>(async t => await DeleteAsync(t));
            ToggleCommand = new Command<TaskModel>(async t => await ToggleAsync(t));
            LoadDataCommand = new Command(async () => await LoadAsync());
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                }
            }
        }

        // ------------------------------------
        // LOAD
        // ------------------------------------
        public async Task LoadAsync()
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                var allTasks = await _repo.LoadAsync();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Tasks.Clear();
                    foreach (var t in allTasks)
                        Tasks.Add(t);
                });

                System.Diagnostics.Debug.WriteLine($"📥 Laddade {allTasks.Count} uppgifter.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ LoadAsync error: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        // ------------------------------------
        // ADD
        // ------------------------------------
        public async Task AddAsync(TaskModel newTask)
        {
            if (newTask == null || !newTask.IsValid()) return;

            try
            {
                await _repo.AddAsync(newTask);

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Tasks.Add(newTask);
                });

                System.Diagnostics.Debug.WriteLine($"➕ Tillagd: {newTask.Title}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ AddAsync error: {ex.Message}");
            }
        }

        // ------------------------------------
        // Tabort
        // ------------------------------------
        public async Task DeleteAsync(TaskModel task)
        {
            if (task == null) return;

            try
            {
                await _repo.DeleteAsync(task);

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Tasks.Remove(task);
                });

                System.Diagnostics.Debug.WriteLine($"🗑️ Borttagen: {task.Title}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ DeleteAsync error: {ex.Message}");
            }
        }

        // ------------------------------------
        // TOGGLE COMPLETED
        // ------------------------------------
        public async Task ToggleAsync(TaskModel task)
        {
            if (task == null) return;

            try
            {
                await _repo.ToggleAsync(task);

                // Efter toggling i filen, uppdatera UI-objektet
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    task.ToggleCompletion(); // Detta uppdaterar UI tack vare INotifyPropertyChanged
                });

                System.Diagnostics.Debug.WriteLine($"🔁 Toggled: {task.Title}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ ToggleAsync error: {ex.Message}");
            }
        }

        // ------------------------------------
        // PropertyChanged
        // ------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
