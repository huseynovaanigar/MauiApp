using System.Text.Json;
using Taskplanner.Models;

namespace Taskplanner.Data;

public class TaskRepository
{
    private readonly string _filePath;

    public TaskRepository()
    {
        // Spara filen i lokal appdata
        _filePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "tasks.json");
    }

    // Ladda alla uppgifter från fil
    public async Task<List<TaskModel>> LoadAsync()
    {
        if (!File.Exists(_filePath))
            return new List<TaskModel>();

        try
        {
            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<TaskModel>>(json) ?? new List<TaskModel>();
        }
        catch
        {
            return new List<TaskModel>();
        }
    }

    // Spara alla uppgifter till fil
    public async Task SaveAsync(List<TaskModel> tasks)
    {
        var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        await File.WriteAllTextAsync(_filePath, json);
    }

    // Lägg till en ny uppgift
    public async Task AddAsync(TaskModel task)
    {
        var tasks = await LoadAsync();
        tasks.Add(task);
        await SaveAsync(tasks);
    }

    // Ta bort en uppgift
    public async Task DeleteAsync(TaskModel task)
    {
        var tasks = await LoadAsync();
        tasks.RemoveAll(t => t.Id == task.Id);
        await SaveAsync(tasks);
    }

    // Växla mellan completed / inte completed
    public async Task ToggleAsync(TaskModel task)
    {
        var tasks = await LoadAsync();
        var t = tasks.FirstOrDefault(x => x.Id == task.Id);

        if (t != null)
            t.IsCompleted = !t.IsCompleted;

        await SaveAsync(tasks);
    }
}