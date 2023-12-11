using EventPulse.Models;
using EventPulse.Resources.Languages;
using EventPulse.Services;

namespace EventPulse.Pages;

public partial class EditEventPage : ContentPage
{
	private readonly EventItemModel _selectedEvent;
	private readonly int? _selectedId;

	public EditEventPage(EventItemModel selectedItem)
	{
		InitializeComponent();

		_selectedEvent = selectedItem;
		_selectedId = Convert.ToInt32(selectedItem.Id);

		BindingContext = _selectedEvent;
	}

	private async void OnDeleteEventClicked(object sender, EventArgs e)
	{
		bool answer = await DisplayAlert(AppResources.Delete_confirmation, AppResources.Delete_confirmation_msg, AppResources.Yes, AppResources.No);

		if (answer)
		{
			await App.EventDb.DeleteEvent(int.Parse(_selectedEvent.Id));
			await Navigation.PushAsync(new HomePage());
		}
	}

	private async void OnSaveChangesClicked(object sender, EventArgs e)
	{
		var eventItems = await App.EventDb.GetEvents();

		var updatedEventItem = eventItems.FirstOrDefault(e => e.Id == _selectedId);

		if (updatedEventItem != null)
		{
			updatedEventItem.Title = _selectedEvent.Title;
			updatedEventItem.Description = _selectedEvent.Description;
			updatedEventItem.Date = _selectedEvent.Date;
			updatedEventItem.Time = _selectedEvent.Time;
		}
		
		await App.EventDb.UpdateEvent(updatedEventItem);

		await Navigation.PushAsync(new HomePage());
	}

}
