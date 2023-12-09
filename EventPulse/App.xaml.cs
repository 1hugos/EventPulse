using EventPulse.Data;
using EventPulse.Utils;

namespace EventPulse;

public partial class App : Application
{
	public static EventDb EventDb { get; private set; }

	public App(EventDb eventDb)
	{
		InitializeComponent();
		MainPage = new AppShell();

		EventDb = eventDb;
	}
}
