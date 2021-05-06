using System;
using System.Collections.Generic;
using System.Text;

namespace StackTest.ResuelveEcuaciones
{
    class Error
    {
        public void GetError(int error)
        {
            string[]
            err = {"SYNTAX ERROR",
                "AL PARECER FALTO UN PARENTESIS",
                "VACIO",
                "DIV/0"
            };
            throw new Exception(err[error]);
        }
    }
}
