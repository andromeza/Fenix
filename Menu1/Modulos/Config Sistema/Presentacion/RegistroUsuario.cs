using DevExpress.XtraEditors;
using Menu1.Modulos.Config_Sistema.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu1.Modulos.Config_Sistema.Presentacion
{
    public partial class RegistroUsuario : DevExpress.XtraEditors.XtraForm
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private void nuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modulos.Config_Sistema.Presentacion.FrmUsuarios frmUser = new Modulos.Config_Sistema.Presentacion.FrmUsuarios();

            frmUser.ShowDialog();
            ActualizarListado();
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            using (fenixlabsEntities1 db = new fenixlabsEntities1())
            {

                var lst = from d in db.Usuarios
                          select d;

                dgvData.DataSource = lst.ToList();


            }
        }

        private int? CapturarID()
        {

            try
            {
                return int.Parse(dgvData.Rows[dgvData.CurrentRow.Index].Cells[0].Value.ToString());

            }
            catch
            {
                return null;
            }

        }

        private void editarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? id = CapturarID();

            if (id != null)
            {
                Modulos.Config_Sistema.Presentacion.FrmUsuarios VUsuario = new Modulos.Config_Sistema.Presentacion.FrmUsuarios(id);

                VUsuario.ShowDialog();
                ActualizarListado();
            }
        }
    }
}