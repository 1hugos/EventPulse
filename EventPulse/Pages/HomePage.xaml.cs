using EventPulse.Models;

namespace EventPulse.Pages
{
	public partial class HomePage : ContentPage
	{
		private bool isTimerRunning;

		public HomePage()
		{
			InitializeComponent();

			var closestEventItemModel = new EventItemModel
			{
				EventItemList = new List<EventItemModel> { DataManager.EventItems.OrderBy(item => item.Date).FirstOrDefault() }
			};

			var eventItemModel = new EventItemModel
			{
				EventItemList = DataManager.EventItems.OrderBy(item => item.Date).Skip(1).ToList()
			};

			UpdateClosestEventUI(closestEventItemModel.EventItemList.FirstOrDefault());

			BindingContext = eventItemModel;

			this.Appearing += OnPageAppearing;
		}

		private void OnPageAppearing(object sender, EventArgs e)
		{
			StartCountdownTimer();
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
			foreach (var item in DataManager.EventItems)
			{
				TimeSpan timeRemaining = item.Date - DateTime.Now;

				item.TimeRemaining = FormatTimeRemaining(timeRemaining);
			}
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
			ClosestTitleLabel.Text = closestEvent.Title;
			ClosestDateLabel.Text = closestEvent.FormattedDate;
			ClosestDescriptionLabel.Text = closestEvent.Description;
			ClosestTimerLabel.Text = closestEvent.TimeRemaining;
		}
	}
}