using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// /////////////////////////////////////
using MySql.Data.MySqlClient;
using System.IO;
using MySql.Data.Common;

namespace ControlCarros
{
    public partial class caracteristicas : Form
    {
        public caracteristicas()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
// ///////////////////////////////Desbloquear Caracteristicas ////////////////////////////////////////////////////////
        private void caracteristicas_Load(object sender, EventArgs e)
        {
            gbTitulo.Enabled = false;
            gbtAutos.Enabled = false;
            gbtVentas.Enabled = false;
        }

        private void btnEnable1_Click(object sender, EventArgs e)
        {
            gbTitulo.Enabled = true;
            if (gbTitulo.Enabled == true)
            {
                gbtAutos.Enabled = false;
                gbtVentas.Enabled = false;
            }
        }
        private void btnEnable2_Click(object sender, EventArgs e)
        {
            gbtAutos.Enabled = true;
            if (gbtAutos.Enabled == true)
            {
                gbTitulo.Enabled = false;
                gbtVentas.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gbtVentas.Enabled = true;
            if (gbtVentas.Enabled == true)
            {
                gbTitulo.Enabled = false;
                gbtAutos.Enabled = false;
            }
        }
// ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Control_Automotriz logearme = new Control_Automotriz();

            this.Hide();
        }


// ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnTitulo_Click(object sender, EventArgs e)
        {
            agregarTitulo();
        }
// /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnDeleteT_Click(object sender, EventArgs e)
        {
            Borrar();
        }
/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnUpdateT_Click(object sender, EventArgs e)
        {
            UpdateTitulo();
        }
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnSeeA_Click(object sender, EventArgs e)
        {
            verAutos();
        }
 // /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnSaveA_Click(object sender, EventArgs e)
        {
            agregarVehiculo();
        }
// /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnDeleteA_Click(object sender, EventArgs e)
        {
            BorrarVehiculo();
        }

// /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnUpdateA_Click(object sender, EventArgs e)
        {
            updateAutos();
        }

// ///////////////////////////////////////////////////////////////////////////////////////////
        private void txtverVentas_Click(object sender, EventArgs e)
        {
            verVentas();
        }
// /////////////////////////////////////////////////////////////////////////////////////////////
        private void btnSaveVentas_Click(object sender, EventArgs e)
        {
            guardarVentas();
        }
// //////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnDelVentas_Click(object sender, EventArgs e)
        {
            BorrarVentas();
        }
// ///////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnUpdateSale_Click(object sender, EventArgs e)
        {
            updateVentaas();
        }






        // ///////////////////////////////////////////////////////////////////////////////////
        private void btnReadT_Click(object sender, EventArgs e)
        {
            verTitulos();
         }

        private void dgvTitulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // codigo para visualizar datos en los textbox al dar click
            // en el DGV

            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvTitulo.Rows[e.RowIndex];

                //nmrTitulo.Value = row.Cells["idTip"].Value.ToString();
                //nmrTitulo.SetBounds = row.Cells["idTip"].Value.ToString();
                txtidTitulo.Text = row.Cells["idTip"].Value.ToString();
                txtTitulo.Text = row.Cells["Tipo"].Value.ToString();
                
            }
        
        }
       
//////////////////////////////////////////////////////////////////////////////////////////////////////////

        void agregarTitulo()
        {
             try{
            Conexion.conectarme();
                string query = "INSERT INTO tipotitulo(idTip, Tipo)values('" + this.txtidTitulo.Text + "','" + this.txtTitulo.Text + "');";
                                              
                MySqlCommand comando = new MySqlCommand(query, Conexion.conectarme());
                comando.ExecuteNonQuery();
                Conexion.desconectarme();
                MessageBox.Show("Los Datos Fueron Capturados Correctamente");
                txtidTitulo.Text = "";
                txtTitulo.Text = "";
                txtTitulo.Focus();
                verTitulos();
            }
            catch(Exception)
            {
                MessageBox.Show("Debe introducir los datos correctamente", "Error");
            }

        }
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        void verTitulos()
        {
            Conexion.conectarme();
            string list = "SELECT * FROM tipotitulo";
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

            dgvTitulo.DataSource = dt;
            dgvTitulo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //this.dgvTitulo.Columns["idTip"].Visible = false;


            //ajustar();
         
        }

  // /////////////////////////////////////////////////////////////////////////////////////////////////////////////      
        void Borrar()//Borar
        ///////////////////////////////
        {
            try
            {

                if (dgvTitulo.CurrentCell == null)
                {
                    MessageBox.Show("Debe seleccionar un Registro para borrar");
                    return;
                }

                if (MessageBox.Show(@"estas seguro de borrarlo?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Conexion.conectarme();
                    int renglon = dgvTitulo.CurrentCell.RowIndex;
                    int id = (int)dgvTitulo[0, renglon].Value;

                    string sql = "DELETE FROM tipotitulo WHERE idTip = " + id;
                    MySqlCommand comand = new MySqlCommand(sql, Conexion.conectarme());
                    comand.ExecuteNonQuery();

                    MessageBox.Show("Borrado Corectamente", "Exito");
                    dgvTitulo.DataSource = null;
                    Conexion.desconectarme();
                    verTitulos();
                }
                else
                {

                }
            }
            catch
            {
                MessageBox.Show("Debe Seleccionar un Registro para borar", "Error");
            }

        }

      

     // //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void UpdateTitulo()
        {
            Conexion.conectarme();
            string query = "UPDATE tipotitulo SET Tipo = '" + this.txtTitulo.Text +
                                            "' WHERE idTip='" + this.txtidTitulo.Text + "' ;";

            MySqlCommand comandoDB = new MySqlCommand(query, Conexion.conectarme());
            MySqlDataReader lector;

            try
            {

                if ((txtTitulo.Text == ""))
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
                    MessageBox.Show("Datos Actualizados");

                    while (lector.Read())
                    {


                    }

                    txtTitulo.Text = "";
                    txtidTitulo.Text = "";
                    verTitulos();

                   
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        // ///////////////////////////////Aqui empiezan metodos del segundo bloque //////////////////////////////////////
        void verAutos()
        {
            Conexion.conectarme();
            string list = "SELECT * FROM tipovehiculo";
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

            dgvAutos.DataSource = dt;
            //dgvTitulo.DataSource = dt;
            dgvAutos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //this.dgvTitulo.Columns["idTip"].Visible = false;


            //ajustar();

        }

       // ////////////////////////////////////////////////////////////////////////////////////////////////

        void agregarVehiculo()
        {
            try
            {
                Conexion.conectarme();
                string query = "INSERT INTO tipovehiculo(idtipovehiculo, tipo)values('" + this.txtidAutos.Text + "','" + this.txtAutos.Text + "');";

                MySqlCommand comando = new MySqlCommand(query, Conexion.conectarme());
                comando.ExecuteNonQuery();
                Conexion.desconectarme();
                MessageBox.Show("Los Datos Fueron Capturados Correctamente");
                
                txtidAutos.Text = "";
                txtAutos.Text = "";
                txtAutos.Focus();
                verAutos();
            }
            catch (Exception)
            {
                MessageBox.Show("Debe introducir los datos correctamente", "Error");
            }

        }

       

     // /////////////////////////////////////////////////////////////////////////////////////////////////

        void BorrarVehiculo()//Borar
        ///////////////////////////////
        {
            try
            {

                if (dgvAutos.CurrentCell == null)
                {
                    MessageBox.Show("Debe seleccionar un Registro para borrar");
                    return;
                }

                if (MessageBox.Show(@"estas seguro de borrarlo?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Conexion.conectarme();
                    int renglon = dgvAutos.CurrentCell.RowIndex;
                    int id = (int)dgvAutos[0, renglon].Value;

                    string sql = "DELETE FROM tipovehiculo WHERE idtipovehiculo = " + id;
                    MySqlCommand comand = new MySqlCommand(sql, Conexion.conectarme());
                    comand.ExecuteNonQuery();

                    MessageBox.Show("Borrado Corectamente", "Exito");
                    dgvAutos.DataSource = null;
                    Conexion.desconectarme();

                    txtidAutos.Text = "";
                    txtAutos.Text = "";
                    txtAutos.Focus();
                    verAutos();
                }
                else
                {

                }
            }
            catch
            {
                MessageBox.Show("Debe Seleccionar un Registro para borar", "Error");
            }

        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////

        void updateAutos()
        {
            Conexion.conectarme();
            string query = "UPDATE tipovehiculo SET tipo = '" + this.txtAutos.Text+
                                            "' WHERE idtipovehiculo='" + this.txtidAutos.Text + "' ;";

            MySqlCommand comandoDB = new MySqlCommand(query, Conexion.conectarme());
            MySqlDataReader lector;

            try
            {

                if ((txtAutos.Text == ""))
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
                    MessageBox.Show("Datos Actualizados");

                    while (lector.Read())
                    {


                    }

                    txtAutos.Text = "";
                    txtidAutos.Text = "";
                    verAutos();

                   
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        private void dgvAutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvAutos.Rows[e.RowIndex];

                //nmrTitulo.Value = row.Cells["idTip"].Value.ToString();
                //nmrTitulo.SetBounds = row.Cells["idTip"].Value.ToString();
                txtidAutos.Text = row.Cells["idtipovehiculo"].Value.ToString();
                txtAutos.Text = row.Cells["tipo"].Value.ToString();

            }
        }

    // //////////////////////////////////// TERCER BLOQUE ///////////////////////////////////////////////////////

        void verVentas()
        {
            Conexion.conectarme();
            string list = "SELECT * FROM vendido";
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

            dgvSale.DataSource = dt;
            //dgvTitulo.DataSource = dt;
            dgvSale.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //this.dgvTitulo.Columns["idTip"].Visible = false;


            //ajustar();
        }
// ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        void guardarVentas()
        {
            try
            {
                Conexion.conectarme();
                string query = "INSERT INTO vendido(idvendido, vendido)values('" + this.txtidVenta.Text + "','" + this.txtventas.Text + "');";

                MySqlCommand comando = new MySqlCommand(query, Conexion.conectarme());
                comando.ExecuteNonQuery();
                Conexion.desconectarme();
                MessageBox.Show("Los Datos Fueron Capturados Correctamente");

                txtidVenta.Text = "";
                //txtidVentas.Text = "";
                txtventas.Text = "";
                txtventas.Focus();
                verVentas();
            }
            catch (Exception)
            {
                MessageBox.Show("Debe introducir los datos correctamente", "Error");
            }

        }
// //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void BorrarVentas()//Borar
        ///////////////////////////////
        {
            try
            {

                if (dgvSale.CurrentCell == null)
                {
                    MessageBox.Show("Debe seleccionar un Registro para borrar");
                    return;
                }

                if (MessageBox.Show(@"estas seguro de borrarlo?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Conexion.conectarme();
                    int renglon = dgvSale.CurrentCell.RowIndex;
                    int id = (int)dgvSale[0, renglon].Value;

                    string sql = "DELETE FROM vendido WHERE idvendido = " + id;
                    MySqlCommand comand = new MySqlCommand(sql, Conexion.conectarme());
                    comand.ExecuteNonQuery();

                    MessageBox.Show("Borrado Corectamente", "Exito");
                    dgvSale.DataSource = null;
                    Conexion.desconectarme();
                    
                    
                    txtidVenta.Text = "";
                    txtventas.Text = "";
                    txtventas.Focus();
                    verVentas();
                }
                else
                {

                }
            }
            catch
            {
                MessageBox.Show("Debe Seleccionar un Registro para borar", "Error");
            }

        }
    // ///////////////////////////////////////////////////////////////////////////////////////////////////
        private void dgvSale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvSale.Rows[e.RowIndex];

                //nmrTitulo.Value = row.Cells["idTip"].Value.ToString();
                //nmrTitulo.SetBounds = row.Cells["idTip"].Value.ToString();
                txtidVenta.Text = row.Cells["idvendido"].Value.ToString();
                txtventas.Text = row.Cells["vendido"].Value.ToString();

            }
        }

       
     // ///////////////////////////////////////////////////////////////////////////////////////////////////////////  

        void updateVentaas()
        {
            Conexion.conectarme();
            string query = "UPDATE vendido SET vendido = '" + this.txtventas.Text +
                                            "' WHERE idvendido='" + this.txtidVenta.Text + "' ;";

            MySqlCommand comandoDB = new MySqlCommand(query, Conexion.conectarme());
            MySqlDataReader lector;

            try
            {

                if ((txtventas.Text == ""))
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
                    MessageBox.Show("Datos Actualizados");

                    while (lector.Read())
                    {


                    }

                    txtventas.Text = "";
                    txtidVenta.Text = "";
                    verVentas();


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

      

    }
}
