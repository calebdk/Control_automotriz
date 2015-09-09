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
    public partial class carros : Form
    {
        public carros(string username)
        {
            InitializeComponent();
            lblName.Text = username;
            this.ControlBox = false;

           
        }

        private void carros_Load(object sender, EventArgs e)
        {
            
            cargarTVehiculo();
            cargarTTitulo();
            cargarVenta();
           // history();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // codigo para visualizar datos en los textbox al dar click
            // en el DGV

            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvDatos.Rows[e.RowIndex];
                txtId.Text = row.Cells["id"].Value.ToString();

                txtMarca.Text = row.Cells["marca"].Value.ToString();
                txtModelo.Text = row.Cells["modelo"].Value.ToString();

                txtYear.Text = row.Cells["anio"].Value.ToString();

                txtNumero.Text = row.Cells["noSerie"].Value.ToString();
                txtColor.Text = row.Cells["color"].Value.ToString();
                txtPlacas.Text = row.Cells["placas"].Value.ToString();

                txtCostoV.Text = row.Cells["costo"].Value.ToString();
                txtPrecioV.Text = row.Cells["precioVenta"].Value.ToString();
                txtInversion.Text = row.Cells["inversion"].Value.ToString();

                txtGanancia.Text = row.Cells["ganancia"].Value.ToString();
                txtNotas.Text = row.Cells["notas"].Value.ToString();
                //txtColor.Text = row.Cells["color"].Value.ToString();


            }
        }
        // //////////////ajustarTablas ////////////////////////////////////////////////////////////////
        private void ajustar()
        {
            dgvDatos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        // //////////////////// Ver todos los datos ////////////////////////////////////////////////////
        private void btnVer_Click(object sender, EventArgs e)
        {
            verdatos();


        }
        // //////////////// Actualizar /////////////////////////////////
        private void btnModificar_Click(object sender, EventArgs e)
        {
            actualizarDatos();
        }

        private void btnVendidos_Click(object sender, EventArgs e)
        {
            Conexion.conectarme();
            string list = "SELECT * FROM datos INNER JOIN tipovehiculo ON datos.des_tipov=tipovehiculo.idtipovehiculo INNER JOIN tipotitulo ON datos.des_titulo=tipotitulo.idTip INNER JOIN vendido ON datos.des_vendido=vendido.idvendido WHERE des_vendido = 1 "; 
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

            dgvDatos.DataSource = dt;

            /*

            this.dgvDatos.Columns["des_tipov"].Visible = false;
            this.dgvDatos.Columns["des_titulo"].Visible = false;
            this.dgvDatos.Columns["des_vendido"].Visible = false;
            this.dgvDatos.Columns["idTip"].Visible = false;
            this.dgvDatos.Columns["idtipovehiculo"].Visible = false;
            this.dgvDatos.Columns["idvendido"].Visible = false;
            //this.dgvDatos.Columns["idtemporal"].Visible = false;
            //this.dgvDatos.Columns["usuario_venta"].Visible = false;
            this.dgvDatos.Columns["id"].Visible = false;
            */
            ajustar();

        }
     
          // ///////////////////////////////// Cargar El Combo Con los tipo de vehiculo //////////////
        private void cargarTVehiculo()
        {
            Conexion.conectarme();
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT tipo FROM tipovehiculo", Conexion.conectarme());
            adapter.Fill(ds, "tipovehiculo");
            cmbtipoV.DataSource = ds.Tables[0].DefaultView;
            cmbtipoV.ValueMember = "tipo";
            Conexion.desconectarme();
        }
        // ///////////////////////////////// Cargar El Combo Con los tipos titulo//////////////
        private void cargarTTitulo()
        {
            Conexion.conectarme();
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Tipo FROM tipotitulo", Conexion.conectarme());
            adapter.Fill(ds, "tipotitulo");
            cmbTitulo.DataSource = ds.Tables[0].DefaultView;
            cmbTitulo.ValueMember = "Tipo";
            Conexion.desconectarme();
        }
        // ///////////////////////////////// Cargar El Combo Con los tipos venta //////////////
        private void cargarVenta()
        {
            Conexion.conectarme();
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT vendido FROM vendido", Conexion.conectarme());
            adapter.Fill(ds, "vendido");
            cmbVendido.DataSource = ds.Tables[0].DefaultView;
            cmbVendido.ValueMember = "vendido";
            Conexion.desconectarme();
        }



        void verdatos()  // Para Listar los datos que estan guardados
        {


            Conexion.conectarme();
            string list = "SELECT * FROM datos INNER JOIN tipovehiculo ON datos.des_tipov=tipovehiculo.idtipovehiculo INNER JOIN tipotitulo ON datos.des_titulo=tipotitulo.idTip INNER JOIN vendido ON datos.des_vendido=vendido.idvendido"; //INNER JOIN temporal ON datos.usuario_venta=temporal.idtemporal";
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

            dgvDatos.DataSource = dt;

     
       
           this.dgvDatos.Columns["des_tipov"].Visible = false;
            this.dgvDatos.Columns["des_titulo"].Visible = false;
            this.dgvDatos.Columns["des_vendido"].Visible = false;
            this.dgvDatos.Columns["idTip"].Visible = false;
            this.dgvDatos.Columns["idtipovehiculo"].Visible = false;
            this.dgvDatos.Columns["idvendido"].Visible = false;
            //this.dgvDatos.Columns["idtemporal"].Visible = false;
            //this.dgvDatos.Columns["usuario_venta"].Visible = false;
            this.dgvDatos.Columns["id"].Visible = false;

            ajustar();

        }


        // //////////////////// Actualizacion de Datos /////////////////////////////////////////////////////////
        void actualizarDatos()
        {

            Conexion.conectarme();
            string query = "UPDATE datos SET marca = '" + this.txtMarca.Text +
                                            "',modelo='" + this.txtModelo.Text +
                                            "',des_tipov='" + this.cmbtipoV.SelectedIndex +
                                            "',anio='" + this.txtYear.Text +
                                            "',noSerie='" + this.txtNumero.Text +
                                            "',color='" + this.txtColor.Text +
                                             "',placas='" + this.txtPlacas.Text +  
                                             "',des_titulo='" + this.cmbTitulo.SelectedIndex +
                                             "',costo='" + this.txtCostoV.Text + 
                                             "',precioVenta='" + this.txtPrecioV.Text +
                                             "',inversion='" + this.txtInversion.Text +
                                             "',ganancia='" + this.txtGanancia.Text +
                                             "',des_vendido='" + this.cmbVendido.SelectedIndex +
                                             "',usuario_venta='" + this.lblName.Text +
                                             "',notas='" + this.txtNotas.Text +
                                            "' WHERE id='" + this.txtId.Text + "' ;";

            MySqlCommand comandoDB = new MySqlCommand(query, Conexion.conectarme());
            MySqlDataReader lector;

            try
            {

                if ((txtMarca.Text == "" ||
                    txtModelo.Text == ""||
                    txtYear.Text == "" ||
                    txtNumero.Text == "" ||
                    txtColor.Text == "" ||
                    txtPlacas.Text == "" ||
                    txtCostoV.Text == "" ||
                    txtPrecioV.Text == "" ||
                    txtInversion.Text == "" ||
                    txtGanancia.Text == "" ||
                    txtNotas.Text == ""))
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

                    Limpiar();
                  

                    //txtConsultarNombre.Focus();



                    verdatos();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            Control_Automotriz logearme = new Control_Automotriz();

             
            try
            {
                
                /*
                Conexion.conectarme();
                string query = "INSERT INTO datos(marca, des_tipov, anio, noSerie, color, placas, des_titulo, costo, precioVenta, inversion, ganancia, registro, des_vendido, usuario_venta)values('" 
                    + this.txtMarca.Text + "','" + this.cmbtipoV.SelectedIndex + "','" + this.txtYear.Text + "','" + this.txtNumero.Text + "','" + this.txtColor.Text + "','" + this.txtPlacas.Text + "','" + this.cmbTitulo.SelectedIndex + "','" + this.txtCostoV.Text + "','" + this.txtPrecioV.Text + "','" + this.txtInversion.Text + "','" + this.txtGanancia.Text + "','" + this.txtDate.Value + "','" + this.cmbVendido.SelectedIndex + "','" +  "');";

                MySqlCommand comando = new MySqlCommand(query, Conexion.conectarme());*/
                MySqlCommand cmd = new MySqlCommand("INSERT INTO datos (marca,modelo,des_tipov,anio,noSerie,color,placas,des_titulo,costo,precioVenta,inversion,ganancia,registro,des_vendido,usuario_venta,usuario_registro,notas) VALUES(@Ma, @Mo, @Des, @An, @Ser, @Co, @Pla, @Ti, @Cos, @PCos, @Inv, @Gan, @Reg, @DVen, @UsVen, @UsReg, @No)", Conexion.conectarme());
                //@Ma, @Des, @An, @Ser, @Co, @Pla, @Ti, @Cos, @PCos, @Inv, @Gan, @Reg, @DVen, @UsVen

                cmd.Parameters.AddWithValue("@Ma", txtMarca.Text);
                cmd.Parameters.AddWithValue("@Mo", txtModelo.Text);
                cmd.Parameters.AddWithValue("@Des", cmbtipoV.SelectedIndex);
                cmd.Parameters.AddWithValue("@An", txtYear.Text);
                cmd.Parameters.AddWithValue("@Ser", txtNumero.Text);
                cmd.Parameters.AddWithValue("@Co", txtColor.Text);
                cmd.Parameters.AddWithValue("@Pla", txtPlacas.Text);
                cmd.Parameters.AddWithValue("@Ti", cmbTitulo.SelectedIndex);
                cmd.Parameters.AddWithValue("@Cos", txtCostoV.Text);
                cmd.Parameters.AddWithValue("@PCos", txtPrecioV.Text);
                cmd.Parameters.AddWithValue("@Inv", txtInversion.Text);
                cmd.Parameters.AddWithValue("@Gan", txtGanancia.Text);
                cmd.Parameters.AddWithValue("@Reg", txtDate.Value);
                cmd.Parameters.AddWithValue("@DVen", cmbVendido.SelectedIndex);

                if (cmbVendido.SelectedIndex == 1)
                {
                    cmd.Parameters.AddWithValue("@UsVen", lblName.Text);// falta este vamosss !!!
                }
                else
                {
                    cmd.Parameters.AddWithValue("@UsVen", "");
                }
                cmd.Parameters.AddWithValue("@UsReg", lblName.Text);
                cmd.Parameters.AddWithValue("@No", txtNotas.Text);

                cmd.ExecuteNonQuery();
                Conexion.desconectarme();
                MessageBox.Show("Los Datos Fueron Capturados Correctamente");
                Limpiar();
                txtMarca.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Debe introducir los datos correctamente", "Error");
            }

            verdatos();

        }

        void Limpiar()
        {
            txtId.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtYear.Text = "";
            txtNumero.Text = "";
            txtColor.Text = "";
            txtPlacas.Text = "";
            txtCostoV.Text = "";
            txtPrecioV.Text = "";
            txtInversion.Text = "";
            txtGanancia.Text = "";
            txtNotas.Text = "";
        }
        

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            //Control_Automotriz logearme = new Control_Automotriz();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lblName.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnNoVendidos_Click(object sender, EventArgs e)
        {
            Conexion.conectarme();
            string list = "SELECT * FROM datos INNER JOIN tipovehiculo ON datos.des_tipov=tipovehiculo.idtipovehiculo INNER JOIN tipotitulo ON datos.des_titulo=tipotitulo.idTip INNER JOIN vendido ON datos.des_vendido=vendido.idvendido WHERE des_vendido = 0 "; 
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

            dgvDatos.DataSource = dt;

            

            this.dgvDatos.Columns["des_tipov"].Visible = false;
            this.dgvDatos.Columns["des_titulo"].Visible = false;
            this.dgvDatos.Columns["des_vendido"].Visible = false;
            this.dgvDatos.Columns["idTip"].Visible = false;
            this.dgvDatos.Columns["idtipovehiculo"].Visible = false;
            this.dgvDatos.Columns["idvendido"].Visible = false;
            //this.dgvDatos.Columns["idtemporal"].Visible = false;
            //this.dgvDatos.Columns["usuario_venta"].Visible = false;
            this.dgvDatos.Columns["id"].Visible = false;
            
            ajustar();

        }

        void Borar()//Borar
        ///////////////////////////////
        {
            try
            {

                if (dgvDatos.CurrentCell == null)
                {
                    MessageBox.Show("Debe seleccionar un Registro para borrar");
                    return;
                }

                if (MessageBox.Show(@"estas seguro de borrarlo?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Conexion.conectarme();
                    int renglon = dgvDatos.CurrentCell.RowIndex;
                    int id = (int)dgvDatos[0, renglon].Value;

                    string sql = "DELETE FROM datos WHERE id = " + id;
                    MySqlCommand comand = new MySqlCommand(sql, Conexion.conectarme());
                    comand.ExecuteNonQuery();

                    MessageBox.Show("Borrado Corectamente", "Exito");
                    dgvDatos.DataSource = null;
                    Conexion.desconectarme();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Borar();
        }

       

        
    }
}
