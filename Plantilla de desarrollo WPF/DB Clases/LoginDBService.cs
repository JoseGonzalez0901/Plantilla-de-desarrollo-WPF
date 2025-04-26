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

    }
}
