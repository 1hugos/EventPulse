﻿using Microsoft.Extensions.Logging;

namespace EventPulse;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Roboto-Light.ttf", "RobotoLight");
				fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
				fonts.AddFont("Rowdies-Light.ttf", "RowdiesLight");
				fonts.AddFont("Rowdies-Regular.ttf", "RowdiesRegular");
				fonts.AddFont("Rowdies-Bold.ttf", "RowdiesBold");
				fonts.AddFont("SmoochSans-Regular.ttf", "SmoochRegular");
				fonts.AddFont("SmoochSans-SemiBold.ttf", "SmoochSemiBold");
				fonts.AddFont("Free_Solid.otf", "FreeSolid");
				fonts.AddFont("Free_Regular.otf", "FreeRegular");
				fonts.AddFont("Brands_Regular.otf", "BrandsRegular");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
