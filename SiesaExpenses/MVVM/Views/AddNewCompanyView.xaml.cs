using SiesaExpenses.MVVM.ViewModels;

namespace SiesaExpenses.MVVM.Views;

public partial class AddNewCompanyView : ContentPage
{
    public AddNewCompanyView()
	{
		InitializeComponent();
		BindingContext = new AddNewCompanyViewModel();
	}

    private async void btnAddCompany_Clicked(object sender, EventArgs e)
    {
        var CurrentVM = (AddNewCompanyViewModel)BindingContext;
        var message = CurrentVM.AddCompany();
        await DisplayAlert("Mensage", message, "OK");
        await Navigation.PushAsync(new HomeView(CurrentVM.CurrentCompany.CompanyName));
    }

    private async void btnReturnShowCompanys_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HomeView(null));
    }
    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}