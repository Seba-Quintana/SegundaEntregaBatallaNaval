using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de ver cosas como el Perfil, el Ranking y el Historial.
    /// Se encarga de crear Partidas Amistosas y tambien de buscar Partidas
    /// Visualiza al tablero.
    /// </summary>
    public class Jugador
    {
      
      public void VerPerfil(int perfil)
      {
         //Admin ad = Admin.Instance();
         try
         {
            //ad.ObtenerPerfil(perfil);
         }
        catch
        {
          Console.WriteLine("No existe un perfil con ese Número de jugador.");
        }
      }  
    
      public void VerRanking()
      {
         //Admin ad = Admin.Instance();
         try
         {
            //ad.ObtenerRanking();
         }      
        catch
        {
          Console.WriteLine("No existe un Ranking.");
        }
      } 
    
      public void VerHistorial(int historial)
      {
          //Admin ad = Admin.Instance();
          try
          {
            //ad.ObtenerHistorial(historial);
          }
          catch
          {
            Console.WriteLine("No hay nada registrado dentro del Historial");
          }
      }
    
      public void PartidaAmistosa(int modo, int jugador1, int jugador2)
      {
        //Admin ad = Admin.Instance();
        try
        {
          //ad.EmparejarAmigos(modo, jugador1, jugador2);
        }
        catch
        {
          Console.WriteLine("Uno de los jugadores no se encuentran en la partida");
        }
      }
    
      public void BuscarPartida(int modo, int jugador1)
      {

        //Admin ad = Admin.Instance();
        try
        {
         //ad.Emparejar(modo, jugador1);
        }
        catch
        {
          Console.WriteLine("No se pudo encontrar una partida");
        }
      
      }
      /// <summary>
      /// 
      /// </summary>
      public void VisualizarTablero()
      {
        //Admin ad = Admin.Instance();
        try
        {
        //ad.ObtenerTableroOponente();
        //ad.ObtenerTablero();
        }
        catch
        {
          Console.WriteLine("El tablero no se puede visualizar o no existe");
        }
      }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="inicio"></param>
      /// <param name="final"></param>
      public void PosicionarBarcos(string inicio, string final)
      { 
        try
        {
        //LogicaDePartida.añadirBarco(TraductorDeCoordenadas.Traducir(inicio),TraductorDeCoordenadas.Traducir(final));
        }
        catch
        {
          Console.WriteLine("No se puede posicionar el barco, pruebe otro barco o posición.");
        }
      }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="coordenada"></param>
      public void Atacar(string coordenada)
      {
        try
        {
          //LogicaDePartida.Atacar(TraductorDeCoordenadas.Traducir(coordenada));
        }
        catch
        {
          Console.WriteLine("No se puede atacar a ese barco, lo has golpeado anteriormente");
        }
      }
    }
    

}