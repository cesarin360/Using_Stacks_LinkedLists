using System;
using System.Collections.Generic;
using System.Text;

namespace StackTest.Lista
{
    class Nodo1
    {
        public Object dato;
        public Nodo1 enlace;


        public Nodo1(Object x)
        {
            dato = x;
            enlace = null;
        }

        public Nodo1(int x, Nodo1 n)
        {
            dato = x;
            enlace = n;
        }

        public Object getDato()
        {
            return dato;

        }

        public Nodo1 getEnlace()
        {
            return enlace;
        }
        public void setEnlace(Nodo1 enlace)
        {
            this.enlace = enlace;
        }
    }
}
