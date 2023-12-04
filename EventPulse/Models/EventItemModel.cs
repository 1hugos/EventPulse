using System.ComponentModel;

namespace EventPulse.Models;

/// <summary>
/// Model dla nowego wydarzenia.
/// </summary>
public class EventItemModel : INotifyPropertyChanged
{
	/// <summary>
	/// Tytuł wydarzenia.
	/// </summary>
	public string Title { get; set; }

	/// <summary>
	/// Treść opisujaca wydarzenie.
	/// </summary>
	public string Description { get; set; }

	/// <summary>
	/// Pełna data wydarzenia.
	/// </summary>
	public DateTime Date { get; set; }

	/// <summary>
	/// Tylko data wydarzenia.
	/// </summary>
	public DateOnly OnlyDate => new(Date.Year, Date.Month, Date.Day);

	/// <summary>
	/// Sformatowana data do wyświetlenia w postaci "1.1.1111".
	/// </summary>
	public string FormattedDate => OnlyDate.ToString("d.M.yyyy");

	/// <summary>
	/// Model dla listy wydarzeń.
	/// </summary>
	public List<EventItemModel> EventItemList { get; set; }

	/// <summary>
	/// Przechowuje sformatowany pozostały czas do wydarzenia.
	/// </summary>
	private string _timeRemaining;

	/// <summary>
	/// Pobiera lub ustawia pozostały czas do wydarzenia.
	/// </summary>
	public string TimeRemaining
	{
		get { return _timeRemaining; }
		set
		{
			if (_timeRemaining != value)
			{
				_timeRemaining = value;
				OnPropertyChanged(nameof(TimeRemaining));
			}
		}
	}

	/// <summary>
	/// Zdarzenie wywoływane po zmianie wartości właściwości.
	/// </summary>
	public event PropertyChangedEventHandler PropertyChanged;

	/// <summary>
	/// Wywoływane w celu powiadomienia o zmianie wartości właściwości.
	/// </summary>
	/// <param name="propertyName">Nazwa właściwości, która uległa zmianie.</param>
	protected virtual void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
