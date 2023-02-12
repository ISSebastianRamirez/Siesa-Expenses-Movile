using SiesaExpenses.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using System.Windows.Input;
using System.Collections.ObjectModel;
using SiesaExpenses.MVVM.Views;
using Microsoft.Maui.ApplicationModel;

namespace SiesaExpenses.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class ShowCompanysViewModel
    {
        public List<CompanyModel> Companys { get; set; }
        public ObservableCollection<CompanyModel> Company { get; set; } = new ObservableCollection<CompanyModel>();
        public CompanyModel CurrentCompany { get; set;} = new CompanyModel();
        
        public ICommand GoCompanyCommand { get; private set; }
        public ICommand RemoveCompanyCommand { get; private set; }
        public ShowCompanysViewModel()
        {
            Refresh();
            GoCompanyCommand = new Command<CompanyModel>(GoCompany);
            RemoveCompanyCommand = new Command<CompanyModel>(RemoveCompany);
        }
        public void Refresh()
        {
            Companys = App.DBRepo.ShowAll();
        }
        public void RemoveCompany(CompanyModel Compnay)
        {
            App.DBRepo.DeleteCompany(Compnay.CompanyName);
            Company.Remove(Compnay);
            Refresh();
        }
        public void GoCompany(CompanyModel Compnay)
        {
            ShowCompanysView.name= Compnay.CompanyName;
        }
    }
}
