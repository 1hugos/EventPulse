using EventPulse.Models;
using SQLite;

namespace EventPulse.Data;

public class EventDb
{
	private readonly string _dbPath;
	private SQLiteAsyncConnection _db;

	public EventDb(string dbPath)
	{
		_dbPath = dbPath;
	}

	private void InitializeDatabase()
	{
		if (_db == null)
		{
			_db = new SQLiteAsyncConnection(_dbPath);
			_db.CreateTableAsync<EventModel>().Wait();
		}
	}

	public async Task<IEnumerable<EventModel>> GetEvents()
	{
		InitializeDatabase();

		var response = await _db.Table<EventModel>().ToListAsync();

		if (response == null)
		{
			return new List<EventModel>();
		}

		return response;
	}

	public async Task SaveEvents(IEnumerable<EventModel> eventItems)
	{
		await _db.InsertAllAsync(eventItems);
	}

	public async Task<IEnumerable<EventModel>> SortEventItemsByDate()
	{
		return await _db.Table<EventModel>().OrderBy(item => item.Date).ToListAsync();
	}

	public async Task AddEvent(EventModel eventItem)
	{
		InitializeDatabase();
		await _db.InsertAsync(eventItem);
	}

	public async Task UpdateEvent(EventModel eventItem)
	{
		await _db.UpdateAsync(eventItem);
	}

	public async Task DeleteEvent(int eventId)
	{
		var eventItemToDelete = await _db.GetAsync<EventModel>(eventId);
		if (eventItemToDelete != null)
		{
			await _db.DeleteAsync(eventItemToDelete);
		}
	}
}
