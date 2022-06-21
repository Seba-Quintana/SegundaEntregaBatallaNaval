using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase Planificador. Se encarga de manejar distintos aspectos del programa,
    /// como los usuarios o el historial.
    /// </summary>
    public static class Planificador
    {
        /// <summary>
        /// Crea un nuevo perfil de usuario asignandole un numero de jugador.
        /// Si es el primer usuario creado le asigna el numero 1, de lo contrario le asigna el
        /// numero mas alto de un jugador existente +1,
        /// y luego crea un PerfilUsuario con los datos necesarios para agregarlo a la lista de usuarios.
        /// </summary>
        /// <param name="nombre"> nombre del usuario</param>
        /// <param name="id"> id proporcionada por el bot </param>
        /// <param name="contraseña"> contraseña </param>
        public static int Registrar(string nombre, int id, string contraseña)
        {
            ImpresoraConsola imprimir = ImpresoraConsola.Instance();
            AlmacenamientoUsuario registro = AlmacenamientoUsuario.Instance();
            int NumeroDeJugador = registro.Registrar(nombre, id, contraseña);
            imprimir.RecibirMensajes($"Su numero de jugador es: {NumeroDeJugador}");
            return NumeroDeJugador;
        }

        /// <summary>
        /// Si el numero de usuarios pertenece a un PerfilUsuario existente
        /// en la lista de perfiles de Planificador, lo elimina de la misma.
        /// </summary>
        /// <param name="NumeroDeJugador"> numero del jugador a remover</param>
        public static string Remover(int NumeroDeJugador)
        {
            ImpresoraConsola imprimir = ImpresoraConsola.Instance();
            AlmacenamientoUsuario removedor = AlmacenamientoUsuario.Instance();
            removedor.Remover(NumeroDeJugador);
            return $"Jugador {NumeroDeJugador} removido";
        }
        
        /// <summary>
        /// Permite visualizar el perfil de un usuario.
        /// </summary>
        /// <param name="usuario"> jugador del cual se quiere ver el perfil </param>
        public static void VerPerfil(int usuario)
        {
            AlmacenamientoUsuario buscador = AlmacenamientoUsuario.Instance();
            PerfilUsuario perfilDelUsuario = buscador.ObtenerPerfil(usuario);
            Iimpresora imprimir = ImpresoraConsola.Instance();
            imprimir.ImprimirPerfilUsuario(perfilDelUsuario);
        }

        /// <summary>
        /// Si el numero de jugador ingresado tiene una partida en juego,
        /// pide mostrar el tablero del oponente.
        /// </summary>
        /// <param name="jugador"> jugador en partida </param>
        public static void VerTableroOponente(int jugador)
        {
            ImpresoraConsola imprimir = ImpresoraConsola.Instance();
            AlmacenamientoUsuario buscador = AlmacenamientoUsuario.Instance();
            char[,] tableroOponente = buscador.ObtenerTableroOponente(jugador);
            if(tableroOponente == null)
            {
                imprimir.RecibirMensajes("No se ha podido imprimir el tablero ya que no estas en partida");
            }
            else
            {
                PartidasEnJuego partidas = PartidasEnJuego.Instance();
                Partida juego = partidas.ObtenerPartida(jugador);
                if (juego != null)
                {
                    imprimir.ImprimirTablero(tableroOponente, false);
                }
            }
        }

        /// <summary>
        /// Si el numero de jugador ingresado tiene una partida en juego,
        /// pide mostrar su propio tablero.
        /// </summary>
        /// <param name="jugador"> jugador en partida </param>
        public static void VerTablero(int jugador)
        {
            ImpresoraConsola impresora = ImpresoraConsola.Instance();
            AlmacenamientoUsuario buscador = AlmacenamientoUsuario.Instance();
            char[,] tableroPropio = buscador.ObtenerTablero(jugador);
            if(tableroPropio == null)
            {
                impresora.RecibirMensajes("No se ha podido imprimir el tablero ya que no estas en partida");
            }
            else
            {
                impresora.ImprimirTablero(tableroPropio, true);
            }
        }

        /// <summary>
        /// Si el numero ingresado es 0 pide mostrar el historial general de todos las partidas jugadas,
        /// si el numero pertenece a un PerfilUsuario en la lista de perfiles de Planificador
        /// pide mostrar el HistorialPersonal de este perfil.
        /// </summary>
        public static void VerHistorial()
        {
            ImpresoraConsola imprimir = ImpresoraConsola.Instance();
            Historial historial = Historial.Instance();
            List<DatosdePartida> historialDePartidas = historial.Partidas;
            imprimir.ImprimirHistorial(historialDePartidas);
        }

        /// <summary>
        /// Si el numero ingresado es 0 pide mostrar el historial general de todos las partidas jugadas,
        /// si el numero pertenece a un PerfilUsuario en la lista de perfiles de Planificador
        /// pide mostrar el HistorialPersonal de este perfil.
        /// </summary>
        /// <param name="numerodejugador"> historial que se quiere ver</param>
        public static void VerHistorialPersonal(int numerodejugador)
        {
            ImpresoraConsola imprimir = ImpresoraConsola.Instance();
            AlmacenamientoUsuario buscador = AlmacenamientoUsuario.Instance();
            imprimir.ImprimirHistorial(buscador.ObtenerHistorialPersonal(numerodejugador));
        }

        /// <summary>
        /// Realiza una lista de PerfilUsuario ordenados por cantidad de partidas ganadas,
        /// y le pide a la impresora que la muestre.
        /// </summary>
        public static void VerRanking()
        {
            AlmacenamientoUsuario buscador = AlmacenamientoUsuario.Instance();
            List<PerfilUsuario> ranking = buscador.ObtenerRanking();
            ImpresoraConsola imprimir = ImpresoraConsola.Instance();
            imprimir.ImprimirRanking(ranking);
        }

        /// <summary>
        /// Crea una Partida, asignandole un tamaño
        /// y los dos numeros de jugador de quienes quieren comenzar una partida.
        /// </summary>
        /// <param name="tamaño"> tamaño del tablero </param>
        /// <param name="modo"> modo de juego a jugar </param>
        /// <param name="jugadores"> jugadores </param>
        public static string CrearPartida(int tamaño, int modo, int[] jugadores)
        {
            if (modo == 0)
            {
                Partida partida = new Partida(tamaño, jugadores[0], jugadores[1]);
                return "partida creada";
            }
            else if (modo == 1)
            {
                PartidaRapida partida = new PartidaRapida(tamaño, jugadores[0], jugadores[1]);
                return "partida creada";
            }
            return "no se ha podido crear la partida";
        }

        /// <summary>
        /// Empareja a dos jugadores, siendo uno de ellos el jugador que busca partida,
        /// y el otro un jugador que este esperando por una partida.
        /// </summary>
        /// <param name="modo"> modo elegido </param>
        /// <param name="jugador"> jugador que busca partida </param>
        /// <param name="tamano"> tamaño del tablero </param>
        public static string Emparejar(int modo, int jugador, int tamano)
        {
            AlmacenamientoUsuario jugadorExistente = AlmacenamientoUsuario.Instance();
            Emparejamiento emparejamiento = Emparejamiento.Instance();
            if (jugadorExistente.ObtenerPerfil(jugador) != null)
            {
                int[] jugadores = emparejamiento.EmparejarAleatorio(modo, jugador);
                if (jugadores != null)
                {
                    CrearPartida(tamano, modo, jugadores);
                    return "Emparejamiento completado";
                }
            }
            return "No se ha podido efectuar el emparejamiento";
        }

        /// <summary>
        /// Empareja a dos jugadores por sus numeros de jugador.
        /// </summary>
        /// <param name="modo"> modo de juego elegido </param>
        /// <param name="jugador1"> jugador 1 </param>
        /// <param name="jugador2"> jugador 2 </param>
        /// <param name="tamano"> tamaño del tablero </param>
        public static string EmparejarAmigos(int modo, int jugador1, int jugador2, int tamano)
        {
            Emparejamiento emparejamiento = Emparejamiento.Instance();
            AlmacenamientoUsuario jugadorExistente = AlmacenamientoUsuario.Instance();
            if (jugadorExistente.ObtenerPerfil(jugador1) != null)
            {
                if (jugadorExistente.ObtenerPerfil(jugador2) != null)
                {
                    int[] jugadores = emparejamiento.EmparejarAmigos(modo, jugador1, jugador2);
                    CrearPartida(tamano, modo, jugadores);
                    return "Emparejamiento completado";
                }
            }
            return "No se ha podido efectuar el emparejamiento";
        }

        /// <summary>
        /// Metodo para posicionar barcos
        /// </summary>
        /// <param name="inicio"> coordenada inicial del barco </param>
        /// <param name="final"> coordenada final del barco </param>
        /// <param name="jugador"> jugador que posiciona </param>
        /// <returns> mensaje a devolver </returns>
        public static string Posicionar(string inicio, string final, int jugador)
        {
            AlmacenamientoUsuario jugadorExistente = AlmacenamientoUsuario.Instance();
            if (jugadorExistente.ObtenerPerfil(jugador) == null)
            {
                return "Jugador no existente";
            }
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida juego = partidas.ObtenerPartida(jugador);
            string mensajeBarco = juego.AñadirBarco(inicio, final, jugador);
            return mensajeBarco;
        }

        /// <summary>
        /// Permite al jugador atacar
        /// </summary>
        /// <param name="coordenada"></param>
        /// <param name="atacante"></param>
        /// <returns></returns>
        public static string Atacar(string coordenada, int atacante)
        {
            AlmacenamientoUsuario jugadorExistente = AlmacenamientoUsuario.Instance();
            if (jugadorExistente.ObtenerPerfil(atacante) == null)
            {
                return "Jugador no existente";
            }
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            if (partidas.EstaElJugadorEnPartida(atacante))
            {
                Partida juego = partidas.ObtenerPartida(atacante);
                string mensajeAtaque = juego.Atacar(coordenada, atacante);
                return mensajeAtaque;
            }
            else
            {
                return "Usted no esta en partida";
            }
        }
        /// <summary>
        /// Metodo para rendirse
        /// </summary>
        /// <param name="jugador"> jugador que quiere rendirse </param>
        public static string Rendirse(int jugador)
        {
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            if (partidas.EstaElJugadorEnPartida(jugador))
            {
                Partida juego = partidas.ObtenerPartida(jugador);
                juego.Rendirse(jugador);
                return "se ha efectuado la rendicion";
            }
            else
                return "no se pudo rendir";
        }
    }
}
