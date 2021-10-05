using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperaturasPOO.Entidades
{
    public class Temperatura
    {
        private double Grados;

        public void SetGrados(double grados)
        {
            Grados = grados;
        }

        public double GetGrados()
        {
            return Grados;
        }

        public Temperatura()//Constructor por defecto
        {
             //SetGrados(ObtenerTemperatura(-10.0,26.9));   
        }

        public Temperatura(double grados)
        {
            Grados = grados;
        }
        private double ObtenerTemperatura(double limiteInferior, double limiteSuperior)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            var resultado = r.NextDouble() * (limiteSuperior - limiteInferior) + limiteInferior;// 15,25698
            var partesDelNumero = resultado.ToString().Split(',');//15 25698
            var parteEntera = partesDelNumero[0];
            var parteDecimal = partesDelNumero[1];
            return Convert.ToDouble($"{parteEntera},{parteDecimal[0]}");
        }

        public double GetFahrenheit()
        {
            return 1.8 * Grados + 32;
        }

        public double GetReaumur()
        {
            return 0.8*Grados ;
        }

        public override bool Equals(object obj)
        {
            if (obj==null || !(obj is Temperatura))
            {
                return false;
            }

            return this.Grados == ((Temperatura) obj).Grados;
        }

        public override int GetHashCode()
        {
            return this.Grados.GetHashCode();
        }
    }
}
