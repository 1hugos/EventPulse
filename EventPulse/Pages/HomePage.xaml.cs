using EventPulse.Models;
using Microsoft.Extensions.Logging;

namespace EventPulse.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();

		var eventItemModel = new EventItemModel
		{
			EventItemList = App.DataManager.EventItems.ToList()
		};

		BindingContext = eventItemModel;
	}

	private void OnAddNewItemClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new AddNewItemPage());
	}

	private void OnCardTapped(object sender, EventArgs e)
	{
		if (sender is Grid grid)
		{
			var descriptionLabel = grid.FindByName<Label>("DescriptionLabel");

			if (descriptionLabel != null)
			{
				descriptionLabel.IsVisible = !descriptionLabel.IsVisible;

				if (descriptionLabel.IsVisible)
				{
					grid.RowDefinitions[2].Height = GridLength.Auto;
				}
			}
		}
	}
}