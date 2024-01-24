using EventPulse.Models;

namespace EventPulse.Services;

/// <summary>
/// Klasa statyczna zawierająca metody do mapowania modeli związanych z wydarzeniami.
/// </summary>
public static class EventService
{
	/// <summary>
	/// Mapuje pojedynczy obiekt z modelu z bazy danych na model przeznaczony do wyświetlania w interfejsie użytkownika.
	/// </summary>
	/// <param name="source">Model z bazy danych do zmapowania.</param>
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

	/// <summary>
	/// Mapuje listę obiektów z modelu z bazy danych na listę modeli przeznaczonych do wyświetlania w interfejsie użytkownika.
	/// </summary>
	/// <param name="sourceList">Lista modeli z bazy danych do zmapowania.</param>
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