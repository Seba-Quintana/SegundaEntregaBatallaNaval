using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    public class Admin
    {
        public static List<PerfilUsuario> ListaDeUsuarios;
    
        public void Registrar(string nombre, int id, string contraseña)
        {
            //PerfilUsuario perfilusuario = new PerfilUsuario (nombre,id,contraseña);
            //ListaDeUsuarios.Add(perfilusuario);

        }
        public void Remover(int NumeroDeJugador)
        {
            foreach (PerfilUsuario usuario in ListaDeUsuarios)
            {
                if (usuario.NumeroDeJugador == NumeroDeJugador)
                {
                    ListaDeUsuarios.Remove(usuario);
                }
            }
        }
        void ObtenerPerfil(int NumeroDePerfil)
        {
            //Iimpresora.ImprimirPerfilUsuario(NumeroDePerfil);
        }
        
        void ObtenerTableroAtaque(string[] tableroOponente)
        {
            //Iimpresora.ImprimirTableroOponente(tableroOponente);
        }

        void ObtenerTableroDefensa(string[] tablero)
        {
            //Iimpresora.ImprimirTablero(tablero);
        }
    
        void ObtenerHistorial()
        {
            //Iimpresora.ImprimirHistorial();
        }
    
        void ObtenerRanking()
        {
            //Iimpresora.ImprimirRanking();
        }
    
        public void ActualizarHistorial(DatosdePartida partida)
        {
            foreach (PerfilUsuario usuario in ListaDeUsuarios)
            {
                if (partida.Ganador == usuario.NumeroDeJugador || partida.Perdedor == usuario.NumeroDeJugador)
                {
                    //PerfilUsuario.AñadiralHistorial(partida);
                }
            }
        }
    
        public void CrearTablero(int Tamaño, int dueño)
        {
            Tablero tablero = new Tablero (Tamaño, dueño);
        }
        
        public void ActualizarTablero(int filas, int columnas, char nuevovalor)
        {
            //Tablero.ActualizarTablero(filas, columnas, nuevovalor);
        }
    }
}
