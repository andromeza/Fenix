using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Menu1
{
    public partial class Form1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            test.Visible = false;
        }

        private void accordionControlElement15_Click(object sender, EventArgs e)
        {
            Modulos.Config_Sistema.Presentacion.RegistroUsuario  frmRegistro  = new Modulos.Config_Sistema.Presentacion.RegistroUsuario ();

            frmRegistro.Show();

        }
    }
}
