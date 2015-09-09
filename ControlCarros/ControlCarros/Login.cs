using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
////////////////////////////////////////Referencia////////////////////////////////////////////////
using MySql.Data.MySqlClient;
using System.IO;
using MySql.Data.Common;

namespace ControlCarros
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
            this.ControlBox = false;
            txtNick.Focus();
        }
       //public string usuario;

       

        private void Login_Load(object sender, EventArgs e)//Aqui es donde carga  la Forma de Inicio
        {
            
            txtPass.Text = "";
            txtPass.PasswordChar = '*';
            txtPass.MaxLength = 20;
            cargarTipo();

        }
        // ///////////////////////////////// Cargar El Combo Con los tipos de usuario //////////////
        private void cargarTipo()
        {
            Conexion.conectarme();
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT tipo FROM tipousuario", Conexion.conectarme());
            adapter.Fill(ds, "tipousuario");
            cmbttipo.DataSource = ds.Tables[0].DefaultView;
            cmbttipo.ValueMember = "tipo";
            Conexion.desconectarme();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(txtPass.Text);
             myLogin();
            // Temporal();

            
        }


        /// Metodos/////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Limpiar()
        {
            txtNick.Text = "";
            txtPass.Text = "";
            txtNick.Focus();
        }

        private void myLogin()
        {

            if (txtNick.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Por favor llene todos los campos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Conexion.conectarme();
                    MySqlCommand comand = new MySqlCommand("SELECT * FROM usuarios WHERE nick ='" + txtNick.Text + "'AND pass ='" + txtPass.Text + "'AND tipo ='" + cmbttipo.SelectedIndex + "'", Conexion.conectarme());
                    DataSet ds = new DataSet();
                    MySqlDataAdapter da = new MySqlDataAdapter(comand);


                    //llenando el dataAdapter
                    da.Fill(ds, "nick");
                    //utilizado para represnetar una fila de la tabla que se necesita
                    DataRow dr;
                    if (ds.Tables["nick"].Rows.Count == 0) //checar si hay resultados o no
                    {

                        MessageBox.Show("Su contraseña y/o Usuario  y/o Permisos Son Incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        Limpiar();

                    }
                    else
                    {
                        dr = ds.Tables["nick"].Rows[0];
                        //evaluando que la contrasena y usuario sean correctos
                        if ((txtNick.Text == dr["nick"].ToString()) || (txtPass.Text == dr["pass"].ToString()))
                        {
                            //instanciando el formulario o forma principal
                           // usuario = txtNick.Text;
                            MessageBox.Show("Bienvenido/a " + txtNick.Text + "!", "Conexion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Conexion.desconectarme();

                            // Aqui Cremos Archivos Temporales
                            //Temporal();/////////////////////////
                           //////////////////////////////////////////////////
                            Control_Automotriz logearme = new Control_Automotriz();
                           // logearme.lblnombre.Text = dr["nick"].ToString();
                            logearme.Show();
                            this.Hide();


                            //Ponemos el nombre del usuario y tipo en la parte de abajo
                            logearme.toolStripStatusLabel2.Text = "Usuario: " + txtNick.Text + "  *** " + " Cargo: " + cmbttipo.Text.ToString();
                     
                          

                            /// //  Aqui es donde se determinan los permisos /////////////////////////
                            if(cmbttipo.SelectedIndex.ToString() == "0"){

                            logearme.caracteristicasToolStripMenuItem.Enabled = true;
                            logearme.usuariosToolStripMenuItem.Enabled = true;
                            }else{
                                //Bloquear caracteristicas
                                logearme.usuariosToolStripMenuItem.Enabled = false;
                                logearme.caracteristicasToolStripMenuItem.Enabled = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Su contraseña y/o Usuario  y/o Permisos Son Incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            Limpiar();
                        }
                    }

                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error!\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        
     





    }
}
