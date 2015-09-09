namespace ControlCarros
{
    partial class reportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reportes));
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            this.btnExcell = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Mydocumento = new System.Drawing.Printing.PrintDocument();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.grbCampos = new System.Windows.Forms.GroupBox();
            this.chkNotas = new System.Windows.Forms.CheckBox();
            this.chkUsrventa = new System.Windows.Forms.CheckBox();
            this.chkUsrreg = new System.Windows.Forms.CheckBox();
            this.chkVendido = new System.Windows.Forms.CheckBox();
            this.chkTitulo = new System.Windows.Forms.CheckBox();
            this.chkTVehiculo = new System.Windows.Forms.CheckBox();
            this.chkFReg = new System.Windows.Forms.CheckBox();
            this.chkGanancia = new System.Windows.Forms.CheckBox();
            this.chkInversion = new System.Windows.Forms.CheckBox();
            this.chkPVenta = new System.Windows.Forms.CheckBox();
            this.chkCosto = new System.Windows.Forms.CheckBox();
            this.chkPlacas = new System.Windows.Forms.CheckBox();
            this.chkColor = new System.Windows.Forms.CheckBox();
            this.chkNumeroS = new System.Windows.Forms.CheckBox();
            this.chkYear = new System.Windows.Forms.CheckBox();
            this.chkModelo = new System.Windows.Forms.CheckBox();
            this.chkMarca = new System.Windows.Forms.CheckBox();
            this.btnPreferencias = new System.Windows.Forms.Button();
            this.btnTodo = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.grbCampos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReportes
            // 
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Location = new System.Drawing.Point(12, 124);
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.ReadOnly = true;
            this.dgvReportes.Size = new System.Drawing.Size(829, 228);
            this.dgvReportes.TabIndex = 0;
            // 
            // btnExcell
            // 
            this.btnExcell.Image = ((System.Drawing.Image)(resources.GetObject("btnExcell.Image")));
            this.btnExcell.Location = new System.Drawing.Point(589, 3);
            this.btnExcell.Name = "btnExcell";
            this.btnExcell.Size = new System.Drawing.Size(53, 42);
            this.btnExcell.TabIndex = 1;
            this.btnExcell.UseVisualStyleBackColor = true;
            this.btnExcell.Click += new System.EventHandler(this.btnExcell_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(54, 11);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(158, 20);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buscar";
            // 
            // Mydocumento
            // 
            this.Mydocumento.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.Mydocumento_PrintPage);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(657, 6);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(57, 39);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnPre
            // 
            this.btnPre.Image = ((System.Drawing.Image)(resources.GetObject("btnPre.Image")));
            this.btnPre.Location = new System.Drawing.Point(729, 6);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(60, 39);
            this.btnPre.TabIndex = 6;
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(12, 82);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(48, 38);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // grbCampos
            // 
            this.grbCampos.Controls.Add(this.chkNotas);
            this.grbCampos.Controls.Add(this.chkUsrventa);
            this.grbCampos.Controls.Add(this.chkUsrreg);
            this.grbCampos.Controls.Add(this.chkVendido);
            this.grbCampos.Controls.Add(this.chkTitulo);
            this.grbCampos.Controls.Add(this.chkTVehiculo);
            this.grbCampos.Controls.Add(this.chkFReg);
            this.grbCampos.Controls.Add(this.chkGanancia);
            this.grbCampos.Controls.Add(this.chkInversion);
            this.grbCampos.Controls.Add(this.chkPVenta);
            this.grbCampos.Controls.Add(this.chkCosto);
            this.grbCampos.Controls.Add(this.chkPlacas);
            this.grbCampos.Controls.Add(this.chkColor);
            this.grbCampos.Controls.Add(this.chkNumeroS);
            this.grbCampos.Controls.Add(this.chkYear);
            this.grbCampos.Controls.Add(this.chkModelo);
            this.grbCampos.Controls.Add(this.chkMarca);
            this.grbCampos.Location = new System.Drawing.Point(377, 46);
            this.grbCampos.Name = "grbCampos";
            this.grbCampos.Size = new System.Drawing.Size(465, 74);
            this.grbCampos.TabIndex = 8;
            this.grbCampos.TabStop = false;
            this.grbCampos.Text = "Elegir Campos a Visualizar";
            // 
            // chkNotas
            // 
            this.chkNotas.AutoSize = true;
            this.chkNotas.Location = new System.Drawing.Point(391, 38);
            this.chkNotas.Name = "chkNotas";
            this.chkNotas.Size = new System.Drawing.Size(54, 17);
            this.chkNotas.TabIndex = 16;
            this.chkNotas.Text = "Notas";
            this.chkNotas.UseVisualStyleBackColor = true;
            // 
            // chkUsrventa
            // 
            this.chkUsrventa.AutoSize = true;
            this.chkUsrventa.Location = new System.Drawing.Point(391, 20);
            this.chkUsrventa.Name = "chkUsrventa";
            this.chkUsrventa.Size = new System.Drawing.Size(73, 17);
            this.chkUsrventa.TabIndex = 15;
            this.chkUsrventa.Text = "Usr Venta";
            this.chkUsrventa.UseVisualStyleBackColor = true;
            // 
            // chkUsrreg
            // 
            this.chkUsrreg.AutoSize = true;
            this.chkUsrreg.Location = new System.Drawing.Point(320, 55);
            this.chkUsrreg.Name = "chkUsrreg";
            this.chkUsrreg.Size = new System.Drawing.Size(84, 17);
            this.chkUsrreg.TabIndex = 14;
            this.chkUsrreg.Text = "Usr Registro";
            this.chkUsrreg.UseVisualStyleBackColor = true;
            // 
            // chkVendido
            // 
            this.chkVendido.AutoSize = true;
            this.chkVendido.Location = new System.Drawing.Point(320, 38);
            this.chkVendido.Name = "chkVendido";
            this.chkVendido.Size = new System.Drawing.Size(65, 17);
            this.chkVendido.TabIndex = 13;
            this.chkVendido.Text = "Vendido";
            this.chkVendido.UseVisualStyleBackColor = true;
            // 
            // chkTitulo
            // 
            this.chkTitulo.AutoSize = true;
            this.chkTitulo.Location = new System.Drawing.Point(322, 20);
            this.chkTitulo.Name = "chkTitulo";
            this.chkTitulo.Size = new System.Drawing.Size(52, 17);
            this.chkTitulo.TabIndex = 12;
            this.chkTitulo.Text = "Titulo";
            this.chkTitulo.UseVisualStyleBackColor = true;
            // 
            // chkTVehiculo
            // 
            this.chkTVehiculo.AutoSize = true;
            this.chkTVehiculo.Location = new System.Drawing.Point(223, 55);
            this.chkTVehiculo.Name = "chkTVehiculo";
            this.chkTVehiculo.Size = new System.Drawing.Size(91, 17);
            this.chkTVehiculo.TabIndex = 11;
            this.chkTVehiculo.Text = "Tipo Vehiculo";
            this.chkTVehiculo.UseVisualStyleBackColor = true;
            // 
            // chkFReg
            // 
            this.chkFReg.AutoSize = true;
            this.chkFReg.Location = new System.Drawing.Point(223, 38);
            this.chkFReg.Name = "chkFReg";
            this.chkFReg.Size = new System.Drawing.Size(98, 17);
            this.chkFReg.TabIndex = 10;
            this.chkFReg.Text = "Fecha Registro";
            this.chkFReg.UseVisualStyleBackColor = true;
            // 
            // chkGanancia
            // 
            this.chkGanancia.AutoSize = true;
            this.chkGanancia.Location = new System.Drawing.Point(224, 20);
            this.chkGanancia.Name = "chkGanancia";
            this.chkGanancia.Size = new System.Drawing.Size(72, 17);
            this.chkGanancia.TabIndex = 9;
            this.chkGanancia.Text = "Ganancia";
            this.chkGanancia.UseVisualStyleBackColor = true;
            // 
            // chkInversion
            // 
            this.chkInversion.AutoSize = true;
            this.chkInversion.Location = new System.Drawing.Point(137, 55);
            this.chkInversion.Name = "chkInversion";
            this.chkInversion.Size = new System.Drawing.Size(69, 17);
            this.chkInversion.TabIndex = 8;
            this.chkInversion.Text = "Inversion";
            this.chkInversion.UseVisualStyleBackColor = true;
            // 
            // chkPVenta
            // 
            this.chkPVenta.AutoSize = true;
            this.chkPVenta.Location = new System.Drawing.Point(137, 38);
            this.chkPVenta.Name = "chkPVenta";
            this.chkPVenta.Size = new System.Drawing.Size(87, 17);
            this.chkPVenta.TabIndex = 7;
            this.chkPVenta.Text = "Precio Venta";
            this.chkPVenta.UseVisualStyleBackColor = true;
            // 
            // chkCosto
            // 
            this.chkCosto.AutoSize = true;
            this.chkCosto.Location = new System.Drawing.Point(137, 20);
            this.chkCosto.Name = "chkCosto";
            this.chkCosto.Size = new System.Drawing.Size(53, 17);
            this.chkCosto.TabIndex = 6;
            this.chkCosto.Text = "Costo";
            this.chkCosto.UseVisualStyleBackColor = true;
            // 
            // chkPlacas
            // 
            this.chkPlacas.AutoSize = true;
            this.chkPlacas.Location = new System.Drawing.Point(67, 55);
            this.chkPlacas.Name = "chkPlacas";
            this.chkPlacas.Size = new System.Drawing.Size(58, 17);
            this.chkPlacas.TabIndex = 5;
            this.chkPlacas.Text = "Placas";
            this.chkPlacas.UseVisualStyleBackColor = true;
            // 
            // chkColor
            // 
            this.chkColor.AutoSize = true;
            this.chkColor.Location = new System.Drawing.Point(67, 38);
            this.chkColor.Name = "chkColor";
            this.chkColor.Size = new System.Drawing.Size(50, 17);
            this.chkColor.TabIndex = 4;
            this.chkColor.Text = "Color";
            this.chkColor.UseVisualStyleBackColor = true;
            // 
            // chkNumeroS
            // 
            this.chkNumeroS.AutoSize = true;
            this.chkNumeroS.Location = new System.Drawing.Point(67, 20);
            this.chkNumeroS.Name = "chkNumeroS";
            this.chkNumeroS.Size = new System.Drawing.Size(64, 17);
            this.chkNumeroS.TabIndex = 3;
            this.chkNumeroS.Text = "NoSerie";
            this.chkNumeroS.UseVisualStyleBackColor = true;
            // 
            // chkYear
            // 
            this.chkYear.AutoSize = true;
            this.chkYear.Location = new System.Drawing.Point(7, 55);
            this.chkYear.Name = "chkYear";
            this.chkYear.Size = new System.Drawing.Size(47, 17);
            this.chkYear.TabIndex = 2;
            this.chkYear.Text = "Anio";
            this.chkYear.UseVisualStyleBackColor = true;
            // 
            // chkModelo
            // 
            this.chkModelo.AutoSize = true;
            this.chkModelo.Location = new System.Drawing.Point(7, 38);
            this.chkModelo.Name = "chkModelo";
            this.chkModelo.Size = new System.Drawing.Size(61, 17);
            this.chkModelo.TabIndex = 1;
            this.chkModelo.Text = "Modelo";
            this.chkModelo.UseVisualStyleBackColor = true;
            // 
            // chkMarca
            // 
            this.chkMarca.AutoSize = true;
            this.chkMarca.Location = new System.Drawing.Point(7, 20);
            this.chkMarca.Name = "chkMarca";
            this.chkMarca.Size = new System.Drawing.Size(56, 17);
            this.chkMarca.TabIndex = 0;
            this.chkMarca.Text = "Marca";
            this.chkMarca.UseVisualStyleBackColor = true;
            // 
            // btnPreferencias
            // 
            this.btnPreferencias.Image = ((System.Drawing.Image)(resources.GetObject("btnPreferencias.Image")));
            this.btnPreferencias.Location = new System.Drawing.Point(290, 84);
            this.btnPreferencias.Name = "btnPreferencias";
            this.btnPreferencias.Size = new System.Drawing.Size(62, 34);
            this.btnPreferencias.TabIndex = 9;
            this.btnPreferencias.UseVisualStyleBackColor = true;
            this.btnPreferencias.Click += new System.EventHandler(this.btnPreferencias_Click);
            // 
            // btnTodo
            // 
            this.btnTodo.Image = ((System.Drawing.Image)(resources.GetObject("btnTodo.Image")));
            this.btnTodo.Location = new System.Drawing.Point(66, 82);
            this.btnTodo.Name = "btnTodo";
            this.btnTodo.Size = new System.Drawing.Size(50, 38);
            this.btnTodo.TabIndex = 10;
            this.btnTodo.UseVisualStyleBackColor = true;
            this.btnTodo.Click += new System.EventHandler(this.btnTodo_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.Enabled = false;
            this.btnActivar.Image = ((System.Drawing.Image)(resources.GetObject("btnActivar.Image")));
            this.btnActivar.Location = new System.Drawing.Point(290, 46);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(62, 32);
            this.btnActivar.TabIndex = 11;
            this.btnActivar.UseVisualStyleBackColor = true;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(230, 11);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(87, 20);
            this.dtpInicio.TabIndex = 12;
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(328, 11);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(89, 20);
            this.dtpFinal.TabIndex = 13;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(423, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(48, 34);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(156, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Cargar Preferencias";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(173, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Activar";
            // 
            // reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(840, 353);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtpFinal);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.btnTodo);
            this.Controls.Add(this.btnPreferencias);
            this.Controls.Add(this.grbCampos);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnExcell);
            this.Controls.Add(this.dgvReportes);
            this.Name = "reportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.reportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.grbCampos.ResumeLayout(false);
            this.grbCampos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReportes;
        private System.Windows.Forms.Button btnExcell;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Drawing.Printing.PrintDocument Mydocumento;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox grbCampos;
        private System.Windows.Forms.CheckBox chkModelo;
        private System.Windows.Forms.CheckBox chkMarca;
        private System.Windows.Forms.Button btnPreferencias;
        private System.Windows.Forms.Button btnTodo;
        private System.Windows.Forms.CheckBox chkCosto;
        private System.Windows.Forms.CheckBox chkPlacas;
        private System.Windows.Forms.CheckBox chkColor;
        private System.Windows.Forms.CheckBox chkNumeroS;
        private System.Windows.Forms.CheckBox chkYear;
        private System.Windows.Forms.CheckBox chkNotas;
        private System.Windows.Forms.CheckBox chkUsrventa;
        private System.Windows.Forms.CheckBox chkUsrreg;
        private System.Windows.Forms.CheckBox chkVendido;
        private System.Windows.Forms.CheckBox chkTitulo;
        private System.Windows.Forms.CheckBox chkTVehiculo;
        private System.Windows.Forms.CheckBox chkFReg;
        private System.Windows.Forms.CheckBox chkGanancia;
        private System.Windows.Forms.CheckBox chkInversion;
        private System.Windows.Forms.CheckBox chkPVenta;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}