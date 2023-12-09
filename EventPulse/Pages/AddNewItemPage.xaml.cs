using EventPulse.Models;
using EventPulse.Services;
using System.Collections.ObjectModel;

namespace EventPulse.Pages;

public partial class AddNewItemPage : ContentPage
{
	public AddNewItemPage()
	{
		InitializeComponent();
		BindingContext = new EventModel();
		
	}

	private async void OnAddClicked(object sender, EventArgs e)
	{
		var newEventItem = new EventModel
		{
			Title = ((EventModel)BindingContext).Title,
			Description = ((EventModel)BindingContext).Description,
			Date = ((EventModel)BindingContext).Date,
			Time = ((EventModel)BindingContext).Time
		};

		await App.EventDb.AddEvent(newEventItem);

		BindingContext = new EventModel();

		await Navigation.PushAsync(new HomePage());
	}

	private void OnGoBackClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new HomePage());
	}
}
