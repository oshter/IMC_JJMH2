using IMC_JJMH2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IMC_JJMH2.ViewModels
{
    public class IMCViewModels : INotifyPropertyChanged
    {
        //Los entrys capturan texto, incluso al escribir numeros
        public string PesoT { get; set; } ="";
        public string EstaturaT { get; set; } ="";

        private string resultado = "Ingresa tus datos";

        public string Resultado
        {
            get { return resultado; }
            set{ 
                resultado = value;

                //avisar al label que el resultado cambio
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Resultado)));

            }
        }

        //El boton usara este comando mediante binding 
        public ICommand CalcularCommand { get; set; }

        //Al ejecutar el comando se llama calcular
        public IMCViewModels()
        {
            CalcularCommand = new Command(Calcular);
        }


        //el binding escucha este evento 
        public event PropertyChangedEventHandler? PropertyChanged;

        private void Calcular()
        {
            //Validar cada camo por separado
            double peso;
            bool pesoValido = double.TryParse(PesoT, out peso);
            double estatura;
            bool estaturaValida = double.TryParse(EstaturaT, out estatura);

            if (pesoValido == false || !double.IsFinite(peso) || peso <= 0)
            {
                Resultado = "Peso invalido";
                return;
            }
            if (estaturaValida == false || !double.IsFinite(estatura) || estatura <= 0)
            {
                Resultado = "Estatura invalida.";
                return;
            }

            //Crear el modelo y le asignamos datos
            Persona persona = new Persona();
            persona.Peso = peso;
            persona.Estatura = estatura;

            //El modelo realiza la operacion 
            double imc = persona.CalcularIMC();

            //evitamos mostrar un resultado numerico invalido 
            if (!double.IsFinite(imc))
            {
                Resultado = "Revisa el peso y estatura.";
                return;
            }

            //F2 muestra el numero con 2 decimales
            Resultado = "Tu IMC es: " + imc.ToString("F2");



        }
    }
}
