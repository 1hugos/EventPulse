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
		App.DataManager.EventItems.Add((EventItemModel)BindingContext);

		BindingContext = new EventItemModel();

		Navigation.PushAsync(new HomePage());
	}

	private void OnGoBackClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new HomePage());
	}
}