using System;
using System.Collections.Generic;
using System.Text;

namespace IMC_JJMH2.Models
{
    public class Persona
    {
        //Datos numericos
        public double Peso { get; set; }
        public double Estatura { get; set; }

        public double CalcularIMC()
        {  
            return Peso /(Estatura*Estatura); 
        }
    }
}
