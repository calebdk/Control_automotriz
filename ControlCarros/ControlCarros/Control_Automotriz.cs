using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlCarros
{
    public partial class Control_Automotriz : Form
    {

        //static string logeado;
        public Control_Automotriz()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Usuarios usr = new Usuarios();
            usr.WindowState = FormWindowState.Maximized;
            usr.MdiParent = this;
            usr.Show();
           // usr.Show();
            //usuariosToolStripMenuItem.Enabled = false;
           //this.Hide();
        }

        //public string Usuario;
        private void Control_Automotriz_Load(object sender, EventArgs e)
        {

            
            toolStripStatusLabel1.Text = DateTime.Now.ToString("F");
          
            //toolStripStatusLabel2.Text = logeado;

            
            //toolStripStatusLabel2.Text = 
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carros cars = new carros(toolStripStatusLabel2.Text);
            cars.WindowState = FormWindowState.Maximized;
            cars.MdiParent = this;
            cars.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportes rep = new reportes();
            rep.WindowState = FormWindowState.Maximized;
            rep.MdiParent = this;
            rep.Show();
        }

       

        private void caracteristicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caracteristicas car = new caracteristicas();
            car.WindowState = FormWindowState.Maximized;
            car.MdiParent = this;
            car.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login forma = new Login();
            forma.Show();
            this.Close();
        }

        private void acecaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About info = new About();
            info.WindowState = FormWindowState.Maximized;
            info.MdiParent = this;
            info.Show();

        }


       
    }
}
