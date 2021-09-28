using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemperaturasPOO.Datos;
using TemperaturasPOO.Entidades;

namespace TemperaaturasPOO.Windows
{
    public partial class FrmTemperaturas : Form
    {
        public FrmTemperaturas()
        {
            InitializeComponent();
        }

        private void SalirToolStripButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private TemperaturasRepositorio repositorio;
        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmTemperaturasEdit frm = new FrmTemperaturasEdit() {Text = "Agregar Temperatura"};
            DialogResult dr=frm.ShowDialog(this);
            if (dr==DialogResult.Cancel)
            {
                //El usuario presionó el botón cancelar del frmEdit
                return;
            }

            try
            {
                Temperatura temperatura = frm.GetTemperatura();
                repositorio.Agregar(temperatura);
                DataGridViewRow r = ConstruirFila();//creo una fila en blanco
                r.CreateCells(DatosDataGridView);//le creo las celdas 
                SetearFila(r, temperatura);
                AgregarFila(r);
                ActualizarContadorRegistros();
                MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void ActualizarContadorRegistros()
        {
            CantidadRegistrosLabel.Text = repositorio.GetCantidad().ToString();
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Temperatura temperatura)
        {
            r.Cells[colTemperatura.Index].Value = temperatura.GetGrados();

            r.Tag = temperatura;
        }

        private DataGridViewRow ConstruirFila()
        {
            return new DataGridViewRow();
        }

        private void FrmTemperaturas_Load(object sender, EventArgs e)
        {
            repositorio = new TemperaturasRepositorio();//Instancio el repositorio
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count==0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];//obtengo la fila seleccionada de la grilla
            Temperatura temperatura =(Temperatura) r.Tag;

            DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?", "Confirmar Baja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dr==DialogResult.Yes)
            {

                bool borrado = repositorio.Borrar(temperatura);
                if (borrado)
                {
                    DatosDataGridView.Rows.Remove(r);//quito la fila de la grilla
                    ActualizarContadorRegistros();
                    MessageBox.Show("Registro Borrado!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo dar de baja el registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count==0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Temperatura temperatura = (Temperatura) r.Tag;
            FrmTemperaturasEdit frm = new FrmTemperaturasEdit() {Text = "Modificar una Temperatura"};
            frm.SetTemperatura(temperatura);//La paso para modificar
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                temperatura = frm.GetTemperatura();//La obtengo modificada
                SetearFila(r,temperatura);
                MessageBox.Show("Registro Modificado!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
    }
}
