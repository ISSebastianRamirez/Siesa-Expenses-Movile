using SiesaExpenses.Repositories;

namespace SiesaExpenses;

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
				fonts.AddFont("Mulish.ttf", "Mulish");
			});
		builder.Services.AddSingleton<DBConection>(); //Registrar una unica instancia para ejecutar
		//y que siempre este disponible
		return builder.Build();
	}
}
