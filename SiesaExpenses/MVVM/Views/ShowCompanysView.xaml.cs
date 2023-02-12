using Microsoft.Maui.Controls;
using SiesaExpenses.MVVM.Models;
using SiesaExpenses.MVVM.ViewModels;
using System.Globalization;
using System.Windows.Input;

namespace SiesaExpenses.MVVM.Views;

public partial class ShowCompanysView : ContentPage
{
    public static string name { get; set; }
    public ShowCompanysView()
	{
		InitializeComponent();
		BindingContext = new ShowCompanysViewModel();
    }

    private async void btnAddCompany_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddNewCompanyView());
    }
    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    private void btnGoHome_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HomeView(null));
    }

    private void btnGoCompany_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HomeView(name));
    }
}