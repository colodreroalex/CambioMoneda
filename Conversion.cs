using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace Relacion24
{

    public class Conversion
    {
        const string FICHERO = "Conversion.txt";
        const double EURO_DOLLAR = 1.3635;
        const double DOLLAR_EURO = 0.7374;


        static double _euros = 0f;
        static double _dollars = 0f;




        public static void LeerFichero()
        {
            StreamReader lector = null;
            lector = File.OpenText(FICHERO);

            try
            {

                while (lector.ReadLine() != null)
                {
                    _euros = Convert.ToDouble(lector.ReadLine());
                    _dollars = Convert.ToDouble(lector.ReadLine());
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("El fichero de configuracion no existe , se crearan unas tasas por defecto tal como pide el enunciado..");
                _euros = DOLLAR_EURO;
                _dollars = EURO_DOLLAR;
            }

            lector.Close();
        }

        public static void CambiarTasas()
        {
            StreamWriter sw = null;
            string respuesta;

            if (File.Exists(FICHERO))
            {
                File.Delete(FICHERO);
            }

            sw = File.CreateText(FICHERO);



            do
            {
                Console.WriteLine("Introduce las nuevas tasas de conversion: ");
                Console.Write("1 euro = ");
                _euros = Single.Parse(Console.ReadLine());

                //Escribirlo en fichero
                sw.WriteLine(_euros);

                Console.WriteLine("1 dollar = ");
                _dollars = float.Parse(Console.ReadLine());

                //Escribirlo en fichero
                sw.WriteLine(_dollars);

                Console.WriteLine("Las nuevas tasas de conversion son: ");
                Console.WriteLine($"1 euro = {_euros} dollares");
                Console.WriteLine($"1 dollar = {_dollars} euros");

                Console.WriteLine("Desea guardar los cambios en el fichero? S/N");
                respuesta = Console.ReadLine();
                sw.WriteLine($"Respuesta: {respuesta}");


            } while (respuesta.ToLower() == "N");


            sw.Close();



        }

        public static double EurosADolares(double cantidadDolar)
        {
            StreamReader file = null;
            file = File.OpenText(FICHERO);

            double tasa;

            tasa = Convert.ToDouble(file.ReadLine());




            return cantidadDolar * tasa;
        }

        public static double DolaresAEuros(double cantidadEuro)
        {
            StreamReader file = null;

            file = File.OpenText(FICHERO);
            double tasa = 0;

            //Leo 1 linea , me la paso por el forro
            file.ReadLine();
            //La segunda si la guardo
            tasa = Convert.ToDouble(file.ReadLine());

            return cantidadEuro * tasa;
        }
    }
}
