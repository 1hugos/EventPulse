namespace EventPulse.Handler;

public class CustomEntryHandler : Entry
{
	public static readonly BindableProperty IsUnderlineVisibleProperty =
		BindableProperty.Create(nameof(IsUnderlineVisible), typeof(bool), typeof(CustomEntryHandler), true);

	public bool IsUnderlineVisible
	{
		get { return (bool)GetValue(IsUnderlineVisibleProperty); }
		set { SetValue(IsUnderlineVisibleProperty, value); }
	}
}