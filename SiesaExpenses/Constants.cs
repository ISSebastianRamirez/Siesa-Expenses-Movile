using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiesaExpenses
{
    public static class Constants //Calse para configuracion de la Base de Datos Sqlite
    {
        private const string DBFileName = "SiesaExpensesMovile.db3"; //Se configura el nombre de la base de datos
        public const SQLiteOpenFlags Falgs = //Configuracion del archvio 
            SQLiteOpenFlags.ReadWrite //Permite abrir la base de datos en un modo de lectura y escritura
                                      //Se agrega un segundo valor con el pipeline |
            | SQLiteOpenFlags.Create //Permite crear la base de datos en dado caso que no exista en el sistema opertativo
            | SQLiteOpenFlags.SharedCache; //Permite habiltar el acceso a la base de datos multi hilo
        
        public static string DataBasePath //Configurar la ruta de la base de datos
        {
            get 
            { 
                return Path.Combine(FileSystem.AppDataDirectory,DBFileName);
                //Almacena la base de datos en el directorio de informacion de la aplicacion
            }
        }
    }
}
