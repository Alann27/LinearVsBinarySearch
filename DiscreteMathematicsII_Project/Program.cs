using DiscreteMathematicsII_Project.Services;
using DiscreteMathematicsII_Project.Utils;
using System;
using System.Threading.Tasks;

namespace DiscreteMathematicsII_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            InitProgram().Wait();
        }

        public static async Task InitProgram()
        {
            Console.WriteLine($"Cuantas personas quieres generar? El límite es {Constants.idLimit.ToString("N0")}.");
            int personQuantity = Convert.ToInt32(Console.ReadLine());

            while (personQuantity > Constants.idLimit)
            {
                Console.WriteLine($"Debes ingresar una cantidad menor a {Constants.idLimit.ToString("N0")}. Cuantas personas quieres generar?");
                personQuantity = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("\nGenerando personas aleatoriamente...");
            await Bootstrap.Init(personQuantity);
            Console.WriteLine($"{personQuantity} Personas generadas");

            PersonService personService = new PersonService();
            int id = -1;

            while (true)
            {
                try
                {
                    Console.WriteLine($"\nIngrese el Id de la persona que desea buscar teniendo como máximo {Constants.idLimit.ToString("N0")}; si desea acabar la búsqueda ingrese 0");
                    Console.Write("Id: ");
                    id = Convert.ToInt32(Console.ReadLine());

                    if (id == 0) return;

                    var binary = personService.GetPersonWithBinary(id);
                    if (binary.person != null)
                    {
                        Console.WriteLine($"\nLa persona con el Id {id} es: {binary.person.FirstName} {binary.person.LastName} con el teléfono {binary.person.Cellphone}.");
                        var linear = personService.GetPersonWithLinear(binary.person.Id);
                        Console.WriteLine("\nComparaciones hechas\n");
                        Console.WriteLine($"Búsqueda binaria: {binary.comparisons}");
                        Console.WriteLine($"Búsqueda lineal: {linear.comparisons.ToString("N0")}");
                    }
                    else
                    {
                        Console.WriteLine($"\nNinguna persona encontrada con el Id {id}, se hicieron {binary.comparisons} comparaciones al usar búsqueda binaria");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Se ingresaron caracteres no numéricos, favor de solo ingresar números.");
                }
            }
        }
    }
}
