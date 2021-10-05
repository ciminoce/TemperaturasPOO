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
                if (!repositorio.Existe(temperatura))
                {
                    repositorio.Agregar(temperatura);
                    DataGridViewRow r = ConstruirFila();//creo una fila en blanco
                    r.CreateCells(DatosDataGridView);//le creo las celdas 
                    SetearFila(r, temperatura);
                    AgregarFila(r);
                    ActualizarContadorRegistros();
                    MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Temperatura está repetida... Alta denegada!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
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
            r.Cells[colFahrenheit.Index].Value = temperatura.GetFahrenheit();
            r.Cells[colReaumur.Index].Value = temperatura.GetReaumur();

            r.Tag = temperatura;
        }

        private DataGridViewRow ConstruirFila()
        {
            return new DataGridViewRow();
        }

        private List<Temperatura> listaTemperaturas;
        private void FrmTemperaturas_Load(object sender, EventArgs e)
        {
            repositorio = new TemperaturasRepositorio();//Instancio el repositorio
            if (repositorio.GetCantidad()>0)
            {
                //Si tengo datos entonces los muestro
                CargarTodosLosRegistros();
                ActualizarContadorRegistros();
            }
        }

        private void CargarTodosLosRegistros()
        {
            listaTemperaturas = repositorio.GetLista();
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var temperatura in listaTemperaturas)
            {
                DataGridViewRow r = ConstruirFila();
                r.CreateCells(DatosDataGridView);
                SetearFila(r,temperatura);
                AgregarFila(r);
            }
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
            Temperatura temperaturaCopia = (Temperatura) temperatura.Clone();
            FrmTemperaturasEdit frm = new FrmTemperaturasEdit() {Text = "Modificar una Temperatura"};
            frm.SetTemperatura(temperaturaCopia);//La paso para modificar
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                temperaturaCopia = frm.GetTemperatura();//La obtengo modificada
                if (!repositorio.Existe(temperaturaCopia))
                {
                    repositorio.Editar(temperatura, temperaturaCopia);
                    SetearFila(r,temperaturaCopia);
                    MessageBox.Show("Registro Modificado!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    SetearFila(r, temperatura);
                    MessageBox.Show("Temperatura repetida... Alta denegada!!!!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            }

        }

        private void FiltrarToolStripButton_Click(object sender, EventArgs e)
        {
            double temperaturaAFiltrar = 17;
            listaTemperaturas=repositorio.Filtrar(temperaturaAFiltrar);
            MostrarDatosEnGrilla();
        }

        private void ActualizarToolStripButton_Click(object sender, EventArgs e)
        {
            CargarTodosLosRegistros();
        }
    }
}
