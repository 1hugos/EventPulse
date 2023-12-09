using EventPulse.Models;

namespace EventPulse.Services;

public static class EventService
{
	public static EventItemModel MapToEventItemModel(EventModel source)
	{
		if(source == null)
		{
			throw new ArgumentNullException(nameof(source));
		}

		return new EventItemModel
		{
			Id = source.Id.ToString(),
			Title = source.Title,
			Description = source.Description,
			Date = source.Date,
			Time = source.Time
		};
	}

	public static IEnumerable<EventItemModel> MapToEventItemModels(IEnumerable<EventModel> sourceList)
	{
		if (sourceList == null)
		{
			throw new ArgumentNullException(nameof(sourceList));
		}

		var destinationList = new List<EventItemModel>();
		foreach (var sourceItem in sourceList)
		{
			destinationList.Add(MapToEventItemModel(sourceItem));
		}
		return destinationList;
	}
}