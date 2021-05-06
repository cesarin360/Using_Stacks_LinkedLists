using System;
using System.Collections.Generic;
using System.Text;

namespace StackTest.Lista
{
    class ClsListaOrdenada
    {
        public Nodo1 cabeza, cola;//Es el nodo que se llama primero 

        public ClsListaOrdenada()
        {
            cabeza = null;
            cola = null;
        }

        //inserta 
        public ClsListaOrdenada insertaInverso(Object entrada)
        {
            Nodo1 nuevo;
            nuevo = new Nodo1(entrada);

            if(cabeza == null)
            {
                cabeza = nuevo;
                cabeza.enlace = null;
                cola = nuevo;
            }
            else
            {
                cola.enlace = nuevo;
                nuevo.enlace = null;
                cola = nuevo;
            }
            return this;
        }


        public void eliminar(Object entrada)
        {
            Nodo1 actual, anterior;
            bool encontrado;
            //Inicializa los apuntadores

            actual = cabeza;
            anterior = null;
            encontrado = false;
            //Busqueda del nodo anterior
            while ((actual != null) && (!encontrado))
            {
                encontrado = (actual.dato == entrada);

                if (!encontrado)
                {
                    anterior = actual;
                    actual = actual.enlace;
                }
            }//end while

            //enlace del nodo anterior con el siguiente 
            if (actual != null)
            {
                //distinguir si el nodo inicial o cabeza o si
                if (actual == cabeza)
                {
                    cabeza = actual.enlace;
                }
                else
                {
                    anterior.enlace = actual.enlace;
                }
                actual = null;
            }
        }
    }
}
