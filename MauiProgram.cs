using Microsoft.Extensions.Logging;
using DUODO.Database;
using DUODO.Views;

namespace DUODO;

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
			});
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<DuoDoItemPage>();

        builder.Services.AddSingleton<DuoDoDatabase>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
