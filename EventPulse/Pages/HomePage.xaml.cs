using EventPulse.Models;

namespace EventPulse.Pages
{
	public partial class HomePage : ContentPage
	{
		private bool isTimerRunning;
		private EventItemModel closestEvent;

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

			if (closestEvent != null)
			{
				ClosestTimerLabel.Text = closestEvent.TimeRemaining;
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
					// selectedItem zawiera dane wybranego elementu listy
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