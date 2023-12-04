using EventPulse.Models;
using System.Collections.ObjectModel;

namespace EventPulse;

public static class DataManager
{
	public static ObservableCollection<EventItemModel> EventItems { get; set; }

	static DataManager()
	{
		EventItems = LoadEventItems();
	}

	public static void AddEventItem(EventItemModel eventItem)
	{
		EventItems.Add(eventItem);

		SaveEventItems(EventItems);
	}

	public static ObservableCollection<EventItemModel> LoadEventItems()
	{
		string serializedList = Preferences.Get("EventItemList", string.Empty);

		if (!string.IsNullOrEmpty(serializedList))
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<EventItemModel>>(serializedList);
		}

		return new ObservableCollection<EventItemModel>();
	}

	public static void SaveEventItems(ObservableCollection<EventItemModel> eventItems)
	{
		string serializedList = Newtonsoft.Json.JsonConvert.SerializeObject(eventItems);

		Preferences.Set("EventItemList", serializedList);
	}

	public static ObservableCollection<EventItemModel> SortEventItemsByDate()
	{
		return new(EventItems.OrderBy(item => item.Date));
	}
}