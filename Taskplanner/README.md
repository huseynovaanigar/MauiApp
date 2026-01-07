PROJECT: TaskPlanner
PROJEKTSTRUKTUR
Taskplanner/
App.xaml
AppShell.xaml
MainPage.xaml
MauiProgram.cs
Taskplanner.csproj
Models/
ViewModels/
Data/
Converters/
Resources/
Platforms/
KRAV FÖR ATT BYGGA PROJEKTET
.NET 9 SDK
https://dotnet.microsoft.com/download
.NET MAUI workloads (kör i Terminal)
dotnet workload install maui
FÖR ANDROID (EMULATOR)
Android Studio installerat
Android SDK Platform 35
Build Tools
Emulator
JDK 17

FÖR iOS (Mac)
Xcode + iOS Simulator installerat
HUR MAN BYGGER PROJEKTET
Gå till projektmappen
cd ~/Dev/MauiApp
Restore + build
dotnet restore
dotnet build

HUR MAN KÖR PROJEKTET
ANDROID (emulator måste vara igång)
cd ~/Dev/MauiApp
dotnet run --project Taskplanner/Taskplanner.csproj -f net9.0-android

iOS (Simulator)
Starta Simulator
open -a Simulator
Kör appen
cd ~/Dev/MauiApp
dotnet run --project Taskplanner/Taskplanner.csproj -f net9.0-ios -p:RuntimeIdentifier=iossimulator-arm64 (eftersom jag har skapat ett script:
~/Dev/MauiApp/scripts/maui-run
och lagt alias / PATH-inställningar i:
~/.zshrc så du kan se en script fil också som är bara för mig jag orkade inte köra så långt skriva varje gång i terminal osv så gjorde jag en kort script som fungerar i min dator maui-run"" mvh Nigar Huseynova)

AVANCERADE C#-KONCEPT SOM ANVÄNDS
Collections & Generics:
List<TaskModel>
ObservableCollection<TaskModel>
Asynkron programmering:
LoadAsync(), AddAsync(), DeleteAsync(), ToggleAsync()
async/await och Task
Designmönster:
MVVM (Views + ViewModels)
Repository för datalagring
ValueConverters:
Färg, ikoner och synlighet baserat på task-status
Filbaserad JSON-lagring:
System.Text.Json

TESTER
Kör tester:
dotnet test
(dotnet test Taskplanner.Tests/Taskplanner.Tests.csproj)


UTVECKLARE
Skrivet av: Nigar Huseynova & Jamila Abdullahi
Kurs: Avancerad C#
Projekt: TaskPlanner
