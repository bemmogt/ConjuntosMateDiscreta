using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionesConjuntos
{
   public class Conjunto
    {
        public List<string> Elementos { get; private set; }

        public Conjunto(List<string> elementos)
        {
            Elementos = elementos;
        }

        public Conjunto Union(Conjunto otro)
        {
            return new Conjunto(Elementos.Union(otro.Elementos).ToList());
        }

        public Conjunto Interseccion(Conjunto otro)
        {
            return new Conjunto(Elementos.Intersect(otro.Elementos).ToList());
        }

        public Conjunto Diferencia(Conjunto otro)
        {
            return new Conjunto(Elementos.Except(otro.Elementos).ToList());
        }

        public Conjunto DiferenciaAritmetica(Conjunto otro)
        {
            return new Conjunto(Elementos.Except(otro.Elementos).Union(otro.Elementos.Except(Elementos)).ToList());
        }

        public Conjunto Complemento(List<string> universo)
        {
            return new Conjunto(universo.Except(Elementos).ToList());
        }

        public Conjunto ProductoEscalar(int escalar)
        {
            var nuevoConjunto = new List<string>();
            for (int i = 0; i < escalar; i++)
            {
                nuevoConjunto.AddRange(Elementos);
            }
            return new Conjunto(nuevoConjunto);
        }

        public void Mostrar()
        {
            Console.WriteLine($"{{ {string.Join(", ", Elementos)} }}");
        }
    }
}
