using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiesaExpenses.MVVM.ViewModels
{
    public class HomeViewModel
    {
        public string GetFirstCompany()
        {
            var company = App.DBRepo.ShowFirstCompany();
            if (company.Count != 0)
            {
                return company.First().CompanyName;
            }
            else
            {
                return null;
            }
        }
    }
}
