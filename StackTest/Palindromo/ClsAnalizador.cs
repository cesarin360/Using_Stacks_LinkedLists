using StackTest.Clases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StackTest.Palindromo
{
    class ClsAnalizador
    {
        public void palindromo()
        {
            PilaLineal pilaChar;
            bool esPalindromo;
            try
            {
                pilaChar = new PilaLineal();
                Console.WriteLine("Teclee una palabra: ");
                String pal = "";
                //Quito los espacios y las letras con tilde
                pal = Regex.Replace(Console.ReadLine().Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9]+", "")
                    + Regex.Replace(pal, @"\s", "").ToLower();

                for (int i = 0; i < pal.Length;)
                {
                    Char c;
                    c = pal[i++];
                    if (c != ' ')
                    {
                        pilaChar.insertar(c);
                    }
                }
                esPalindromo = true;
                for (int j = pal.Length-1; esPalindromo && !pilaChar.pilaVacia();)
                {
                    char c;
                    c = (char)pilaChar.quitarChar();
                    esPalindromo = pal[j--] == c;
                }
                pilaChar.limpiarPila();
                if (esPalindromo)
                {
                    Console.WriteLine($"la palabra {pal} es palindromo");
                }
                else
                {
                    Console.WriteLine("Nel no es");
                }

            }
            catch (Exception error)
            {
                Console.WriteLine($"Upss error {error.Message}");
            }
        }
    }
}
