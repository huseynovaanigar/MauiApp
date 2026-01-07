using Taskplanner.ViewModels;
using Taskplanner.Models;

namespace Taskplanner.pages
{
    public partial class TasksPage : ContentPage
    {
        public TasksPage()
        {
            InitializeComponent();

            // Kör när sidan visas
            this.Appearing += OnPageAppearing;
        }

        private void OnPageAppearing(object sender, EventArgs e)
        {
            if (BindingContext is TasksViewModel vm)
            {
                // Kör kommandot som laddar uppgifter
                vm.LoadDataCommand.Execute(null);

                System.Diagnostics.Debug.WriteLine(
                    $"📱 Sidan laddad - Visar {vm.Tasks.Count} uppgifter");
            }
        }

        /// <summary>
        /// Lägg till en ny uppgift
        /// </summary>
        private async void OnAddTaskClicked(object sender, EventArgs e)
        {
            if (BindingContext is TasksViewModel vm)
            {
                var newTask = new TaskModel
                {
                    Title = TitleEntry.Text?.Trim() ?? "",
                    Description = DescriptionEntry.Text?.Trim() ?? "",
                    DueDate = DueDatePicker.Date
                };

                // Validera titel
                if (string.IsNullOrWhiteSpace(newTask.Title))
                {
                    await DisplayAlert("Fel", "Ange en titel för uppgiften", "OK");
                    TitleEntry.Focus();
                    return;
                }

                // Lägg till
                await vm.AddAsync(newTask);

                // Rensa fält
                TitleEntry.Text = "";
                DescriptionEntry.Text = "";
                DueDatePicker.Date = DateTime.Now;

                await DisplayAlert("Lyckades", $"Uppgiften '{newTask.Title}' har lagts till!", "OK");
            }
        }
    }
}