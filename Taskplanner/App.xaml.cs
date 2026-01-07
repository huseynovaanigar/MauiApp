namespace Taskplanner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        // Hjälpmetod för att hämta dynamiska färger baserat på tema
        public static Color GetDynamicColor(string lightColorKey, string darkColorKey)
        {
            if (Application.Current == null) 
                return Colors.Black;
                
            try
            {
                return Application.Current.RequestedTheme == AppTheme.Dark
                    ? (Color)Application.Current.Resources[darkColorKey]
                    : (Color)Application.Current.Resources[lightColorKey];
            }
            catch
            {
                // Fallback färger om något går fel
                return Application.Current.RequestedTheme == AppTheme.Dark ? Colors.Black : Colors.White;
            }
        }
    }
}