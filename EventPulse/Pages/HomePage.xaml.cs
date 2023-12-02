using EventPulse.Models;

namespace EventPulse.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();

		BindingContext = new EventItemModel
		{
			EventItemList = App.DataManager.EventItems.ToList()
		};
	}
	private void OnAddNewItemClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new AddNewItemPage());
	}
}