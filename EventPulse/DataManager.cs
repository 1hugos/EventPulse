using EventPulse.Models;
using System.Collections.ObjectModel;

public class DataManager
{
	public ObservableCollection<EventItemModel> EventItems { get; set; }

	public DataManager()
	{
		EventItems = new ObservableCollection<EventItemModel>();
	}
}
