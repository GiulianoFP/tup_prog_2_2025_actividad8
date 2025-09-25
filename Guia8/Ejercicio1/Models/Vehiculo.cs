using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Vehiculo
    {
        public string Patente;
        public double Importe;

        public Vehiculo(string patente, double importe)
        {
            Patente = patente;
            Importe = importe;
        }

        public override string ToString()
        {
            return $"Patente:{Patente}  Importe:${Importe}";
        }
    }
}
