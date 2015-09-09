namespace ControlCarros
{
    partial class caracteristicas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(caracteristicas));
            this.gbTitulo = new System.Windows.Forms.GroupBox();
            this.txtidTitulo = new System.Windows.Forms.TextBox();
            this.btnDeleteT = new System.Windows.Forms.Button();
            this.btnReadT = new System.Windows.Forms.Button();
            this.btnUpdateT = new System.Windows.Forms.Button();
            this.dgvTitulo = new System.Windows.Forms.DataGridView();
            this.btnTitulo = new System.Windows.Forms.Button();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnable1 = new System.Windows.Forms.Button();
            this.btnEnable2 = new System.Windows.Forms.Button();
            this.gbtAutos = new System.Windows.Forms.GroupBox();
            this.txtidAutos = new System.Windows.Forms.TextBox();
            this.btnSeeA = new System.Windows.Forms.Button();
            this.dgvAutos = new System.Windows.Forms.DataGridView();
            this.btnUpdateA = new System.Windows.Forms.Button();
            this.btnDeleteA = new System.Windows.Forms.Button();
            this.btnSaveA = new System.Windows.Forms.Button();
            this.txtAutos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gbtVentas = new System.Windows.Forms.GroupBox();
            this.txtidVenta = new System.Windows.Forms.TextBox();
            this.txtverVentas = new System.Windows.Forms.Button();
            this.dgvSale = new System.Windows.Forms.DataGridView();
            this.btnUpdateSale = new System.Windows.Forms.Button();
            this.btnDelVentas = new System.Windows.Forms.Button();
            this.btnSaveVentas = new System.Windows.Forms.Button();
            this.txtventas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.gbTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitulo)).BeginInit();
            this.gbtAutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutos)).BeginInit();
            this.gbtVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSale)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTitulo
            // 
            this.gbTitulo.BackColor = System.Drawing.Color.LightGray;
            this.gbTitulo.Controls.Add(this.txtidTitulo);
            this.gbTitulo.Controls.Add(this.btnDeleteT);
            this.gbTitulo.Controls.Add(this.btnReadT);
            this.gbTitulo.Controls.Add(this.btnUpdateT);
            this.gbTitulo.Controls.Add(this.dgvTitulo);
            this.gbTitulo.Controls.Add(this.btnTitulo);
            this.gbTitulo.Controls.Add(this.txtTitulo);
            this.gbTitulo.Controls.Add(this.label3);
            this.gbTitulo.Controls.Add(this.label2);
            this.gbTitulo.Enabled = false;
            this.gbTitulo.Location = new System.Drawing.Point(12, 48);
            this.gbTitulo.Name = "gbTitulo";
            this.gbTitulo.Size = new System.Drawing.Size(187, 314);
            this.gbTitulo.TabIndex = 0;
            this.gbTitulo.TabStop = false;
            this.gbTitulo.Text = "Agregar Tipos de Titulo";
            // 
            // txtidTitulo
            // 
            this.txtidTitulo.Location = new System.Drawing.Point(48, 19);
            this.txtidTitulo.Name = "txtidTitulo";
            this.txtidTitulo.Size = new System.Drawing.Size(28, 20);
            this.txtidTitulo.TabIndex = 11;
            // 
            // btnDeleteT
            // 
            this.btnDeleteT.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteT.Image")));
            this.btnDeleteT.Location = new System.Drawing.Point(69, 68);
            this.btnDeleteT.Name = "btnDeleteT";
            this.btnDeleteT.Size = new System.Drawing.Size(48, 37);
            this.btnDeleteT.TabIndex = 10;
            this.btnDeleteT.UseVisualStyleBackColor = true;
            this.btnDeleteT.Click += new System.EventHandler(this.btnDeleteT_Click);
            // 
            // btnReadT
            // 
            this.btnReadT.Location = new System.Drawing.Point(6, 280);
            this.btnReadT.Name = "btnReadT";
            this.btnReadT.Size = new System.Drawing.Size(75, 23);
            this.btnReadT.TabIndex = 9;
            this.btnReadT.Text = "Ver todos";
            this.btnReadT.UseVisualStyleBackColor = true;
            this.btnReadT.Click += new System.EventHandler(this.btnReadT_Click);
            // 
            // btnUpdateT
            // 
            this.btnUpdateT.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateT.Image")));
            this.btnUpdateT.Location = new System.Drawing.Point(135, 68);
            this.btnUpdateT.Name = "btnUpdateT";
            this.btnUpdateT.Size = new System.Drawing.Size(47, 37);
            this.btnUpdateT.TabIndex = 8;
            this.btnUpdateT.UseVisualStyleBackColor = true;
            this.btnUpdateT.Click += new System.EventHandler(this.btnUpdateT_Click);
            // 
            // dgvTitulo
            // 
            this.dgvTitulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTitulo.Location = new System.Drawing.Point(0, 120);
            this.dgvTitulo.Name = "dgvTitulo";
            this.dgvTitulo.Size = new System.Drawing.Size(182, 150);
            this.dgvTitulo.TabIndex = 5;
            this.dgvTitulo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTitulo_CellContentClick);
            // 
            // btnTitulo
            // 
            this.btnTitulo.Image = ((System.Drawing.Image)(resources.GetObject("btnTitulo.Image")));
            this.btnTitulo.Location = new System.Drawing.Point(0, 68);
            this.btnTitulo.Name = "btnTitulo";
            this.btnTitulo.Size = new System.Drawing.Size(52, 37);
            this.btnTitulo.TabIndex = 4;
            this.btnTitulo.UseVisualStyleBackColor = true;
            this.btnTitulo.Click += new System.EventHandler(this.btnTitulo_Click);
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(48, 42);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(100, 20);
            this.txtTitulo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(3, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Titulo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID";
            // 
            // btnEnable1
            // 
            this.btnEnable1.Location = new System.Drawing.Point(42, 12);
            this.btnEnable1.Name = "btnEnable1";
            this.btnEnable1.Size = new System.Drawing.Size(75, 23);
            this.btnEnable1.TabIndex = 2;
            this.btnEnable1.Text = "Opcion #1";
            this.btnEnable1.UseVisualStyleBackColor = true;
            this.btnEnable1.Click += new System.EventHandler(this.btnEnable1_Click);
            // 
            // btnEnable2
            // 
            this.btnEnable2.Location = new System.Drawing.Point(308, 12);
            this.btnEnable2.Name = "btnEnable2";
            this.btnEnable2.Size = new System.Drawing.Size(75, 23);
            this.btnEnable2.TabIndex = 3;
            this.btnEnable2.Text = "Opcion #2";
            this.btnEnable2.UseVisualStyleBackColor = true;
            this.btnEnable2.Click += new System.EventHandler(this.btnEnable2_Click);
            // 
            // gbtAutos
            // 
            this.gbtAutos.BackColor = System.Drawing.Color.LightGray;
            this.gbtAutos.Controls.Add(this.txtidAutos);
            this.gbtAutos.Controls.Add(this.btnSeeA);
            this.gbtAutos.Controls.Add(this.dgvAutos);
            this.gbtAutos.Controls.Add(this.btnUpdateA);
            this.gbtAutos.Controls.Add(this.btnDeleteA);
            this.gbtAutos.Controls.Add(this.btnSaveA);
            this.gbtAutos.Controls.Add(this.txtAutos);
            this.gbtAutos.Controls.Add(this.label6);
            this.gbtAutos.Controls.Add(this.label5);
            this.gbtAutos.Enabled = false;
            this.gbtAutos.Location = new System.Drawing.Point(308, 48);
            this.gbtAutos.Name = "gbtAutos";
            this.gbtAutos.Size = new System.Drawing.Size(229, 314);
            this.gbtAutos.TabIndex = 4;
            this.gbtAutos.TabStop = false;
            this.gbtAutos.Text = "Agregar Tipos de Autos";
            // 
            // txtidAutos
            // 
            this.txtidAutos.Location = new System.Drawing.Point(34, 22);
            this.txtidAutos.Name = "txtidAutos";
            this.txtidAutos.Size = new System.Drawing.Size(36, 20);
            this.txtidAutos.TabIndex = 11;
            // 
            // btnSeeA
            // 
            this.btnSeeA.Location = new System.Drawing.Point(10, 280);
            this.btnSeeA.Name = "btnSeeA";
            this.btnSeeA.Size = new System.Drawing.Size(75, 23);
            this.btnSeeA.TabIndex = 8;
            this.btnSeeA.Text = "Ver todos";
            this.btnSeeA.UseVisualStyleBackColor = true;
            this.btnSeeA.Click += new System.EventHandler(this.btnSeeA_Click);
            // 
            // dgvAutos
            // 
            this.dgvAutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutos.Location = new System.Drawing.Point(7, 120);
            this.dgvAutos.Name = "dgvAutos";
            this.dgvAutos.Size = new System.Drawing.Size(217, 154);
            this.dgvAutos.TabIndex = 7;
            this.dgvAutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAutos_CellContentClick);
            // 
            // btnUpdateA
            // 
            this.btnUpdateA.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateA.Image")));
            this.btnUpdateA.Location = new System.Drawing.Point(175, 74);
            this.btnUpdateA.Name = "btnUpdateA";
            this.btnUpdateA.Size = new System.Drawing.Size(49, 36);
            this.btnUpdateA.TabIndex = 6;
            this.btnUpdateA.UseVisualStyleBackColor = true;
            this.btnUpdateA.Click += new System.EventHandler(this.btnUpdateA_Click);
            // 
            // btnDeleteA
            // 
            this.btnDeleteA.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteA.Image")));
            this.btnDeleteA.Location = new System.Drawing.Point(100, 74);
            this.btnDeleteA.Name = "btnDeleteA";
            this.btnDeleteA.Size = new System.Drawing.Size(49, 36);
            this.btnDeleteA.TabIndex = 5;
            this.btnDeleteA.UseVisualStyleBackColor = true;
            this.btnDeleteA.Click += new System.EventHandler(this.btnDeleteA_Click);
            // 
            // btnSaveA
            // 
            this.btnSaveA.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveA.Image")));
            this.btnSaveA.Location = new System.Drawing.Point(15, 74);
            this.btnSaveA.Name = "btnSaveA";
            this.btnSaveA.Size = new System.Drawing.Size(55, 36);
            this.btnSaveA.TabIndex = 4;
            this.btnSaveA.UseVisualStyleBackColor = true;
            this.btnSaveA.Click += new System.EventHandler(this.btnSaveA_Click);
            // 
            // txtAutos
            // 
            this.txtAutos.Location = new System.Drawing.Point(76, 48);
            this.txtAutos.Name = "txtAutos";
            this.txtAutos.Size = new System.Drawing.Size(91, 20);
            this.txtAutos.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(7, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tipo Autos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(7, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "ID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(610, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Opcion #3";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbtVentas
            // 
            this.gbtVentas.BackColor = System.Drawing.Color.LightGray;
            this.gbtVentas.Controls.Add(this.txtidVenta);
            this.gbtVentas.Controls.Add(this.txtverVentas);
            this.gbtVentas.Controls.Add(this.dgvSale);
            this.gbtVentas.Controls.Add(this.btnUpdateSale);
            this.gbtVentas.Controls.Add(this.btnDelVentas);
            this.gbtVentas.Controls.Add(this.btnSaveVentas);
            this.gbtVentas.Controls.Add(this.txtventas);
            this.gbtVentas.Controls.Add(this.label1);
            this.gbtVentas.Controls.Add(this.label8);
            this.gbtVentas.Enabled = false;
            this.gbtVentas.Location = new System.Drawing.Point(610, 55);
            this.gbtVentas.Name = "gbtVentas";
            this.gbtVentas.Size = new System.Drawing.Size(224, 303);
            this.gbtVentas.TabIndex = 6;
            this.gbtVentas.TabStop = false;
            this.gbtVentas.Text = "Vendido";
            // 
            // txtidVenta
            // 
            this.txtidVenta.Location = new System.Drawing.Point(33, 24);
            this.txtidVenta.Name = "txtidVenta";
            this.txtidVenta.Size = new System.Drawing.Size(38, 20);
            this.txtidVenta.TabIndex = 9;
            // 
            // txtverVentas
            // 
            this.txtverVentas.Location = new System.Drawing.Point(6, 273);
            this.txtverVentas.Name = "txtverVentas";
            this.txtverVentas.Size = new System.Drawing.Size(69, 23);
            this.txtverVentas.TabIndex = 8;
            this.txtverVentas.Text = "Ver todos";
            this.txtverVentas.UseVisualStyleBackColor = true;
            this.txtverVentas.Click += new System.EventHandler(this.txtverVentas_Click);
            // 
            // dgvSale
            // 
            this.dgvSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSale.Location = new System.Drawing.Point(7, 117);
            this.dgvSale.Name = "dgvSale";
            this.dgvSale.Size = new System.Drawing.Size(212, 150);
            this.dgvSale.TabIndex = 7;
            this.dgvSale.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSale_CellContentClick);
            // 
            // btnUpdateSale
            // 
            this.btnUpdateSale.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateSale.Image")));
            this.btnUpdateSale.Location = new System.Drawing.Point(168, 73);
            this.btnUpdateSale.Name = "btnUpdateSale";
            this.btnUpdateSale.Size = new System.Drawing.Size(50, 38);
            this.btnUpdateSale.TabIndex = 6;
            this.btnUpdateSale.UseVisualStyleBackColor = true;
            this.btnUpdateSale.Click += new System.EventHandler(this.btnUpdateSale_Click);
            // 
            // btnDelVentas
            // 
            this.btnDelVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnDelVentas.Image")));
            this.btnDelVentas.Location = new System.Drawing.Point(93, 73);
            this.btnDelVentas.Name = "btnDelVentas";
            this.btnDelVentas.Size = new System.Drawing.Size(48, 38);
            this.btnDelVentas.TabIndex = 5;
            this.btnDelVentas.UseVisualStyleBackColor = true;
            this.btnDelVentas.Click += new System.EventHandler(this.btnDelVentas_Click);
            // 
            // btnSaveVentas
            // 
            this.btnSaveVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveVentas.Image")));
            this.btnSaveVentas.Location = new System.Drawing.Point(6, 73);
            this.btnSaveVentas.Name = "btnSaveVentas";
            this.btnSaveVentas.Size = new System.Drawing.Size(46, 38);
            this.btnSaveVentas.TabIndex = 4;
            this.btnSaveVentas.UseVisualStyleBackColor = true;
            this.btnSaveVentas.Click += new System.EventHandler(this.btnSaveVentas_Click);
            // 
            // txtventas
            // 
            this.txtventas.Location = new System.Drawing.Point(78, 46);
            this.txtventas.Name = "txtventas";
            this.txtventas.Size = new System.Drawing.Size(77, 20);
            this.txtventas.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(7, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo Venta:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(6, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "ID";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(778, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(50, 37);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // caracteristicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(848, 363);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.gbtVentas);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbtAutos);
            this.Controls.Add(this.btnEnable2);
            this.Controls.Add(this.btnEnable1);
            this.Controls.Add(this.gbTitulo);
            this.Name = "caracteristicas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "caracteristicas Que Desea Hacer?";
            this.Load += new System.EventHandler(this.caracteristicas_Load);
            this.gbTitulo.ResumeLayout(false);
            this.gbTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitulo)).EndInit();
            this.gbtAutos.ResumeLayout(false);
            this.gbtAutos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutos)).EndInit();
            this.gbtVentas.ResumeLayout(false);
            this.gbtVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSale)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTitulo;
        private System.Windows.Forms.Button btnDeleteT;
        private System.Windows.Forms.Button btnReadT;
        private System.Windows.Forms.Button btnUpdateT;
        private System.Windows.Forms.DataGridView dgvTitulo;
        private System.Windows.Forms.Button btnTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnable1;
        private System.Windows.Forms.Button btnEnable2;
        private System.Windows.Forms.GroupBox gbtAutos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSeeA;
        private System.Windows.Forms.DataGridView dgvAutos;
        private System.Windows.Forms.Button btnUpdateA;
        private System.Windows.Forms.Button btnDeleteA;
        private System.Windows.Forms.Button btnSaveA;
        private System.Windows.Forms.TextBox txtAutos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbtVentas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button txtverVentas;
        private System.Windows.Forms.DataGridView dgvSale;
        private System.Windows.Forms.Button btnUpdateSale;
        private System.Windows.Forms.Button btnDelVentas;
        private System.Windows.Forms.Button btnSaveVentas;
        private System.Windows.Forms.TextBox txtventas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox txtidTitulo;
        private System.Windows.Forms.TextBox txtidAutos;
        private System.Windows.Forms.TextBox txtidVenta;
    }
}