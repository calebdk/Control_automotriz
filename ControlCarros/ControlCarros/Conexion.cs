using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//dependencias que se agregan para la conexion

using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ControlCarros
{
    class Conexion
    {

        //metodo para la coneccion a la base de datos
        public static MySqlConnection conectarme()
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=carros; Uid=root; pwd='';");
            conectar.Open();
            return conectar;
        }

        //cerrar la conexion a la base de datos
        public static void desconectarme()
        {
            MySqlConnection conectar = new MySqlConnection();
            conectar.Close();
        }

        
    }
}
