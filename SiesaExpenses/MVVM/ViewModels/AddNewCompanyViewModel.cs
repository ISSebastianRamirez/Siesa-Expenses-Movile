using SiesaExpenses.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiesaExpenses.MVVM.ViewModels
{
    public class AddNewCompanyViewModel
    {
        public CompanyModel CurrentCompany { get; set; } = new CompanyModel();
        public string AddCompany()
        {
            App.DBRepo.AddCompany(CurrentCompany);
            return App.DBRepo.StatusMessage;
        }
    }
}
