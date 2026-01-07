using Taskplanner.pages;

namespace Taskplanner;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    
   
    /// Navigera till TasksPage när knappen klickas
    private async void OnGoToTasksPageClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(TasksPage));
    }
}