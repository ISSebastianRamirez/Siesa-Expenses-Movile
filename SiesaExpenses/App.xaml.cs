using SiesaExpenses.MVVM.Views;
using SiesaExpenses.Repositories;

namespace SiesaExpenses;

public partial class App : Application
{
	public static DBConection DBRepo { get; private set; } //Se abre el acceso a la base de datos
	public App(DBConection db)
	{
		InitializeComponent();
		DBRepo = db;
		Current.UserAppTheme = AppTheme.Light;
		MainPage = new NavigationPage(new HomeView(null));
	}
}
