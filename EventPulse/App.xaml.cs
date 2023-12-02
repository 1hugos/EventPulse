namespace EventPulse;

public partial class App : Application
{
	public static DataManager DataManager { get; private set; }

	public App()
	{
		InitializeComponent();
		DataManager = new DataManager();
		MainPage = new AppShell();
	}
}
