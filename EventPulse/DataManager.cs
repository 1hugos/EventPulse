using EventPulse.Models;
using System.Collections.ObjectModel;

public class DataManager
{
	public ObservableCollection<EventItemModel> EventItems { get; set; }

	public DataManager()
	{
		EventItems = LoadEventItems();
	}

	public void AddEventItem(EventItemModel eventItem)
	{
		EventItems.Add(eventItem);

		SaveEventItems(EventItems);
	}

	public ObservableCollection<EventItemModel> LoadEventItems()
	{
		string serializedList = Preferences.Get("EventItemList", string.Empty);

		if (!string.IsNullOrEmpty(serializedList))
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<EventItemModel>>(serializedList);
		}

		return new ObservableCollection<EventItemModel>();
	}

	public void SaveEventItems(ObservableCollection<EventItemModel> eventItems)
	{
		string serializedList = Newtonsoft.Json.JsonConvert.SerializeObject(eventItems);

		Preferences.Set("EventItemList", serializedList);
	}
}