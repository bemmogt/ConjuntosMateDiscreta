using System;
using System.Collections.Generic;
using System.Linq;

namespace OperacionesConjuntos
{
    class Program
    {
        static List<string> universo = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al sistema de Operaciones con Conjuntos.");
            IngresarUniverso();
            int cantidadConjuntos = IngresarCantidadConjuntos();

            List<Conjunto> conjuntos = new List<Conjunto>();

            // se le solicita al usuario que ingrese los datos
            for (int i = 0; i < cantidadConjuntos; i++)
            {
                Console.WriteLine($"Ingrese los elementos para el conjunto {i + 1}:");
                conjuntos.Add(new Conjunto(IngresarConjunto()));
            }

            // aquí se muestra el menú de opciones
            while (true)
            {
                Console.WriteLine("\nSeleccione la operación a realizar:");
                Console.WriteLine("1. Unión");
                Console.WriteLine("2. Intersección");
                Console.WriteLine("3. Diferencia");
                Console.WriteLine("4. Diferencia Simétrica");
                Console.WriteLine("5. Complemento");
                Console.WriteLine("6. Producto Escalar");
                Console.WriteLine("0. Salir");

                string opcion = Console.ReadLine();

                if (opcion == "0")
                    break;

                // aquí se escogen los conjuntos que se van a operar
                Conjunto conjunto1 = SeleccionarConjunto(conjuntos, "primer");
                Conjunto conjunto2 = null;

                if (opcion != "5") // aquí en esta línea se deja un solo conjunto ya que en el complemento solo se necesita uno.
                    conjunto2 = SeleccionarConjunto(conjuntos, "segundo");

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Resultado de la Unión: ");
                        conjunto1.Union(conjunto2).Mostrar();
                        break;
                    case "2":
                        Console.WriteLine("Resultado de la Intersección: ");
                        conjunto1.Interseccion(conjunto2).Mostrar();
                        break;
                    case "3":
                        Console.WriteLine("Resultado de la Diferencia: ");
                        conjunto1.Diferencia(conjunto2).Mostrar();
                        break;
                    case "4":
                        Console.WriteLine("Resultado de la Diferencia Simétrica: ");
                        conjunto1.DiferenciaAritmetica(conjunto2).Mostrar();
                        break;
                    case "5":
                        Console.WriteLine("Resultado del Complemento: ");
                        conjunto1.Complemento(universo).Mostrar();
                        break;
                    case "6":
                        Console.WriteLine("Resultado del Producto Escalar: ");
                        Console.Write("Ingrese un escalar: ");
                        int escalar = int.Parse(Console.ReadLine());
                        conjunto1.ProductoEscalar(escalar).Mostrar();
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
        }

        // aquí están las funciones o métodos que se utilizarán como auxiliares
        static void IngresarUniverso()
        {
            Console.WriteLine("Ingrese los elementos del universo separados por comas:");
            universo = Console.ReadLine().Split(',').Select(e => e.Trim()).ToList();
        }

        static int IngresarCantidadConjuntos()
        {
            Console.Write("Ingrese la cantidad de conjuntos: ");
            return int.Parse(Console.ReadLine());
        }

        static List<string> IngresarConjunto()
        {
            List<string> conjunto;
            while (true)
            {
                Console.WriteLine("Ingrese los elementos del conjunto separados por comas (máximo 10):");
                conjunto = Console.ReadLine().Split(',').Select(e => e.Trim()).Take(10).ToList();

                // validamos de que los elementos ingresados formen parte del conjunto universo y si ingresa uno que no está ahí, le muestra un error
                if (conjunto.All(e => universo.Contains(e)))
                    break;
                else
                    Console.WriteLine("Error: Todos los elementos deben pertenecer al universo. Inténtelo de nuevo.");
            }
            return conjunto;
        }

        // este método es para seleccionar el conjunto al mmomento de que se haga una operación.
        static Conjunto SeleccionarConjunto(List<Conjunto> conjuntos, string descripcion)
        {
            Console.WriteLine($"Seleccione el {descripcion} conjunto (1 - {conjuntos.Count}):");
            int indice = int.Parse(Console.ReadLine()) - 1;
            return conjuntos[indice];
        }
    }

}
