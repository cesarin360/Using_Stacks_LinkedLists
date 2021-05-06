using java.lang;
using StackTest.Clases;
using StackTest.Lista;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StackTest.ResuelveEcuaciones
{ 
    class equations_NoVar
    {
        //Utilizo un poco la logica de los arboles binarios al resolver la ecuación
        int syntaxError = 0; //selecciona el indice 0 en el array en la clase Error
        int brackets = 1; //Cuando hay error de parentesis
        int divEntreCero = 3;//cuando se divide entre 0
        private string exp; //Almacena la cadena de la expresión
        private int cima; // indica el indice actual de la expresion
        private string digito; // contiene token actual
        private int Charactertype; //contiene que tipo de caracter es 
        private PilaLineal pilaChar;//Clase PilaLineal
        private Error err;//Clase error 

        //Evalua la expesión
        public double evaluar(string cadenaExp)
        {
            err = new Error();
            double resultado;
            cima = 0;
            try
            {//Quito los espacios en blanco 
                exp = Regex.Replace(cadenaExp, @"\s", "");
                pilaChar = new PilaLineal();
                int i = 0;
                //inserto a la lista enlazada por medio de {PilaLineal}
                do
                {
                    Char c;
                    c = exp[i++];
                    pilaChar.insertar(c);

                } while (i <= exp.Length-1);
                GetToken();
                // analiza y evalua la expresion
                resultado = evaluaSumaResta();
            }
            catch (System.Exception err)
            {
                throw new System.Exception("La pila esta vacia, no se puede sacar" + err.Message);
            }
            return resultado;
        }

        // metodo para suma o resta
        private double evaluaSumaResta()
        {
            char op;
            double tot;
            double subTot;
            //Antes de sumar o resta verificamos la multiplicación y división
            tot = evaluaMultDiv();
            //Si cuando igualmamos la variable op a el digito y es igual a + o - entra al bucle
            while ((op = digito[0]) == '+' || op == '-')
            {
                //Obtenemos el token con el segundo digito que se sumara 
                GetToken();
                //Evaluamos si existe otra multiplicación
                subTot = evaluaMultDiv();
                switch (op)
                {
                    //Si op es igual a '-' entonces se sumara el total de los dos extremos de la resta
                    case '-':
                        tot = tot - subTot;
                        break;
                    //Si op es igual a '+' entonces se sumara el total de los dos extremos de la suma
                    case '+':
                        tot = tot + subTot;
                        break;
                }
            }
            return tot;
        }
        // metodo para multiplicacion y division
        private double evaluaMultDiv()
        {
            char op;
            double tot;
            double subTot;
            //Antes de evaluar una multiplicación o división vamos a evualuar si existe un exponente 
            tot = exponente();
            //Si op es igual a '*' o '/' entra al bucle 
            while ((op = digito[0]) == '*' || op == '/')
            {
                //Se obtienen el token con el que se va a multiplicar o dividir 
                GetToken();
                //Se obtiene el valor del exponente, si lo hubiera. Si no es así se obtiene el valor 
                //numerico con el que se va a multiplcar 
                subTot = exponente();
                switch (op)
                {
                    case '*':
                        tot = tot * subTot;
                        break;
                    case '/':
                        if (subTot == 0.0)
                        {
                            err.GetError(divEntreCero);
                        }
                        tot /= subTot;
                        break;
                }
            }
            return tot;
        }

        // metodo que evalua un exponente
        private double exponente()
        {
            double tot;
            double subtot;
            double ex;
            int t;
            //Evaluamos los parentesis
            tot = evaluaParentesis();
            if (digito.Equals("^"))
            {
                GetToken();
                subtot = exponente();
                ex = tot;
                if (subtot == 0.0)
                {
                    tot = 1.0;
                }
                else
                {
                    for (t = (int)subtot - 1; t > 0; t--)
                    {
                        tot = tot * ex;
                    }
                }
            }
            return tot;
        }
        // metodo que procesa los parentesis
        private double evaluaParentesis()
        {
            double tot;
            if (digito.Equals("("))
            {
                GetToken();
                tot = evaluaSumaResta();
                if (!digito.Equals(")"))
                {
                    err.GetError(brackets);
                }
                GetToken();
            }
            else
            {
                tot = this.tot();
            }
            return tot;
        }

        //Metodo que obtiene el valor de un numero
        private double tot()
        {
            double tot = 0.0;
            switch (Charactertype)
            {
                case 3:
                    try
                    {
                        tot = double.Parse(digito);
                    }
                    catch (NumberFormatException exc)
                    {
                        err.GetError(syntaxError);
                        Console.WriteLine($"Error: {exc}");
                    }
                    GetToken();
                    break;
                default:
                    err.GetError(syntaxError);
                    break;
            }
            return tot;
        }

        private void GetToken()
        {
            digito = "";
            Charactertype = 0;
            Char digit = (char)pilaChar.lista.dato;
            if (cima == exp.Length)
            {
                digito = "\0";
                return;
            }
            if (op(digit))
            {
                digito += digit;
                cima++;
                Charactertype = 1;
                if (cima <= exp.Length - 1)
                {
                    pilaChar.lista = pilaChar.lista.enlace;
                    digit = (char)pilaChar.lista.dato;
                }
            }
            else if (Char.IsDigit(digit))
            {
                while (!op(digit))
                {
                    digito += digit;
                    cima++;
                    if (cima <= exp.Length-1)
                    {
                        pilaChar.lista = pilaChar.lista.enlace;
                        digit = (char)pilaChar.lista.dato;
                    }
                    if (cima >= exp.Length)
                    {
                        break;
                    }
                }
                Charactertype = 3;
            }
            else
            { //caracter desconocido termina la expresion
                Console.WriteLine("Error Caracter ingresado desconocido");
                digito = "\0";
                return;
            }
        }
        private bool op(object elemento)
        {
            if (("+-*/^()".IndexOf((char)elemento) != -1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
