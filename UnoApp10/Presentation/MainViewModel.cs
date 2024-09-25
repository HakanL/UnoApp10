using System.Collections.ObjectModel;

namespace UnoApp10.Presentation;

public partial class MainViewModel : ObservableObject
{
    private INavigator _navigator;

    [ObservableProperty]
    private string? name;

    public MainViewModel(
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        Title += $" - {appInfo?.Value?.Environment}";
        GoToSecond = new AsyncRelayCommand(GoToSecondView);

        MenuItems.Add(new MenuItem { Name = "First" });
        MenuItems.Add(new MenuItem { Name = "Second" });
        MenuItems.Add(new MenuItem { Name = "Third" });
    }
    public string? Title { get; }

    public ICommand GoToSecond { get; }

    public ObservableCollection<MenuItem> MenuItems { get; } = new ObservableCollection<MenuItem>();

    private async Task GoToSecondView()
    {
        await _navigator.NavigateViewModelAsync<SecondViewModel>(this, data: new Entity(Name!));
    }

}
