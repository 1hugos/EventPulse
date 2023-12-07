using EventPulse.Models;

namespace EventPulse.Pages;

public partial class EditEventPage : ContentPage
{
	private EventItemModel _selectedEvent;
	public EditEventPage(EventItemModel selectedItem)
	{
		InitializeComponent();

		_selectedEvent = selectedItem;

		BindingContext = _selectedEvent;
	}

	private void OnDeleteEventClicked(object sender, EventArgs e)
	{
		int selectedIndex = DataManager.EventItems.IndexOf(_selectedEvent);

		if (selectedIndex != -1)
		{
			DataManager.EventItems.RemoveAt(selectedIndex);

			DataManager.SaveEventItems(DataManager.EventItems);
		}

		Navigation.PushAsync(new HomePage());
	}

	private void OnSaveChangesClicked(object sender, EventArgs e)
	{
		int selectedIndex = DataManager.EventItems.IndexOf(_selectedEvent);

		if (selectedIndex != -1)
		{
			DataManager.EventItems[selectedIndex].Title = _selectedEvent.Title;
			DataManager.EventItems[selectedIndex].Description = _selectedEvent.Description;
			DataManager.EventItems[selectedIndex].Date = _selectedEvent.Date;
			DataManager.EventItems[selectedIndex].Time = _selectedEvent.Time;
			
			DataManager.SaveEventItems(DataManager.EventItems);
		}

		Navigation.PushAsync(new HomePage());
	}
}