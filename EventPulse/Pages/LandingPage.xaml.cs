using System.Collections.ObjectModel;

namespace EventPulse.Pages;

public partial class LandingPage : ContentPage
{
	public ObservableCollection<string> ImageUrls { get => imageUrls; set => imageUrls = value; }

	private ObservableCollection<string> imageUrls = new()
		{
			"cowboy.jpg",
			"guitar_solo.jpg",
			"lights.jpg",
			"porsche.jpg"
		};

	private int currentIndex = 0;

	[Obsolete]
	public LandingPage()
	{
		InitializeComponent();

		carouselView.ItemsSource = ImageUrls;
		carouselView.PositionChanged += CarouselView_PositionChanged;

		Device.StartTimer(TimeSpan.FromSeconds(3), () =>
		{
			currentIndex = (currentIndex + 1) % ImageUrls.Count;
			carouselView.Position = currentIndex;
			return true;
		});
	}

	private void CarouselView_PositionChanged(object sender, PositionChangedEventArgs e)
	{
		currentIndex = e.CurrentPosition;
	}

	private void OnGetStartedClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new HomePage());
	}
}