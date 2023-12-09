using EventPulse.Models;
using EventPulse.Services;

namespace EventPulse.Pages;

public partial class EditEventPage : ContentPage
{
	private EventItemModel _selectedEvent;
	private int? _selectedId;

	public EditEventPage(EventItemModel selectedItem)
	{
		InitializeComponent();

		_selectedEvent = selectedItem;
		_selectedId = Convert.ToInt32(selectedItem.Id);

		BindingContext = _selectedEvent;
	}

	private async void OnDeleteEventClicked(object sender, EventArgs e)
	{
		await App.EventDb.DeleteEvent(int.Parse(_selectedEvent.Id));

		await Navigation.PushAsync(new HomePage());
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
