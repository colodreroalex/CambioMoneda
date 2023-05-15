using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relacion24
{
    public static class Interfaz
    {
        public static byte Menu()
        {
            string aux;
            byte opcion;

            
            Console.WriteLine();
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Convertir euros a dólares");
            Console.WriteLine("2. Convertir dólares a euros");
            Console.WriteLine("3. Modificar las tasas de conversión actuales");
            Console.WriteLine("4. Salir del programa");

            aux = Console.ReadLine();

            
            opcion = byte.Parse(aux);

            return opcion;

        }

        public static void OpcionMenu()
        {

            bool salir;
            byte opcionMenu;
            double euros;
            double dollars;

            do
            {
                salir = false;

                opcionMenu = Interfaz.Menu();
                string aux;

                switch (opcionMenu)
                {
                    case 1:
                        Console.Write("Introduzca los euros a convertir: ");
                        euros = Convert.ToDouble(Console.ReadLine());
                        dollars = Conversion.EurosADolares(euros);
                        Console.WriteLine($"{euros} euros son --> {dollars} dolares");
                        //salir = true; 
                        break;
                    case 2:
                        Console.Write("Introduzca los dolares a convertir: ");
                        dollars = Convert.ToDouble(Console.ReadLine());
                        euros = Conversion.DolaresAEuros(dollars);
                        Console.WriteLine($"{dollars} dolares son --> {euros} euros");
                        //salir = true; 
                        break;
                    case 3:
                        Conversion.CambiarTasas();
                        Console.WriteLine("Se han modificado las tasas actuales..");
                        break;
                    case 4:
                        Console.WriteLine("Hasta luego!!");
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opcion no valida...");
                        break;
                }

            } while (!salir);
        }
    }
}
