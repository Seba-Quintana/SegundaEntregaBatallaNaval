//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using ClassLibrary;

namespace ConsoleApplication
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            ImpresoraConsola impresora = new ImpresoraConsola();
            Tablero tablero = new Tablero(5,5);
            impresora.ImprimirTablero(tablero.VerTablero(3));
            
        }
    }
}