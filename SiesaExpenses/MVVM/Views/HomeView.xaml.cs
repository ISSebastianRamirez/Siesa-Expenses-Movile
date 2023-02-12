using SiesaExpenses.MVVM.ViewModels;

namespace SiesaExpenses.MVVM.Views;

public partial class HomeView : FlyoutPage
{
    HomeViewModel goaddVM = new HomeViewModel();
    public HomeView(string company)
	{
		InitializeComponent();
		SourceURL(company);
	}
    protected override bool OnBackButtonPressed()
    {
        return true;
    }
    private void SourceURL(string companyname)
	{
        if (companyname != null)
        {
            var url = "https://siesaexpenses.com/?cia=" + companyname;
            wvCompany.Source = url;
        }
        else
        {
            companyname = SourceCompany();
            var url = "https://siesaexpenses.com/?cia=" + companyname;
            wvCompany.Source = url;
        }
	}

    private void GoAdd_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddNewCompanyView());
    }
    private string SourceCompany()
    {
        var company = goaddVM.GetFirstCompany();
        if (company != null)
        {
            return company;
        }
        else
        {
            Navigation.PushAsync(new AddNewCompanyView());
            return null;
        }
    }

    private void GoShow_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ShowCompanysView());
    }

    private void GoHome_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HomeView(null));
    }
}