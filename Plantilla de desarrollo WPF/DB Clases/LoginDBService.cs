using Plantilla_de_desarrollo_WPF.MVVM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plantilla_de_desarrollo_WPF.DB_Clases
{
    internal class LoginDBService
    {
        [Key]
        public int ID_Empleado { get; set; }
        public string  Usuario{ get; set; }
        public string Clave { get; set; }

        public static LoginDBService Current_Person { get; set; } = new LoginDBService();
        public void Register_user(LoginDBService loginDBService)
        {
            AppDbContext context = new AppDbContext();
            DatabaseManager<LoginDBService> dbManager = new DatabaseManager<LoginDBService>(context);
            dbManager.Add(loginDBService);
            ////TODO Revisar el estado OK

        }
        public bool LoginUser(int ID,string clave)
        {
            AppDbContext context = new AppDbContext();
            DatabaseManager<LoginDBService> dbManager = new DatabaseManager<LoginDBService>(context);
            LoginDBService user = dbManager.GetById(ID);
            if (user == null)
            {
                System.Windows.MessageBox.Show("Usuario no encontrado");
                return false;
            }
            else
            {
                if (user.Clave == clave)
                {
                    System.Windows.MessageBox.Show("Bienvenido " + user.Usuario);
                    Current_Person = user;
                    return true;

                }
                else
                {
                    System.Windows.MessageBox.Show("Contraseña incorrecta");
                    return false;
                }
            }
            
        }

    }
}
