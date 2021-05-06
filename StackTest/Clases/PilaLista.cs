using StackTest.Lista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackTest.Clases
{
    class PilaLista
    {

        private int cima;
        private readonly ClsListaOrdenada doble = new ClsListaOrdenada();
        Nodo1 lista;

        public PilaLista()
        {
            cima = -1; // condicion de pila vacia.

        }
        public void insertar(Object elemento)
        {
            cima++;
            doble.insertaInverso(elemento);
            lista = doble.cabeza;
            //doble.insertaCabezaLista(elemento);
        }

        public Object quitar()
        {
            Object aux;
            if (pilaVacia())
            {
                throw new Exception("Pila vacia");
            }
            aux = (int)lista.dato;
            doble.eliminar(lista.dato);
            lista = lista.enlace;
            cima--;
            return aux;
        }

        public bool pilaVacia()
        {
            return cima == -1;
        }

        public void limpiarPila()
        {
            while (!pilaVacia())
            {
                quitar();
            }
        }


    }
}
