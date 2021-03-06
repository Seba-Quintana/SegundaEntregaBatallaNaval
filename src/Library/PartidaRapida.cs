using System;

namespace ClassLibrary
{
    /// <summary>
    /// Tablero de modo rapido creado en caso de diseñar dicho modo.
    /// </summary>
    public class PartidaRapida : Partida
    {
        /// <summary>
        /// Atributo con el contador del segundo ataque de cada personaje.
        /// </summary>
        public int[] Segundastiradas = new int[2];
        /// <summary>
        /// En este contructor se asigna el tamaño de la matriz, se crea la misma y se asigna el dueño del Tablero.
        /// </summary>
        /// <param name="tamaño"></param>
        /// <param name="jugador1"></param>
        /// <param name="jugador2"></param>
        /// <returns></returns>
        public PartidaRapida(int tamaño ,int jugador1, int jugador2) : base (tamaño , jugador1, jugador2)
        {
            this.tableros[0] = new Tablero(tamaño,jugador1);
            this.jugadores[0]=jugador1; //Simboliza los jugadores, puede cambiarse a futuro
            this.jugadores[1]=jugador2;
            this.tableros[1] = new Tablero(tamaño,jugador2);
            this.cantidadDeBarcosParaPosicionar[0]= (tamaño * tamaño*25)/100;
            this.cantidadDeBarcosParaPosicionar[1]= (tamaño * tamaño*25)/100;
            this.tiradas[0]=0;
            this.tiradas[1]=0;
            this.Segundastiradas[0]=0;
            this.Segundastiradas[1]=0;
            PartidasEnJuego partida = PartidasEnJuego.Instance();
            partida.AlmacenarPartida(this);
        }
        /// <summary>
        /// Metodo encargado de llamar al metodo Atacar de Logica de Tablero se cambia ya que se debe controlar
        /// que un jugador ejecute su segundo tiro antes de que ataque su oponente.
        /// </summary>
        /// <param name="objetivo"></param>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public override string Atacar(string objetivo, int jugador)
        {
            int[] LugarDeAtaque = TraductorDeCoordenadas.Traducir(objetivo);

            if (LugarDeAtaque==null)
            {
                return "La coordenada enviada fue invalida";
            }
            if (!this.posicionamientoTerminado[0] || !this.posicionamientoTerminado[1])
            {
                return "Estamos en etapa de posicionamiento, si no le quedan barcos para posicionar, entonces espere a que termine de posicionar su oponente";
            }
            if (this.jugadores[0] != jugador || this.jugadores[1] != jugador) //no uso jugadores.Contains(jugador) ya que por alguna razon no deja utilizar el metodo con un atributo array heredado
            { 
                return "Ataque no ejecutado ya que quien ataca no es uno de los jugadores de la partida";
                }
            if (LugarDeAtaque[0] >= this.tableros[0].Tamaño || LugarDeAtaque[1] >= this.tableros[0].Tamaño)
            {
                return "Las coordenadas enviadas son erroneas";
                }

            int fila = LugarDeAtaque[0];
            int columna = LugarDeAtaque[1];

            if (jugador == this.jugadores[0])
            {
                if (this.tiradas[0]==this.tiradas[1] && this.Segundastiradas[0] == this.Segundastiradas[1])
                {
                    
                    Tablero tablerobjetivo = this.tableros[1];
                    string respuesta = respuestaDeAtaque(tablerobjetivo, fila, columna);
                    LogicaDeTablero.Atacar(tablerobjetivo,fila,columna);
                    this.tiradas[0]+=1;
                    
                    if (tablerobjetivo.terminado)
                    {
                        this.PartidaTerminada=true;
                        respuesta += $"\nFelicitaciones has ganado la partida";
                        LogicaDeTablero.PartidaFinalizada(this.tableros[0]);
                        this.Finalizar();
                    }
                    
                    return respuesta;
                }
                else if (this.Segundastiradas[0]==this.Segundastiradas[1])
                {
                    Tablero tablerobjetivo = this.tableros[1];
                    string respuesta = respuestaDeAtaque(tablerobjetivo, fila, columna);
                    LogicaDeTablero.Atacar(tablerobjetivo,fila,columna);
                    this.Segundastiradas[0]+=1;
                    
                    if (tablerobjetivo.terminado)
                    {
                        this.PartidaTerminada=true;
                        respuesta += $"\nFelicitaciones has ganado la partida";
                        LogicaDeTablero.PartidaFinalizada(this.tableros[0]);
                        this.Finalizar();
                    }
                    
                    return respuesta;
                }
                else
                {
                    return "Debe esperar a que el otro jugador lo ataque.";
                }
                  
            }
            else if (jugador == jugadores[1])
            {
                if (this.tiradas[0] > this.tiradas[1] && this.Segundastiradas[0] > this.Segundastiradas[1])
                {
                    
                    Tablero tablerobjetivo = tableros[0];
                    string respuesta = respuestaDeAtaque(tablerobjetivo, fila, columna);
                    LogicaDeTablero.Atacar(tablerobjetivo,fila,columna);
                    tiradas[1]+=1;
                    if (tablerobjetivo.terminado)
                    {
                        this.PartidaTerminada=true;
                        respuesta += $"\nFelicitaciones has ganado la partida";
                        LogicaDeTablero.PartidaFinalizada(tableros[1]);
                        this.Finalizar();
                    }
                    return respuesta;

                }
                else if (this.Segundastiradas[0] > this.Segundastiradas[1])
                {
                    Tablero tablerobjetivo = this.tableros[0];
                    string respuesta = respuestaDeAtaque(tablerobjetivo, fila, columna);
                    LogicaDeTablero.Atacar(tablerobjetivo,fila,columna);
                    this.Segundastiradas[1]+=1;
                    if (tablerobjetivo.terminado)
                    {
                        this.PartidaTerminada=true;
                        respuesta += $"\nFelicitaciones has ganado la partida";
                        LogicaDeTablero.PartidaFinalizada(this.tableros[1]);
                        this.Finalizar();
                    }
                    return respuesta;
                }
                else
                {
                    return "Debe esperar a que el otro jugador lo ataque.";
                }
                  
            }
            else
            {
            return "Ataque no ejecutado ya que quien ataca no es uno de los jugadores de la partida";
            }

        }
       
        
    }
}
