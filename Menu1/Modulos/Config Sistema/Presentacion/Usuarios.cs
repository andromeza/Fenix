using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu1.Modulos.Config_Sistema.Entity;

namespace Menu1.Modulos.Config_Sistema.Presentacion
{
    public partial class FrmUsuarios : DevExpress.XtraEditors.XtraForm
    {
        public int? id;
        Usuarios mRegistros = null;
        public FrmUsuarios(int? id = null)
        {
            InitializeComponent();
            this.id = id;

            if (id != null)
            {
                CargarDatos();
            }
        }


        //FUNCION PARA CARGAR DATOS DE TABALA
        private void CargarDatos()
        {
            using (fenixlabsEntities1 db = new fenixlabsEntities1())
            {

                mRegistros = db.Usuarios.Find(id);

                txtUsuario.Text = mRegistros.nombre;
                txtPassword.Text = mRegistros.pass;
                cbxPermisos.Text = mRegistros.permisos;
                    

                //SI ES FECHA
                //dtpFecha.Value = (DateTime)mRegistros.fechanacimiento;


            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (fenixlabsEntities1 db = new fenixlabsEntities1())
            {
                if (id == null)
                    //instancia de la tabla de la bd
                    mRegistros = new Usuarios();

                //atributos de la tabla
                mRegistros.nombre = txtUsuario.Text;
                mRegistros.pass = txtPassword.Text ;
                mRegistros.permisos = cbxPermisos.Text ;

                //registrar en la base de datos

                //if de validacion guardar o modificar
                if (id == null)
                    db.Usuarios.Add(mRegistros);
                else
                {
                    db.Entry(mRegistros).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();

                this.Close();
                
            }
        }
    }
}