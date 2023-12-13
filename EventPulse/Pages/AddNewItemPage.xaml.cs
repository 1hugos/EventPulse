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
		NewEventDatePicker.MinimumDate = DateTime.Now;
	}

	private async void OnAddClicked(object sender, EventArgs e)
	{
		var eventModel = (EventModel)BindingContext;

		if (string.IsNullOrWhiteSpace(eventModel.Title) ||
			string.IsNullOrWhiteSpace(eventModel.Description) ||
			eventModel.Date == default(DateTime) ||
			eventModel.Time == default(TimeSpan))
		{
			await DisplayAlert("B³¹d", "Wszystkie pola musz¹ byæ wype³nione.", "OK");
			return;
		}

		var newEventItem = new EventModel
		{
			Title = eventModel.Title,
			Description = eventModel.Description,
			Date = eventModel.Date,
			Time = eventModel.Time
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
