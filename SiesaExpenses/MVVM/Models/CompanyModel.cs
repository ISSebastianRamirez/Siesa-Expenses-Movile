using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiesaExpenses.MVVM.Models
{
    [Table("Companys")]
    public class CompanyModel
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(10)]
        public string CompanyName { get; set; }
    }
}
