using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemperaturasPOO.Entidades;

namespace TemperaaturasPOO.Windows
{
    public partial class FrmTemperaturasEdit : Form
    {
        public FrmTemperaturasEdit()
        {
            InitializeComponent();
        }

        private Temperatura temperatura;
        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (temperatura==null)
                {
                    temperatura = new Temperatura();
                }
                //temperatura = new Temperatura(double.Parse(TemperaturaTextBox.Text));
                temperatura.SetGrados(double.Parse(TemperaturaTextBox.Text));
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool esValido = true;
            errorProvider1.Clear();
            if (!double.TryParse(TemperaturaTextBox.Text, out double grados))
            {
                errorProvider1.SetError(TemperaturaTextBox,"Temperatura mal ingresada");
                esValido = false;
            }else if (grados<-10 || grados>27)
            {
                errorProvider1.SetError(TemperaturaTextBox,"Temperatura fuera del rango permitido [-10,27]");
                esValido = false;
            }

            return esValido;
        }

        public Temperatura GetTemperatura()
        {
            return temperatura;
        }

        public void SetTemperatura(Temperatura temperatura)
        {
            this.temperatura = temperatura;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Veo si me pasan una temperatura
            if (temperatura!=null)
            {
                TemperaturaTextBox.Text = temperatura.GetGrados().ToString();
            }
        }
    }
}
