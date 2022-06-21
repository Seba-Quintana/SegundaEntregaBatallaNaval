using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de ver cosas como el Perfil, el Ranking y el Historial y los tableros.
    /// Se encarga de crear Partidas Amistosas y tambien de buscar Partidas
    /// Esta clase tiene catch en sus metodos para poder atrapar las excepciones que suceden
    /// en partes mas internas del programa (por propagacion de excepciones), y llama
    /// a la impresora para imprimir un mensaje de error.
    /// </summary>
    public class Jugador
    {
      /// <summary>
      /// Numero del jugador. Sirve como identificación.
      /// </summary>
      public int NumeroDeJugador;

      /// <summary>
      /// Constructor del jugador.
      /// </summary>
      /// <param name="nombre"> nombre del jugador </param>
      /// <param name="id"> La id es para simular la id caracteristica del usuario,
      /// la cual es proporcionada por el bot </param>
      /// <param name="contraseña"> contraseña del jugador </param>
      public Jugador(string nombre, int id, string contraseña)
      {
        try
        {
          this.NumeroDeJugador = Admin.Registrar(nombre, id, contraseña);
        }
        catch (Exception)
        {
          Iimpresora impresora = ImpresoraConsola.Instance();
          impresora.RecibirMensajes("no se pudo crear un jugador");
        }
      }

      /// <summary>
      /// Remueve el jugador de la lista de usuarios
      /// </summary>
      public string Remover()
      {
        try
        {
          return Admin.Remover(this.NumeroDeJugador);
        }
        catch (Exception)
        {
          return "no se pudo remover el jugador";
        }
      }
      
      /// <summary>
      /// Permite al jugador visualizar su perfil
      /// </summary>
      /// <param name="perfil"></param>
      public void VerPerfil(int perfil)
      {
        try
        {
          Admin.VerPerfil(perfil);
        }
        catch (Exception)
        {
          Iimpresora impresora = ImpresoraConsola.Instance();
          impresora.RecibirMensajes("no se pudo ver el perfil del jugador");
        }
      }
    
      /// <summary>
      /// Permite al jugador visualizar el ranking
      /// </summary>
      public void VerRanking()
      {
        try
        {
          Admin.VerRanking();
        }
        catch (Exception)
        {
          Iimpresora impresora = ImpresoraConsola.Instance();
          impresora.RecibirMensajes("no se pudo ver el ranking");
        }
      }
    
      /// <summary>
      /// Permite al jugador ver el historial
      /// </summary>
      public void VerHistorial()
      {
        try
        {
          Admin.VerHistorial();
        }
        catch (Exception)
        {
          Iimpresora impresora = ImpresoraConsola.Instance();
          impresora.RecibirMensajes("No se pudo ver el historial");
        }
      }
    
      /// <summary>
      /// Permite al jugador ver su historial personal
      /// </summary>
      /// <param name="numerodejugador"> jugador del que se quiere ver el historial </param>
      public void VerHistorialPersonal(int numerodejugador)
      {
        try
        {
          Admin.VerHistorialPersonal(numerodejugador);
        }
        catch (Exception)
        {
          Iimpresora impresora = ImpresoraConsola.Instance();
          impresora.RecibirMensajes("No se pudo ver el historial");
        }
      }

      /// <summary>
      /// Permite al jugador visualizar el tablero actual
      /// </summary>
      public void VisualizarTableros()
      {
        try
        {
          Admin.VerTableroOponente(this.NumeroDeJugador);
          Admin.VerTablero(this.NumeroDeJugador);
        }
        catch (Exception)
        {
          Iimpresora impresora = ImpresoraConsola.Instance();
          impresora.RecibirMensajes("No se pudo ver el tablero");
        }
      }

      /// <summary>
      /// Busqueda de partida amistosa (jugar partida con un amigo)
      /// </summary>
      /// <param name="modo"> modo de juego elegido </param>
      /// <param name="jugador2"> jugador con el que se quiere emparejar </param>
      /// <param name="tamano"> tamaño del tablero </param>
      public string PartidaAmistosa(int modo, int jugador2, int tamano)
      {
        try
        {
          return Admin.EmparejarAmigos(modo, this.NumeroDeJugador, jugador2, tamano);
        }
        catch (Exception)
        {
          return "No se ha podido emparejar a los jugadores";
        }
      }
    
      /// <summary>
      /// Busqueda de partida (partida con oponente aleatorio)
      /// </summary>
      /// <param name="modo"> modo de juego elegido </param>
      /// <param name="tamano"></param>
      public string BuscarPartida(int modo, int tamano)
      {
        try
        {
          return Admin.Emparejar(modo, this.NumeroDeJugador, tamano);
        }
        catch (Exception)
        {
          return "No se pudo emparejar con otro jugador";
        }
      }

      /// <summary>
      /// Permite al jugador posicionar barcos
      /// </summary>
      /// <param name="inicio"> coordenada que indica la primera casilla del barco </param>
      /// <param name="final"> coordenada que indica la ultima casilla del barco </param>
      public string PosicionarBarcos(string inicio, string final)
      {
        try
        {
          return Admin.Posicionar(inicio ,final ,NumeroDeJugador);
        }
        catch (Exception)
        {
          return "No se ha podido posicionar el barco";
        }
      }

      /// <summary>
      /// Permite al jugador atacar
      /// </summary>
      /// <param name="coordenada"> coordenada de ataque </param>
      public string Atacar(string coordenada)
      {
        try
        {
          return Admin.Atacar(coordenada, NumeroDeJugador);
        }
        catch (Exception)
        {
          return "no se ha podido realizar el ataque";
        }
      }

      /// <summary>
      /// Permite al jugador rendirse
      /// </summary>
      public string Rendirse()
      {
        try
        {
          return Admin.Rendirse(this.NumeroDeJugador);
        }
        catch (Exception)
        {
          return "No se ha podido efectuar la rendicion";
        }
      }
    }
}
