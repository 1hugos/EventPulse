namespace EventPulse.Models;

/// <summary>
/// Model dla nowego wydarzenia.
/// </summary>
public class EventItemModel
{
	/// <summary>
	/// Tytuł wydarzenia.
	/// </summary>
	public string Title { get; set; }

	/// <summary>
	/// Treść opisujaca wydarzenie.
	/// </summary>
	public string Content { get; set; }

	/// <summary>
	/// Data wydarzenia.
	/// </summary>
	public DateTime Data { get; set; }
}
