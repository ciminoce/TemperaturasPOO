using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperaturasPOO.Entidades;

namespace TemperaturasPOO.Datos
{
    public class TemperaturasRepositorio
    {
        private List<Temperatura> temperaturas;

        public TemperaturasRepositorio()
        {
            temperaturas = new List<Temperatura>();
        }

        public void Agregar(Temperatura temperatura)
        {
            temperaturas.Add(temperatura);
        }

        public List<Temperatura> GetLista()
        {
            return temperaturas;
        }

        public int GetCantidad()
        {
            return temperaturas.Count;
        }

    }
}
