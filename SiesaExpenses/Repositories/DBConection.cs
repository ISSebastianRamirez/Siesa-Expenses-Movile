using SiesaExpenses.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SiesaExpenses.Repositories
{
    public class DBConection //Conexion para la base de datos
    {
        SQLiteConnection conn;
        public string StatusMessage { get; set; }
        public DBConection()
        {
            conn = new SQLiteConnection(Constants.DataBasePath,Constants.Falgs);
            conn.CreateTable<CompanyModel>(); //Se ejecuta unicamente cuando la tabla no existe
        }
        public void AddCompany(CompanyModel NewCompany) //Agregar una compañia
        {
            var result = 0;
            if (NewCompany.CompanyName != null)
            {
                try
                {
                    result = conn.Insert(NewCompany);
                    StatusMessage = $"Se ha agreagdo la compañía {NewCompany.CompanyName}";
                }
                catch (Exception ex)
                {
                    StatusMessage = $"Se ha producido un error{ex.Message}";
                    throw;
                }
            }
            else
            {
                StatusMessage = "Ingresa un nombre de compañía";
            }
}
        public List<CompanyModel> ShowAll() //Mostrar todas las compañias
        {
            try
            {
                return conn.Table<CompanyModel>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Se ha producido un error{ex.Message}";
                throw;
            }
        }
        public CompanyModel GetByName(string CompanyName) //Buscar compañia por nombre
        {
            if (CompanyName != null)
            {
                try
                {
                    return conn.Table<CompanyModel>().FirstOrDefault(x => x.CompanyName == CompanyName);
                    //Usando FirstOrDefault nos devuelve nulo en dado caso de que no encuentre nada
                }
                catch (Exception ex)
                {
                    StatusMessage = $"Se ha producido un error{ex.Message}";
                    throw;
                }
            }
            else
            {
                StatusMessage = "Elije una compañía, si no tienes agrega una";
                return null;
            }
        }
        public List<CompanyModel> ShowFirstCompany() //Mostrar la primera compañia que encuentre
            //Realizar una consulta a la tabla con Query
        {
            try
            {
                return conn.Query<CompanyModel>("SELECT CompanyName FROM Companys").ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Se ha producido un error{ex.Message}";
                throw;
            }
        }
        public void DeleteCompany(string CompanyName)
        {
            if (CompanyName != null)
            {
                try
                {
                    var company = GetByName(CompanyName);
                    conn.Delete(company);
                    StatusMessage = $"Se ha eliminado la compañia {CompanyName}";
                }
                catch (Exception ex)
                {
                    StatusMessage = $"Se ha producido un error{ex.Message}";
                    throw;
                }
            }
            else
            {
                StatusMessage = "Elije una compañía, si no tienes agrega una";
            }
        }
    }
}
