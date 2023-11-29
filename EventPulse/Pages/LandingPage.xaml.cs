﻿using System.Collections.ObjectModel;

namespace EventPulse;

public partial class LandingPage : ContentPage
{
	private ObservableCollection<string> imageUrls = new()
		{
			"cowboy.jpg",
			"guitar_solo.jpg",
			"lights.jpg",
			"porsche.jpg"
		};

	private int currentIndex = 0;

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

	public ObservableCollection<string> ImageUrls { get => imageUrls; set => imageUrls = value; }

	private void CarouselView_PositionChanged(object sender, PositionChangedEventArgs e)
	{
		currentIndex = e.CurrentPosition;
	}

	private void OnGetStartedClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new HomePage());
	}
}