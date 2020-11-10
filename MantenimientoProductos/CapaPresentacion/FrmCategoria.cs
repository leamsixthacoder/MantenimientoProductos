using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmCategoria : Form
    {
        private string idcategoria;
        public FrmCategoria()
        {
            InitializeComponent();
        }


        public void actionsTable()
        {
            tablaCategoria.Columns[0].Visible = false;
            tablaCategoria.Columns[1].Width = 80;
            tablaCategoria.Columns[2].Width = 180;

        }
        public void mostrarBuscarTabla(string buscar)
        {
            N_Categoria objNegocio = new N_Categoria();
            tablaCategoria.DataSource = objNegocio.ListandoCategoria(buscar);
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }
        public void clearBoxes()
        {
            txtID.Text = "";
            txtnombre.Text = "";
            txtDescripcion.Text = "";
            txtnombre.Focus();
        }

        private void FrmCategoria_Load_1(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            actionsTable();
        }

        private void cerrarForm_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            clearBoxes();
        }

        private void topFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
