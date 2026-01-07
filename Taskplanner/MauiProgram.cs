using Taskplanner.Data;
using Taskplanner.ViewModels;
using Taskplanner.pages;

namespace Taskplanner;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        //  Registrera Repository & ViewModels
        builder.Services.AddSingleton<TaskRepository>();
        builder.Services.AddSingleton<TasksViewModel>();

        //  Registrera sidor
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<TasksPage>();

        return builder.Build();
    }
}