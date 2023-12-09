using EventPulse.Models;
using EventPulse.Services;

namespace EventPulse.Pages
{
	public partial class HomePage : ContentPage
	{
		private bool isTimerRunning;
		private EventItemModel closestEvent;
		private IEnumerable<EventItemModel> events;

		public HomePage()
		{
			InitializeComponent();

			this.Appearing += OnPageAppearing;
		}

		private async void OnPageAppearing(object sender, EventArgs e)
		{
			await LoadEventDataAsync();
			StartCountdownTimer();
		}

		private async Task LoadEventDataAsync()
		{
			var response = await App.EventDb.GetEvents();

			if(!response.Any())
			{
				NoRecordsGrid.IsVisible = true;
				ClosestEvenGrid.IsVisible = false;
				return;
			}

			events = EventService.MapToEventItemModels(response);

			var closestEventItemModel = new EventItemModel
			{
				EventItemList = new List<EventItemModel> { events.OrderBy(item => item.Date).FirstOrDefault() }
			};

			var eventItemModel = new EventItemModel
			{
				EventItemList = events.OrderBy(item => item.Date).Skip(1).ToList()
			};

			UpdateClosestEventUI(closestEventItemModel.EventItemList.FirstOrDefault());

			BindingContext = eventItemModel;
		}

		private void StartCountdownTimer()
		{
			if (!isTimerRunning)
			{
				Device.StartTimer(TimeSpan.FromSeconds(1), () =>
				{
					UpdateCountdowns();
					return true; // Keep the timer running
				});

				isTimerRunning = true;
			}
		}

		private void UpdateCountdowns()
		{
			foreach (var item in events)
			{
				DateTime now = DateTime.Now;

				DateTime eventDateTime = item.FullDate;

				if (now < eventDateTime)
				{
					TimeSpan timeRemaining = eventDateTime - now;

					item.TimeRemaining = FormatTimeRemaining(timeRemaining);
				}
				else
				{
					item.TimeRemaining = "Wydarzenie ju¿ siê odby³o.";
				}
			}

			ClosestTimerLabel.Text = closestEvent.TimeRemaining;
		}

		private void OnCardTapped(object sender, EventArgs e)
		{
			if (sender is Grid grid)
			{
				var descriptionLabel = grid.FindByName<Label>("DescriptionLabel");

				if (descriptionLabel != null)
				{
					descriptionLabel.IsVisible = !descriptionLabel.IsVisible;

					if (descriptionLabel.IsVisible)
					{
						grid.RowDefinitions[2].Height = GridLength.Auto;
					}
				}
			}
		}

		private void OnAddNewItemClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new AddNewItemPage());
		}

		private static string FormatTimeRemaining(TimeSpan timeRemaining)
		{
			string formattedTimeRemaining = $"{(int)timeRemaining.TotalDays}d {timeRemaining.Hours}h {timeRemaining.Minutes}min {timeRemaining.Seconds}sec";

			return formattedTimeRemaining;
		}

		private void UpdateClosestEventUI(EventItemModel closestEvent)
		{
			this.closestEvent = closestEvent;
			ClosestTitleLabel.Text = closestEvent.Title;
			ClosestDateLabel.Text = closestEvent.FormattedDate;
			ClosestDescriptionLabel.Text = closestEvent.Description;
		}

		private void OnEditButtonClicked(object sender, EventArgs e)
		{
			if (sender is Button editButton)
			{
				if (editButton.BindingContext is EventItemModel selectedItem)
				{
					Navigation.PushAsync(new EditEventPage(selectedItem));
				}
			}
		}

		private void OnEditClosestEventButtonClicked(object sender, EventArgs e)
		{
			if (closestEvent != null)
			{
				Navigation.PushAsync(new EditEventPage(closestEvent));
			}
		}
	}
}
