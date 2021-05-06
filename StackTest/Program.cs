using StackTest.Clases;
using StackTest.Palindromo;
using StackTest.ResuelveEcuaciones;
using System;

namespace StackTest
{
    class Program
    {
        static void evaluaEc()
        {
            string expresion;
            equations_NoVar eq = new equations_NoVar();
            Console.Write("****| Por favor, ingrese una expresión matematica: \n");
            expresion = Console.ReadLine();
            try
            {
                Console.WriteLine("RESULTADO: " + eq.evaluar(expresion));
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        static void listaInversa()
        {
            int dato;
            String datos = "";
            PilaLineal pila;
            int CLAVE = -1;

            Console.WriteLine("****|Ingrese numeros, y para terminar -1: \n");
            try
            {
                pila = new PilaLineal();
                do
                {
                    dato = Convert.ToInt32(Console.ReadLine());
                    if (dato != CLAVE)
                    {
                        pila.insertar(dato);
                    }

                } while (dato != CLAVE);
                Console.WriteLine("****|Estos son los elementos de la pila a la inversa: \n");

                while (!pila.pilaVacia())
                {
                    datos += pila.quitar()+ ",";
                }
                int i = datos.Split(",").Length-2;
                do
                {
                    String c;
                    c = datos.Split(",")[i--];
                    if (c != " ")
                    {
                        Console.WriteLine($"****|Elemento: {c}");
                    }

                } while (i >= 0);
  
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error = {err.Message}");
            }
            
        }
        static void Main(string[] args)
        {
           // ClsAnalizador pal = new ClsAnalizador();
            //pal.palindromo();
            //evaluaEc();
            listaInversa();
           
        }
    }
}
