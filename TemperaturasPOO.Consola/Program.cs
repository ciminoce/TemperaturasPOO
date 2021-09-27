using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperaturasPOO.Datos;
using TemperaturasPOO.Entidades;

namespace TemperaturasPOO.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            //double[] temperaturas = new double[7];
            //List<double> temperaturas = new List<double>();
            //List<Temperatura> temperaturas = new List<Temperatura>();
            TemperaturasRepositorio repositorio = new TemperaturasRepositorio();
            for (int i = 0; i < 7; i++)
            {
                //var temperatura = ObtenerTemperatura(-10.0, 26.9);
                //temperaturas[i] = temperatura;
                //temperaturas.Add(temperatura);
                //Temperatura t = new Temperatura();//cree un obj de tipo Temperatura
                //t.Grados = ObtenerTemperatura(-10.0, 26.9);
                //t.SetGrados(ObtenerTemperatura(-10.0,26.9));
                //Temperatura t = new Temperatura(ObtenerTemperatura(-10.0, 26.9));
                var t = new Temperatura();
                
                //temperaturas.Add(t);//Agrego la temperatura a la lista
                repositorio.Agregar(t);

            }

            foreach (var temperatura in repositorio.GetLista())
            {
                //Console.WriteLine(temperatura.Grados);
                Console.WriteLine(temperatura.GetGrados());
            }

            Console.WriteLine($"Cantidad de temperaturas:{repositorio.GetCantidad()}");
            Console.ReadLine();
        }

        //private static double ObtenerTemperatura(double limiteInferior, double limiteSuperior)
        //{
        //    Random r = new Random(Guid.NewGuid().GetHashCode());
        //    var resultado= r.NextDouble() * (limiteSuperior - limiteInferior) + limiteInferior;// 15,25698
        //    var partesDelNumero = resultado.ToString().Split(',');//15 25698
        //    var parteEntera = partesDelNumero[0];
        //    var parteDecimal = partesDelNumero[1];
        //    return Convert.ToDouble($"{parteEntera},{parteDecimal[0]}");
        //}
    }
}
