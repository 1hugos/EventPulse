using EventPulse.Models;

namespace EventPulse.Pages;

public partial class AddNewItemPage : ContentPage
{
	public AddNewItemPage()
	{
		InitializeComponent();
		BindingContext = new EventItemModel();
	}

	private void OnAddClicked(object sender, EventArgs e)
	{
		var newEventItem = new EventItemModel
		{
			Title = ((EventItemModel)BindingContext).Title,
			Description = ((EventItemModel)BindingContext).Description,
			Date = ((EventItemModel)BindingContext).Date,
			Time = ((EventItemModel)BindingContext).Time
		};

		DataManager.AddEventItem(newEventItem);

		BindingContext = new EventItemModel();

		DataManager.SaveEventItems(DataManager.EventItems);

		Navigation.PushAsync(new HomePage());
	}

	private void OnGoBackClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new HomePage());
	}
}