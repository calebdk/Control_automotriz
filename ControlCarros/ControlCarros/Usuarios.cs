using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/////////////Referencias//////////////
using MySql.Data.MySqlClient;
using System.IO;
using MySql.Data.Common;


namespace ControlCarros
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        

        private void btnCerrar_Click(object sender, EventArgs e)
        {
           Control_Automotriz logearme = new Control_Automotriz();
            //logearme.Show();
            
       
            //logearme.usuariosToolStripMenuItem.Enabled = true;
            
            this.Hide();
              
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            // ////////////// Al Cargar La forma //////////////////////////////////////////////
            cargarTipo();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            cargarUsuarios();
        }

        
    // /////////////////////////////Metodos ////////////////////////////////////////////////////////////


        ////////////////ajustar el contenido////////////
        private void ajustar()
        {
            dgvUsers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


        // //////////Las Modificaciones //////////////////////////////////////////////////////////

        private void btnMod_Click(object sender, EventArgs e)
        {
            actualizarDatos();
        }


        //  ////////////////////Borrar ////////////////////////////////////////////////////////
        private void btnEmpty_Click(object sender, EventArgs e)
        {
            Borrar();
        }


      // ///////// Agregar Nuevos Usuarios //////////////////////////////////////////
        private void btnNuevo_Click(object sender, EventArgs e)
        { 
            try{
            Conexion.conectarme();
                string query = "INSERT INTO usuarios(nick, pass, nombre, telefono, correo, tipo)values('" + this.txtNick.Text + "','" + this.txtPass.Text + "','" +  this.txtName.Text + "','" + this.txtTel.Text + "','" + this.txtMail.Text + "','" + this.cmbTipo.SelectedIndex + "');";
                                              
                MySqlCommand comando = new MySqlCommand(query, Conexion.conectarme());
                comando.ExecuteNonQuery();
                Conexion.desconectarme();
                MessageBox.Show("Los Datos Fueron Capturados Correctamente");
                Limpiar();
                txtNick.Focus();
            }
            catch(Exception)
            {
                MessageBox.Show("Debe introducir los datos correctamente", "Error");
            }

        }



         // ///////////////////////////////// Cargar El Combo Con los tipos de usuario //////////////
               private void cargarTipo()
        {
            Conexion.conectarme();
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT tipo FROM tipousuario", Conexion.conectarme());
            adapter.Fill(ds, "tipousuario");
            cmbTipo.DataSource = ds.Tables[0].DefaultView;
            cmbTipo.ValueMember = "tipo";
            Conexion.desconectarme();
         }


        // //////////////////Limpiar las Cajas de Texto ///////////////////////////////////////////////////
         private void Limpiar(){
             txtNick.Text = "";
             txtPass.Text = "";
             txtName.Text = "";
             txtTel.Text = "";
             txtMail.Text = "";
           }

     



         void cargarUsuarios()
         {

             
             Conexion.conectarme();
             string list = "SELECT * FROM usuarios INNER JOIN tipousuario ON usuarios.tipo=tipousuario.idTipo";
             MySqlDataAdapter ad = new MySqlDataAdapter(list, Conexion.conectarme());
             DataTable dt = new DataTable();

             /////////hacemos un cachador de errores/////////

             try
             {
                 ad.Fill(dt);
                
             }
             catch (Exception ex)
             {
                 MessageBox.Show("A ocurrido un Error" + ex.ToString(), Application.ProductName + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
             }

             dgvUsers.DataSource = dt;

             //this.dgvUsers.Colums["idusuarios"].Visible = false;
             this.dgvUsers.Columns["idusuarios"].Visible = false;
             this.dgvUsers.Columns["tipo"].Visible = false;
             this.dgvUsers.Columns["idTipo"].Visible = false;

             ajustar();
         
         }

         



        /// ////////////////////Metodo PAra las Modificaciones ////////////////////////////

        
         void actualizarDatos()
         {
             
             Conexion.conectarme();
             string query = "UPDATE usuarios SET nick = '" + this.txtNick.Text +
                                             "',pass='" + this.txtPass.Text +
                                             "',nombre='" + this.txtName.Text +
                                             "',telefono='" + this.txtTel.Text +
                                             "',correo='" + this.txtMail.Text +
                                              "',tipo='" + this.cmbTipo.SelectedIndex +
                                             "' WHERE nick='" + this.txtNick.Text + "' ;";

             MySqlCommand comandoDB = new MySqlCommand(query, Conexion.conectarme());
             MySqlDataReader lector;

             try
             {

                 if ((txtNick.Text == "" ||
                     txtPass.Text == "" ||
                     txtName.Text == "" ||
                     txtTel.Text == "" ||
                     txtMail.Text == ""||
                     cmbTipo.SelectedIndex == (0-1)))
                 {

                     MessageBox.Show("Revise los campos",
                                     "Advertencia",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);

                 }
                 else
                 {

                     Conexion.conectarme();
                     lector = comandoDB.ExecuteReader();
                     MessageBox.Show("Usuarios Actualizados");

                     while (lector.Read())
                     {


                     }


                     txtNick.Clear();
                     txtPass.Clear();
                     txtName.Clear();
                     txtTel.Clear();
                     txtMail.Clear();

                     //txtConsultarNombre.Focus();

          

                     cargarUsuarios();
                 }

             }
             catch (Exception ex)
             {

                 MessageBox.Show(ex.Message);

             }


         }

         private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
             // codigo para visualizar datos en los textbox al dar click
               // en el DGV

               if (e.RowIndex >= 0)
               {

                   DataGridViewRow row = this.dgvUsers.Rows[e.RowIndex];

                   txtNick.Text = row.Cells["nick"].Value.ToString();

                   txtPass.Text = row.Cells["pass"].Value.ToString();

                   txtName.Text = row.Cells["nombre"].Value.ToString();
                   txtTel.Text = row.Cells["telefono"].Value.ToString();
                   txtMail.Text = row.Cells["correo"].Value.ToString();

                   //cmbTipo.SelectedIndex = row.Cells["tipo"].Value.ToString();


               }
           }

        



        // ///////////////////////Borrar Usuarios /////////////////////////////////////////////////////
         void Borrar()//Borar
      
         {
             try
             {

                 if (dgvUsers.CurrentCell == null)
                 {
                     MessageBox.Show("Debe seleccionar un Usuario para borrar");
                     return;
                 }

                 if (MessageBox.Show(@"estas seguro de borrarlo?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                     Conexion.conectarme();
                     int renglon = dgvUsers.CurrentCell.RowIndex;
                     int id = (int)dgvUsers[0, renglon].Value;

                     string sql = "DELETE FROM usuarios WHERE idusuarios = " + id;
                     MySqlCommand comand = new MySqlCommand(sql, Conexion.conectarme());
                     comand.ExecuteNonQuery();

                     MessageBox.Show("Borrado Corectamente", "Exito");
                     dgvUsers.DataSource = null;
                     Conexion.desconectarme();
                 }
                 else
                 {

                 }
             }
             catch
             {
                 MessageBox.Show("Debe Seleccionar un Usuario para borar", "Error");
             }



         }

         }

    }

