using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

using System.IO;

using MySql.Data.MySqlClient;
using MySql.Data.Common;

using nmExcel = Microsoft.Office.Interop.Excel; //esta referencia es para poder crear el archivo de excell
using System.Net.Mail; // esta es la directiva que se utiliza para mandar email
using System.Net; // directiva para email


namespace ControlCarros
{
    public partial class reportes : Form
    {
        // variale tabla global

        DataTable Tabla;
        imprimir dgvlistaprinter;

       // private bool adj = false;
       // private string archivo;

        public reportes()
        {
            InitializeComponent();
            this.ControlBox = false;
            AutoCompletadoTextBox();
            AutoFiltradoDGV();
        }
        

        

        private void reportes_Load(object sender, EventArgs e)
        {

            CargaDatos();
        }

        void CargaDatos()
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

            dgvReportes.DataSource = dt;



            this.dgvReportes.Columns["des_tipov"].Visible = false;
            this.dgvReportes.Columns["des_titulo"].Visible = false;
            this.dgvReportes.Columns["des_vendido"].Visible = false;
            this.dgvReportes.Columns["idTip"].Visible = false;
            this.dgvReportes.Columns["idtipovehiculo"].Visible = false;
            this.dgvReportes.Columns["idvendido"].Visible = false;
            //this.dgvDatos.Columns["idtemporal"].Visible = false;
            //this.dgvDatos.Columns["usuario_venta"].Visible = false;
            this.dgvReportes.Columns["id"].Visible = false;
            //this.dgvReportes.Columns["usuario_venta"].Visible = false;
            //this.dgvReportes.Columns["usuario_registro"].Visible = false;



            ajustar();
            stylo();
        }
// ////////////////////////////////////////////////////////////////////////////////////////////////////////
        void ajustar()
        {
            dgvReportes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        void stylo()
        {
            dgvReportes.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            dgvReportes.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            dgvReportes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvReportes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReportes.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            dgvReportes.DefaultCellStyle.BackColor = Color.Empty;
            dgvReportes.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
            dgvReportes.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvReportes.GridColor = SystemColors.ControlDarkDark;
        }
       
       

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Se establece la variable DV utilizado la variable global tabla
            try
            {
                DataView DV = new DataView(Tabla);

                // Aqui filtro mediante el texbox, lo que sea que escriba me lo muestra

                DV.RowFilter = string.Format("marca LIKE '%{0}%'", txtBuscar.Text);

                dgvReportes.DataSource = DV;
                // le pongo de donde obtendra la fuente de filtrado el dgv
                // dgvReportes.DataSource = DV;

                this.dgvReportes.Columns["des_tipov"].Visible = false;
                this.dgvReportes.Columns["des_titulo"].Visible = false;
                this.dgvReportes.Columns["des_vendido"].Visible = false;
                this.dgvReportes.Columns["idTip"].Visible = false;
                this.dgvReportes.Columns["idtipovehiculo"].Visible = false;
                this.dgvReportes.Columns["idvendido"].Visible = false;
                //this.dgvDatos.Columns["idtemporal"].Visible = false;
                //this.dgvDatos.Columns["usuario_venta"].Visible = false;
                this.dgvReportes.Columns["id"].Visible = false;
            }
            catch
            {
                MessageBox.Show("No hay datos");
                CargaDatos();
            }
        }
// ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////// aUtocompletado ////////////////////////////
        void AutoCompletadoTextBox()
        {

            // llamamos a la clase conexion y su metodo conectar para abrir la conexion

            Conexion.conectarme();

            // Lo siguiente son propiedades de un textbox para el autocompletado

            txtBuscar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            // el comando se utiliara para mostrar los nombres en la lista de sugerencias de 
            //  autocompletado cuando se teclee algo 

            string consulta = "SELECT  marca FROM datos";

            // Establecemos la variable que utilizaremos para efectuar el comando,
            // y a su vez, se le dice hacia donde mandamos la orden (en la base de datos)

            MySqlCommand comandoconsulta = new MySqlCommand(consulta, Conexion.conectarme());

            // el lector se utiliza para efectuar una lectura de datos

            MySqlDataReader lector;

            try
            {

                /*el lector tomara el comando SQL*/
                lector = comandoconsulta.ExecuteReader();

                while (lector.Read())
                {
                    /*Mientras la lectura ocurra...que se obtiene el valor
                         * de la tabla del campo nombre*/

                   
                    string SValor = lector.GetString("marca");
                    coll.Add(SValor);

                }

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

            txtBuscar.AutoCompleteCustomSource = coll;

        }


        /// /////////////////////////////////////////Metodo para el filtrado y que se refleje en la tabla

        void AutoFiltradoDGV()
        {

            // aca el codigo para que se filtre lo que se esta escrito en el textbox
            // se refleje en el datagridvieww

            Conexion.conectarme();

            MySqlCommand comandoDB = new MySqlCommand("SELECT * FROM datos INNER JOIN tipovehiculo ON datos.des_tipov=tipovehiculo.idtipovehiculo INNER JOIN tipotitulo ON datos.des_titulo=tipotitulo.idTip INNER JOIN vendido ON datos.des_vendido=vendido.idvendido;", Conexion.conectarme()); 
            try{
                MySqlDataAdapter lector = new MySqlDataAdapter();
                lector.SelectCommand = comandoDB;
                Tabla = new DataTable();
                lector.Fill(Tabla);
                BindingSource bFuente = new BindingSource();

                bFuente.DataSource = Tabla;
                dgvReportes.DataSource = bFuente;
                lector.Update(Tabla);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

            AjustarDGV();

           this.dgvReportes.Columns["des_tipov"].Visible = false;
           this.dgvReportes.Columns["des_titulo"].Visible = false;
           this.dgvReportes.Columns["des_vendido"].Visible = false;
           this.dgvReportes.Columns["idTip"].Visible = false;
           this.dgvReportes.Columns["idtipovehiculo"].Visible = false;
           this.dgvReportes.Columns["idvendido"].Visible = false;
            //this.dgvDatos.Columns["idtemporal"].Visible = false;
            //this.dgvDatos.Columns["usuario_venta"].Visible = false;
           this.dgvReportes.Columns["id"].Visible = false;

        }
        private void AjustarDGV()
        {
            dgvReportes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        

        private void btnExcell_Click(object sender, EventArgs e)
        {
            //boton para mandar a excel
            nmExcel.Application ExcelApp = new nmExcel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 12;
            for (int i = 0; i < dgvReportes.Rows.Count; i++)
            {
                DataGridViewRow Fila = dgvReportes.Rows[i];
                for (int j = 0; j < Fila.Cells.Count; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = Fila.Cells[j].Value;
                }
            }


            // ---------- cuadro de dialogo para Guardar

            SaveFileDialog CuadroDialogo = new SaveFileDialog();
            CuadroDialogo.DefaultExt = "xlsx";
            CuadroDialogo.Filter = "xlsx file(*.xlsx)|*.xlsx";
            CuadroDialogo.AddExtension = true;
            CuadroDialogo.RestoreDirectory = true;
            CuadroDialogo.Title = "Guardar";
            CuadroDialogo.InitialDirectory = @"c:\";
            if (CuadroDialogo.ShowDialog() == DialogResult.OK)
            {
                ExcelApp.ActiveWorkbook.SaveCopyAs(CuadroDialogo.FileName);
                ExcelApp.ActiveWorkbook.Saved = true;
                CuadroDialogo.Dispose();
                CuadroDialogo = null;
                ExcelApp.Quit();
                MessageBox.Show("Documento Creado y  Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("No se pudo guardar Datos .. ","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       

      

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = Mydocumento;
                MyPrintPreviewDialog.ShowDialog();
            }
        }
// //////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
                Mydocumento.Print();
        }
// ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Mydocumento_PrintPage(object sender, PrintPageEventArgs e)
        {
            //boton mandar imprimir el datagridview
            bool more = dgvlistaprinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;

        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool SetupThePrinting()

          //con este codigo generamos un documento virtual
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            Mydocumento.DocumentName = "Control Automotriz";
            Mydocumento.PrinterSettings = MyPrintDialog.PrinterSettings;
            Mydocumento.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            Mydocumento.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);


            //codigo para imprimir o visualizar

            if (MessageBox.Show("quiere el reporte en el centro de la pagina?", "Administrador de pagina - centrado de pagina", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgvlistaprinter = new imprimir(dgvReportes, Mydocumento, true, true, "Vehiculos", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgvlistaprinter = new imprimir(dgvReportes, Mydocumento, false, true, "Vehiculos", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

            this.Hide();
        }
        // ////////////////////////////////PREFERENCIAS DEL USUARIO A IMPRIMIR /////////////////////////////////////
        private void btnPreferencias_Click(object sender, EventArgs e)
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

            dgvReportes.DataSource = dt;

            if (chkMarca.Checked == false)
            {
                this.dgvReportes.Columns["marca"].Visible = false;
            }
            if (chkModelo.Checked == false)
            {
                this.dgvReportes.Columns["modelo"].Visible = false;
            }
            if (chkYear.Checked == false)
            {
                this.dgvReportes.Columns["anio"].Visible = false;
            }
            if (chkNumeroS.Checked == false)
            {
                this.dgvReportes.Columns["noSerie"].Visible = false;
            }
            if (chkColor.Checked == false)
            {
                this.dgvReportes.Columns["color"].Visible = false;
            }
            if (chkPlacas.Checked == false)
            {
                this.dgvReportes.Columns["placas"].Visible = false;
            }
            if (chkCosto.Checked == false)
            {
                this.dgvReportes.Columns["costo"].Visible = false;
            }
            if (chkPVenta.Checked == false)
            {
                this.dgvReportes.Columns["precioVenta"].Visible = false;
            }
            if (chkInversion.Checked == false)
            {
                this.dgvReportes.Columns["inversion"].Visible = false;
            }
            if (chkGanancia.Checked == false)
            {
                this.dgvReportes.Columns["ganancia"].Visible = false;
            }
            if (chkFReg.Checked == false)
            {
                this.dgvReportes.Columns["registro"].Visible = false;
            }
            if (chkTVehiculo.Checked == false)
            {
                //this.dgvReportes.Columns["des_tipov"].Visible = false;
                //this.dgvReportes.Columns["idtipovehiculo"].Visible = false;
                this.dgvReportes.Columns["tipo"].Visible = false;
            }
            if (chkTitulo.Checked == false)
            {
                this.dgvReportes.Columns["Tipo1"].Visible = false;
            }
            if (chkVendido.Checked == false)
            {
                this.dgvReportes.Columns["vendido"].Visible = false;
            }
            if (chkUsrventa.Checked == false)
            {
                this.dgvReportes.Columns["usuario_venta"].Visible = false;
            }
            if (chkUsrreg.Checked == false)
            {
                this.dgvReportes.Columns["usuario_registro"].Visible = false;
            }
            if (chkNotas.Checked == false)
            {
                this.dgvReportes.Columns["notas"].Visible = false;
            }

            this.dgvReportes.Columns["des_tipov"].Visible = false;
            this.dgvReportes.Columns["des_titulo"].Visible = false;
            this.dgvReportes.Columns["des_vendido"].Visible = false;
            this.dgvReportes.Columns["idTip"].Visible = false;
            this.dgvReportes.Columns["idtipovehiculo"].Visible = false;
            this.dgvReportes.Columns["idvendido"].Visible = false;
            //this.dgvDatos.Columns["idtemporal"].Visible = false;
            //this.dgvDatos.Columns["usuario_venta"].Visible = false;
            this.dgvReportes.Columns["id"].Visible = false;

          

            ajustar();
            stylo();

            grbCampos.Enabled = false;
            btnActivar.Enabled = true;
            btnPreferencias.Enabled = false;

        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            dgvReportes.DataSource = null;
            grbCampos.Enabled = true;
            chkMarca.Checked = false;
            chkModelo.Checked = false;
            chkYear.Checked = false;
            chkNumeroS.Checked = false;
            chkColor.Checked = false;
            chkPlacas.Checked = false;
            chkCosto.Checked = false;
            chkPVenta.Checked = false;
            chkInversion.Checked = false;
            chkGanancia.Checked = false;
            chkFReg.Checked = false;
            chkTVehiculo.Checked = false;
            chkTitulo.Checked = false;
            chkVendido.Checked = false;
            chkUsrreg.Checked = false;
            chkUsrventa.Checked = false;
            chkNotas.Checked = false;


           
            btnPreferencias.Enabled = true;
            btnActivar.Enabled = false;

            
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            CargaDatos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string query = "select * from datos where registro BETWEEN @desde AND @hasta";
            Conexion.conectarme();
            MySqlCommand cmd = new MySqlCommand(query, Conexion.conectarme());
             
            cmd.Parameters.AddWithValue("@desde", dtpInicio.Value);
            cmd.Parameters.AddWithValue("@hasta", dtpFinal.Value);
           

         DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();
           

           //connection.Open();
             da.SelectCommand = cmd;
              da.Fill(ds, "datos");
          dgvReportes.DataSource = ds.Tables[0];
        }
// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       
      
        






    }
}
