using StackTest.Lista;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StackTest.Clases
{
    class PilaLineal
    {
        private int cima;
        private ClsListaOrdenada addfiles = new ClsListaOrdenada();
        public Nodo1 lista;

        public PilaLineal()
        {
            cima = -1; //Condición de pila vacia.
        }
        public bool pilaLlena()
        {
            return cima == 50;
        }
        //Operaciones que modifican la pila 
        public void insertar(Object elemento)
        {
            if (pilaLlena())
            {
                throw new Exception("Desbordamiento de pila Stack Overflow");
            }
            //incrementar puntero cima y vamos a insertar el elemento
            cima++;
            //addfiles.inserta(elemento);
            addfiles.insertaInverso(elemento);

            lista = addfiles.cabeza;

        }

        public bool pilaVacia()
        {
            return cima == -1;
        }
        //Extraer elemento de la pila 

        //Retorna un tipo char
        public object quitarChar()
        {
            char aux;
            if (pilaVacia())
            {
                throw new Exception("Pila Vacia");
            }
            if (lista != null)
            {
                aux = (char)lista.dato;
            }
            else
            {
                aux = ' ';
                return aux;
            }
            lista = lista.enlace;
            cima--;
            return aux;
        }
       
        public Object quitar()
        {
            int aux;
            if (pilaVacia())
            {
                throw new Exception("La pila esta vacia");
            }
            aux = (int)lista.dato;
            addfiles.eliminar(lista.dato);
            lista = lista.enlace;
            cima--;
            return aux;

        }
        public void limpiarPila()
        {
            cima = -1;
        }
    }

}
