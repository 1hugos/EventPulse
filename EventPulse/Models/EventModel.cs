using SQLite;

namespace EventPulse.Models;

[Table("Event")]
public class EventModel
{
	[PrimaryKey, AutoIncrement, Column("Id")]
	public int Id { get; set; }

	public string Title { get; set; }

	public string Description { get; set; }

	public DateTime Date { get; set; }

	public TimeSpan Time { get; set; }
}
