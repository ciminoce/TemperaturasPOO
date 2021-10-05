using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperaturasPOO.Entidades;

namespace TemperaturasPOO.Datos
{
    public class TemperaturasRepositorio
    {
        private List<Temperatura> temperaturas;
        private readonly string _archivo = Environment.CurrentDirectory + @"\Temperaturas.txt";
        private readonly string _archivoBak = Environment.CurrentDirectory + @"\Temperaturas.bak";

        public TemperaturasRepositorio()
        {
            temperaturas = new List<Temperatura>();
            LeerDatosDelArchivo();
        }

        public bool Existe(Temperatura temperatura)
        {
            return temperaturas.Contains(temperatura);
            //return temperaturas.Any(t => t.GetGrados() == temperatura.GetGrados());
        }

        public void Agregar(Temperatura temperatura)
        {
            AgregarEnArchivo(temperatura);
            temperaturas.Add(temperatura);
        }

        private void AgregarEnArchivo(Temperatura temperatura)
        {
            StreamWriter escritor = new StreamWriter(_archivo, true);
            var linea = ConstruirLinea(temperatura);
            escritor.WriteLine(linea);
            escritor.Close();
        }

        private string ConstruirLinea(Temperatura temperatura)
        {
            return $"{temperatura.GetGrados()}";
        }

        public List<Temperatura> GetLista()
        {
            return temperaturas;
        }

        public int GetCantidad()
        {
            return temperaturas.Count;
        }

        public bool Borrar(Temperatura temperatura)
        {
            BorrarDelArchivo(temperatura);
            return temperaturas.Remove(temperatura);
        }

        private void BorrarDelArchivo(Temperatura temperatura)
        {
            StreamReader lector = new StreamReader(_archivo);
            StreamWriter escritor = new StreamWriter(_archivoBak);
            while (!lector.EndOfStream)
            {
                var linea = lector.ReadLine();
                Temperatura temperaturaEnArchivo = ConstruirTemperatura(linea);
                if (!temperaturaEnArchivo.Equals(temperatura))
                {
                    escritor.WriteLine(linea);
                }
            }
            lector.Close();
            escritor.Close();
            File.Delete(_archivo);
            File.Move(_archivoBak,_archivo);
        }

        private void LeerDatosDelArchivo()
        {
            if (!File.Exists(_archivo))
            {
                return;
            }

            StreamReader lector = new StreamReader(_archivo);
            while (!lector.EndOfStream)
            {
                var linea = lector.ReadLine();
                Temperatura t = ConstruirTemperatura(linea);
                temperaturas.Add(t);
            }
            lector.Close();
        }

        private Temperatura ConstruirTemperatura(string linea)
        {
            return new Temperatura(double.Parse(linea));
        }
    }
}
