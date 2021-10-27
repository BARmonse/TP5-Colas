using Colas.Servidores;
using Colas.Soporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colas
{
    class Linea
    {
        public string LLEGADA_PEDIDO = "llegada de pedido";
        public string FIN_ATENCION1 = "fin de atencion servidor 1";
        public string FIN_ATENCION2 = "fin de atencion servidor 2";
        public string FIN_ATENCION3 = "fin de atencion servidor 3";
        public string FIN_ATENCION4 = "fin de atencion servidor 4";
        public string FIN_ATENCION5 = "fin de atencion servidor 5";
        public string CONTEO = "conteo";

        public GeneradorLenguaje aleatorios;
        public Truncador truncador;
        public string evento { get; set; }
        public double reloj { get; set; }
        public double llegadaPedido { get; set; }
        public double cantidadProductos { get; set; }

        public string[] EVENTOS = new string[] {"fin de atencion servidor 1", "fin de atencion servidor 2", "fin de atencion servidor 3",
            "fin de atencion servidor 4", "fin de atencion servidor 5" };

        public ServidorActividad servidorActividad1 { get; set; }
        public ServidorActividad servidorActividad2 { get; set; }
        public ServidorActividad servidorActividad3 { get; set; }
        public ServidorActividad servidorActividad4 { get; set; }
        public ServidorActividad servidorActividad5 { get; set; }
        public Linea lineaAnterior { get; set; }
        public GestorColas colas;
        public List<Producto> productos;
        public Queue<Producto> productosLibres;

        public double colaMaximaServidor1 = 0;
        public double colaMaximaServidor2 = 0;
        public double colaMaximaServidor3 = 0;
        public double colaMaximaServidor4 = 0;
        public double colaMaximaServidor5 = 0;
        public double colaEncastre;

        public double contadorOcupadoServidor1 = 0;
        public double contadorOcupadoServidor2 = 0;
        public double contadorOcupadoServidor3 = 0;
        public double contadorOcupadoServidor4 = 0;
        public double contadorOcupadoServidor5 = 0;

        public double porcentajeOcupacionServidor1;
        public double porcentajeOcupacionServidor2;
        public double porcentajeOcupacionServidor3;
        public double porcentajeOcupacionServidor4;
        public double porcentajeOcupacionServidor5;

        public double ensamblesHora = 0;
        public double probabilidad3Ensambles;
        public double contador3EnsamblesHora = 0;
        public double horasTranscurridas = 0;
        public double promedioEnsamblesHora = 0;

        public double cliente1;
        public double cliente2;
        public double cliente3;
        public double cliente4;
        public double cliente5;
        public double promedioProductosCola = 0;
        public double promedioProductosSistema = 0;

        public double acumuladorTiemposBloqueo;
        public double acumuladorTiemposOcupacion;
        public double proporcionBloqueoOcupacion;

        public double acumuladorEsperaServidor1;
        public double acumuladorEsperaServidor2;
        public double acumuladorEsperaServidor3;
        public double acumuladorEsperaServidor4;
        public double acumuladorEsperaServidor5;

        public double promedioDuracionEnsamble;

        public int idFila;
        public int desde;
        public int hasta;
        public List<ServidorActividad> listaActividad;

        public Linea()
        {
            this.llegadaPedido = 0;
            this.cantidadProductos = 0;
            this.truncador = new Truncador(2);
            this.aleatorios = new GeneradorLenguaje(truncador);
            this.servidorActividad1 = new ServidorActividad();
            this.servidorActividad2 = new ServidorActividad();
            this.servidorActividad3 = new ServidorActividad();
            this.servidorActividad4 = new ServidorActividad();
            this.servidorActividad5 = new ServidorActividad();
            this.productos = new List<Producto>();
            this.productosLibres = new Queue<Producto>();
            listaActividad = new List<ServidorActividad>();
            listaActividad.Add(servidorActividad1);
            listaActividad.Add(servidorActividad2);
            listaActividad.Add(servidorActividad3);
            listaActividad.Add(servidorActividad4);
            listaActividad.Add(servidorActividad5);
        }
        public Linea(Linea lineaAnterior,GestorColas colas,int desde, int hasta,int idFila)
        {
            this.lineaAnterior = lineaAnterior;
            this.truncador = new Truncador(4);
            this.aleatorios = new GeneradorLenguaje(truncador);
            this.productos = lineaAnterior.productos;
            this.cantidadProductos = lineaAnterior.cantidadProductos;
            this.servidorActividad1 = lineaAnterior.servidorActividad1;
            this.servidorActividad2 = lineaAnterior.servidorActividad2;
            this.servidorActividad3 = lineaAnterior.servidorActividad3;
            this.servidorActividad4 = lineaAnterior.servidorActividad4;
            this.servidorActividad5 = lineaAnterior.servidorActividad5;
            this.productosLibres = lineaAnterior.productosLibres;
            this.colas = colas;
            this.desde = desde;
            this.hasta = hasta;
            this.idFila = idFila;
            this.listaActividad = lineaAnterior.listaActividad;
            this.colaMaximaServidor1 = lineaAnterior.colaMaximaServidor1;
            this.colaMaximaServidor2 = lineaAnterior.colaMaximaServidor2;
            this.colaMaximaServidor3 = lineaAnterior.colaMaximaServidor3;
            this.colaMaximaServidor4 = lineaAnterior.colaMaximaServidor4;
            this.colaMaximaServidor5 = lineaAnterior.colaMaximaServidor5;
            this.colaEncastre = lineaAnterior.colaEncastre;
            this.contadorOcupadoServidor1 = lineaAnterior.contadorOcupadoServidor1;
            this.contadorOcupadoServidor2 = lineaAnterior.contadorOcupadoServidor2;
            this.contadorOcupadoServidor3 = lineaAnterior.contadorOcupadoServidor3;
            this.contadorOcupadoServidor4 = lineaAnterior.contadorOcupadoServidor4;
            this.contadorOcupadoServidor5 = lineaAnterior.contadorOcupadoServidor5;
            this.ensamblesHora = lineaAnterior.ensamblesHora;
            this.probabilidad3Ensambles = lineaAnterior.probabilidad3Ensambles;
            this.contador3EnsamblesHora = lineaAnterior.contador3EnsamblesHora;
            this.horasTranscurridas = lineaAnterior.horasTranscurridas;
            this.promedioEnsamblesHora = lineaAnterior.promedioEnsamblesHora;
            this.promedioProductosCola = lineaAnterior.promedioProductosCola;
            this.promedioProductosSistema = lineaAnterior.promedioProductosSistema;
            this.acumuladorTiemposBloqueo = lineaAnterior.acumuladorTiemposBloqueo;
            this.acumuladorTiemposOcupacion = lineaAnterior.acumuladorTiemposOcupacion;
            this.proporcionBloqueoOcupacion = lineaAnterior.proporcionBloqueoOcupacion;
            this.promedioDuracionEnsamble = lineaAnterior.promedioDuracionEnsamble;
            this.acumuladorEsperaServidor1 = lineaAnterior.acumuladorEsperaServidor1;
            this.acumuladorEsperaServidor2 = lineaAnterior.acumuladorEsperaServidor2;
            this.acumuladorEsperaServidor3 = lineaAnterior.acumuladorEsperaServidor3;
            this.acumuladorEsperaServidor4 = lineaAnterior.acumuladorEsperaServidor4;
            this.acumuladorEsperaServidor5 = lineaAnterior.acumuladorEsperaServidor5;
        }
        private Producto buscarProductoLibre()
        {
            Producto libre;
            Boolean correcto = productosLibres.TryDequeue(out libre);
            if (correcto)
            {
                return libre;
            }

            Producto res = new Producto();
            this.productos.Add(res);
            if (idFila <= hasta)
            {
                colas.agregarColumna();
            }

            return res;
        }
        public void calcularEvento()
        {
            this.reloj = lineaAnterior.llegadaPedido;
            this.evento = LLEGADA_PEDIDO;

            for (int i = 0; i < listaActividad.Count; i++)
            {
                if (listaActividad[i].finAtencion > 0 && listaActividad[i].finAtencion < reloj)
                {
                    reloj = listaActividad[i].finAtencion;
                    evento = EVENTOS[i];

                }
            }
            if (idFila % 60 == 0)
            {
                reloj = lineaAnterior.reloj;
                this.evento = CONTEO;
            }
        }

        public void calcularSiguienteLlegada()
        {
            if (this.evento.Equals(LLEGADA_PEDIDO))
            {
                this.llegadaPedido = reloj + (-20 * Math.Log(1-aleatorios.siguienteAleatorio()));
                return;
            }
            this.llegadaPedido = lineaAnterior.llegadaPedido;
        }
        public void calcularFinAtencion1(double a, double b)
        {
            calcularFinAtencion1EventoLlegadaCliente(servidorActividad1,a, b);
            calcularFinAtencion1EventoFinAtencion1(servidorActividad1,a, b);
            calcularFinAtencion1EventoFinAtencion2();
            calcularFinAtencion1EventoFinAtencion3();
            calcularFinAtencion1EventoFinAtencion4();
            calcularFinAtencion1EventoFinAtencion5();
            calcularFinAtencion1EventoConteo();
        }
        public void calcularFinAtencion2(double a, double b)
        {
            calcularFinAtencion2EventoLlegadaCliente(servidorActividad2, a, b);
            calcularFinAtencion2EventoFinAtencion1();
            calcularFinAtencion2EventoFinAtencion2(servidorActividad2,a,b);
            calcularFinAtencion2EventoFinAtencion3();
            calcularFinAtencion2EventoFinAtencion4();
            calcularFinAtencion2EventoFinAtencion5();
            calcularFinAtencion2EventoConteo();
        }
        public void calcularFinAtencion3(double media)
        {
            calcularFinAtencion3EventoLlegadaCliente(servidorActividad3,media);
            calcularFinAtencion3EventoFinAtencion1();
            calcularFinAtencion3EventoFinAtencion2();
            calcularFinAtencion3EventoFinAtencion3(servidorActividad3,media);
            calcularFinAtencion3EventoFinAtencion4();
            calcularFinAtencion3EventoFinAtencion5();
            calcularFinAtencion3EventoConteo();
        }
        public void calcularFinAtencion4(double a,double b)
        {
            calcularFinAtencion4EventoLlegadaCliente();
            calcularFinAtencion4EventoFinAtencion1(servidorActividad4,a,b);
            calcularFinAtencion4EventoFinAtencion2();
            calcularFinAtencion4EventoFinAtencion3();
            calcularFinAtencion4EventoFinAtencion4(servidorActividad4,a,b);
            calcularFinAtencion4EventoFinAtencion5();
            calcularFinAtencion4EventoConteo();
        }

        public void calcularFinAtencion5(double media)
        {
            calcularFinAtencion5EventoLlegadaCliente();
            calcularFinAtencion5EventoFinAtencion1();
            calcularFinAtencion5EventoFinAtencion2(servidorActividad5,media);
            calcularFinAtencion5EventoFinAtencion3();
            calcularFinAtencion5EventoFinAtencion4(servidorActividad5,media);
            calcularFinAtencion5EventoFinAtencion5(servidorActividad5,media);
            calcularFinAtencion5EventoConteo();
        }

        private void calcularFinAtencion1EventoLlegadaCliente(ServidorActividad servidorActividad, double a, double b)
        {
            if (this.evento.Equals(LLEGADA_PEDIDO))
            {
                Producto productoActual = buscarProductoLibre();
                if (lineaAnterior.servidorActividad1.estaOcupado())
                {
                    esperarAtencionServidor1(servidorActividad, productoActual);
                }
                else
                {
                    atenderServidor1(servidorActividad, productoActual, a, b);
                }
            }
        }
        private void calcularFinAtencion1EventoFinAtencion1(ServidorActividad servidorActividad, double a, double b)
        {
            if (this.evento.Equals(FIN_ATENCION1))
            {
                Producto productoProcesado = servidorActividad.getProductoActual();
                servidorActividad.agregarAColaDeposito(productoProcesado);
                productoProcesado.colocarDeposito1();
                productosLibres.Enqueue(productoProcesado);//Recién agregado

                if (lineaAnterior.tieneColaServidor(servidorActividad))
                {
                    Producto productoActual = servidorActividad.siguienteProducto();
                    atenderServidor1(servidorActividad, productoActual, a, b);
                }
                else
                {
                    servidorActividad.liberar();
                }
            }
        }
        private void calcularFinAtencion2EventoLlegadaCliente(ServidorActividad servidorActividad, double a, double b)
        {
            if (this.evento.Equals(LLEGADA_PEDIDO))
            {
                Producto productoActual = buscarProductoLibre();
                if (lineaAnterior.servidorActividad2.estaOcupado())
                {
                    esperarAtencionServidor2(servidorActividad, productoActual);
                }
                else
                {
                    atenderServidor2(servidorActividad, productoActual, a, b);
                }
            }
        }
        private void calcularFinAtencion2EventoFinAtencion2(ServidorActividad servidorActividad, double a, double b)
        {
            if (this.evento.Equals(FIN_ATENCION2))
            {
                Producto productoProcesado = servidorActividad.getProductoActual();
                servidorActividad.agregarAColaDeposito(productoProcesado);
                productoProcesado.colocarDeposito2();

                if (lineaAnterior.tieneColaServidor(servidorActividad))
                {
                    Producto productoActual = servidorActividad.siguienteProducto();
                    atenderServidor2(servidorActividad, productoActual, a, b);
                }
                else
                {
                    servidorActividad.liberar();
                }
            }
        }
        private void calcularFinAtencion3EventoLlegadaCliente(ServidorActividad servidorActividad ,double media)
        {
            if (this.evento.Equals(LLEGADA_PEDIDO))
            {
                Producto productoActual = buscarProductoLibre();
                if (lineaAnterior.servidorActividad3.estaOcupado())
                {
                    esperarAtencionServidor3(servidorActividad, productoActual);
                }
                else
                {
                    atenderServidor3(servidorActividad,productoActual, media);
                }
            }
        }
        private void calcularFinAtencion3EventoFinAtencion3(ServidorActividad servidorActividad, double media)
        {
            if (this.evento.Equals(FIN_ATENCION3))
            {
                Producto productoProcesado = servidorActividad.getProductoActual();
                servidorActividad.agregarAColaDeposito(productoProcesado);
                productoProcesado.colocarDeposito3();

                if (lineaAnterior.tieneColaServidor(servidorActividad))
                {
                    Producto productoActual = servidorActividad.siguienteProducto();
                    atenderServidor3(servidorActividad3, productoActual,media);
                }
                else
                {
                    servidorActividad.liberar();
                }
                if (servidorActividad5.tieneColaDeposito())
                {
                    Producto productoDeposito5 = servidorActividad5.siguienteProductoDeposito();
                    Producto productoDeposito3 = servidorActividad.siguienteProductoDeposito();
                    productoDeposito5.limpiar();
                    productoDeposito3.limpiar();
                    productosLibres.Enqueue(productoDeposito3); //Reutilización de columnas de objetos temporales
                    productosLibres.Enqueue(productoDeposito5); //Reutilización de columnas de objetos temporales
                    cantidadProductos += 1;
                    ensamblesHora += 1;
                }
            }
        }

        private void calcularFinAtencion4EventoFinAtencion1(ServidorActividad servidorActividad, double a, double b)
        {
            if (this.evento.Equals(FIN_ATENCION1))
            {
                if (servidorActividad1.tieneColaDeposito())
                {
                    Producto productoActual = servidorActividad1.siguienteProductoDeposito();
                    if (lineaAnterior.servidorActividad4.estaOcupado())
                    {
                        esperarAtencionServidor4(servidorActividad, productoActual);
                    }
                    else
                    {
                        atenderServidor4(servidorActividad, productoActual, a, b);
                    }
                }
               
            }
        }
        private void calcularFinAtencion4EventoFinAtencion4(ServidorActividad servidorActividad, double a, double b)
        {
            if (this.evento.Equals(FIN_ATENCION4))
            {
                Producto productoProcesado = servidorActividad.getProductoActual();
                servidorActividad.agregarAColaDeposito(productoProcesado);
                productoProcesado.colocarDeposito4();

                if (lineaAnterior.tieneColaServidor(servidorActividad))
                {
                    Producto productoActual = servidorActividad.siguienteProducto();
                    atenderServidor4(servidorActividad4, productoActual, a, b);
                }
                else
                {
                    servidorActividad.liberar();
                }
            }
        }
        private void calcularFinAtencion5EventoFinAtencion2(ServidorActividad servidorActividad, double media)
        {
            if (this.evento.Equals(FIN_ATENCION2))
            {
                if ((servidorActividad.estaBloqueado() || servidorActividad.estaLibre()) && servidorActividad4.tieneColaDeposito())
                {
                    Producto productoProcesado = servidorActividad4.siguienteProductoDeposito();
                    Producto productoDeposito2 = servidorActividad2.siguienteProductoDeposito();
                    productoDeposito2.limpiar();
                    productosLibres.Enqueue(productoDeposito2);//Reutilización de columnas de objetos temporales
                    productosLibres.Enqueue(productoProcesado);//Recién agregado
                    atenderServidor5(servidorActividad, productoProcesado, media);
                    return;
                }

                if ((servidorActividad.estaBloqueado() || servidorActividad.estaLibre()) && !servidorActividad4.tieneColaDeposito())
                {
                    servidorActividad.bloquear();
                    return;
                }

                if (servidorActividad.estaOcupado() && servidorActividad4.tieneColaDeposito())
                {
                    Producto productoActual = servidorActividad4.siguienteProductoDeposito();
                    Producto productoDeposito2 = servidorActividad2.siguienteProductoDeposito();
                    productoDeposito2.limpiar();
                    productosLibres.Enqueue(productoDeposito2);//Reutilización de columnas de objetos temporales
                    productosLibres.Enqueue(productoActual);//Recién agregado
                    esperarAtencionServidor5(servidorActividad,productoActual);
                    return;
                }
                if(servidorActividad.estaOcupado() && !servidorActividad4.tieneColaDeposito())
                {
                    servidorActividad.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad));
                }
            }
        }
        private void calcularFinAtencion5EventoFinAtencion4(ServidorActividad servidorActividad,double media)
        {
            if (this.evento.Equals(FIN_ATENCION4))
            {
                if ((servidorActividad.estaBloqueado() || servidorActividad.estaLibre()) && servidorActividad2.tieneColaDeposito())
                {
                    Producto productoActual = servidorActividad2.siguienteProductoDeposito();
                    Producto productoDeposito4 = servidorActividad4.siguienteProductoDeposito();
                    productoDeposito4.limpiar();
                    productosLibres.Enqueue(productoDeposito4);// Reutilización de columnas de objetos temporales
                    productosLibres.Enqueue(productoActual);//Recién agregado
                    atenderServidor5(servidorActividad, productoActual, media);
                    return;
                }

                if ((servidorActividad.estaBloqueado() || servidorActividad.estaLibre()) && !servidorActividad2.tieneColaDeposito())
                {
                    servidorActividad.bloquear();
                    return;
                }

                if (servidorActividad.estaOcupado() && servidorActividad2.tieneColaDeposito())
                {
                    Producto productoActual = servidorActividad4.siguienteProductoDeposito();
                    Producto productoDeposito2 = servidorActividad2.siguienteProductoDeposito();
                    productoDeposito2.limpiar();
                    productosLibres.Enqueue(productoDeposito2);// Reutilización de columnas de objetos temporales
                    productosLibres.Enqueue(productoActual);// Recién agregado
                    esperarAtencionServidor5(servidorActividad, productoActual);
                    return;
                }
                if (servidorActividad.estaOcupado() && !servidorActividad2.tieneColaDeposito())
                {
                    servidorActividad.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad));
                }
            }
        }

        private void calcularFinAtencion5EventoFinAtencion3()
        {
            if (this.evento.Equals(FIN_ATENCION3) && lineaAnterior.tieneFinAtencion(servidorActividad5))
            {
                servidorActividad5.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad5));
            }
        }


        private void calcularFinAtencion5EventoFinAtencion5(ServidorActividad servidorActividad,double media)
        {
            if (this.evento.Equals(FIN_ATENCION5))
            {
                Producto productoProcesado = servidorActividad.getProductoActual();
                servidorActividad.agregarAColaDeposito(productoProcesado);
                productoProcesado.colocarDeposito5();

                if (lineaAnterior.tieneColaServidor(servidorActividad))
                {
                    Producto productoActual = servidorActividad.siguienteProducto();
                    atenderServidor5(servidorActividad, productoActual, media);
                }
                else
                {
                    servidorActividad.liberar();
                }
                if (servidorActividad3.tieneColaDeposito())
                {
                    Producto productoDeposito3 = servidorActividad3.siguienteProductoDeposito();
                    Producto productoDeposito5 = servidorActividad.siguienteProductoDeposito();
                    productoDeposito5.limpiar();
                    productoDeposito3.limpiar();
                    productosLibres.Enqueue(productoDeposito3); //Reutilización de columnas de objetos temporales
                    productosLibres.Enqueue(productoDeposito5); //Reutilización de columnas de objetos temporales
                    cantidadProductos += 1;
                    ensamblesHora += 1;
                }
            }
        }

        
        private void esperarAtencionServidor1(ServidorActividad servidorActividad, Producto productoActual)
        {
            servidorActividad.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad1));
            servidorActividad.agregarACola(productoActual);
            productoActual.esperarAtencionServidor1();
            productoActual.horaLlegadaServidor = this.reloj;
        }
        private void esperarAtencionServidor2(ServidorActividad servidorActividad, Producto productoActual)
        {
            servidorActividad.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad2));
            servidorActividad.agregarACola(productoActual);
            productoActual.esperarAtencionServidor2();
            productoActual.horaLlegadaServidor = this.reloj;
        }
        private void esperarAtencionServidor3(ServidorActividad servidorActividad, Producto productoActual)
        {
            servidorActividad.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad3));
            servidorActividad.agregarACola(productoActual);
            productoActual.esperarAtencionServidor3();
            productoActual.horaLlegadaServidor = this.reloj;
        }
        private void esperarAtencionServidor4(ServidorActividad servidorActividad,Producto productoActual)
        {
            servidorActividad.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad4));
            servidorActividad.agregarACola(productoActual);
            productoActual.esperarAtencionServidor4();
            productoActual.horaLlegadaServidor = this.reloj;
        }
        private void esperarAtencionServidor5(ServidorActividad servidorActividad,Producto productoActual)
        {
            servidorActividad.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad5));
            servidorActividad.agregarACola(productoActual);
            productoActual.esperarAtencionServidor5();
            productoActual.horaLlegadaServidor = this.reloj;
        }
        private void atenderServidor1(ServidorActividad servidorActividad, Producto productoActual, double a, double b)
        {
            productoActual.atenderServidor1();
            servidorActividad.agregarFinAtencion(this.reloj + a + (b - a) * aleatorios.siguienteAleatorio());
            servidorActividad.productoActual = productoActual;
            acumuladorEsperaServidor1 += this.reloj - productoActual.horaLlegadaServidor;
        }
        private void atenderServidor2(ServidorActividad servidorActividad,Producto productoActual, double a, double b)
        {
            productoActual.atenderServidor2();
            servidorActividad.agregarFinAtencion(this.reloj + a + (b - a) * aleatorios.siguienteAleatorio());
            servidorActividad.productoActual = productoActual;
            acumuladorEsperaServidor2 +=  this.reloj - productoActual.horaLlegadaServidor;
        }
        
        private void atenderServidor3(ServidorActividad servidorActividad,Producto productoActual,double media)
        {
            productoActual.atenderServidor3();
            servidorActividad.agregarFinAtencion(this.reloj + (-media * Math.Log(1 - aleatorios.siguienteAleatorio())));
            servidorActividad.productoActual = productoActual;
            acumuladorEsperaServidor3 += this.reloj - productoActual.horaLlegadaServidor;
        }
        private void atenderServidor4(ServidorActividad servidorActividad,Producto productoActual,double a,double b)
        {
            productoActual.atenderServidor4();
            servidorActividad.agregarFinAtencion(this.reloj + a + (b - a) * aleatorios.siguienteAleatorio());
            servidorActividad.productoActual = productoActual;
            acumuladorEsperaServidor4 += this.reloj - productoActual.horaLlegadaServidor;
        }
        private void atenderServidor5(ServidorActividad servidorActividad,Producto productoActual,double media)
        {
            productoActual.atenderServidor5();
            servidorActividad.agregarFinAtencion(this.reloj + (-media * Math.Log(1 - aleatorios.siguienteAleatorio())));
            servidorActividad.productoActual = productoActual;
            acumuladorEsperaServidor5 += this.reloj - productoActual.horaLlegadaServidor;
        }
        
        private Boolean tieneFinAtencion(ServidorActividad servidorActividad)
        {
            return servidorActividad.tieneFinAtencion();
        }

        private void calcularFinAtencion1EventoFinAtencion2()
        {
            if (this.evento.Equals(FIN_ATENCION2) && lineaAnterior.tieneFinAtencion(servidorActividad1))
            {
                servidorActividad1.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad1));
            }
        }
        private void calcularFinAtencion1EventoFinAtencion3()
        {
            if (this.evento.Equals(FIN_ATENCION3) && lineaAnterior.tieneFinAtencion(servidorActividad1))
            {
                servidorActividad1.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad1));
            }
        }
        private void calcularFinAtencion1EventoFinAtencion4()
        {
            if (this.evento.Equals(FIN_ATENCION4) && lineaAnterior.tieneFinAtencion(servidorActividad1))
            {
                servidorActividad1.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad1));
            }
        }
        private void calcularFinAtencion1EventoFinAtencion5()
        {
            if (this.evento.Equals(FIN_ATENCION5) && lineaAnterior.tieneFinAtencion(servidorActividad1))
            {
                servidorActividad1.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad1));
            }
        }
        private void calcularFinAtencion1EventoConteo()
        {
            if (this.evento.Equals(CONTEO) && lineaAnterior.tieneFinAtencion(servidorActividad1))
            {
                servidorActividad1.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad1));
            }
        }
        private void calcularFinAtencion2EventoFinAtencion1()
        {
            if (this.evento.Equals(FIN_ATENCION1) && lineaAnterior.tieneFinAtencion(servidorActividad2))
            {
                servidorActividad2.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad2));
            }
        }
        private void calcularFinAtencion2EventoFinAtencion3()
        {
            if (this.evento.Equals(FIN_ATENCION3) && lineaAnterior.tieneFinAtencion(servidorActividad2))
            {
                servidorActividad2.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad2));
            }
        }
        private void calcularFinAtencion2EventoFinAtencion4()
        {
            if (this.evento.Equals(FIN_ATENCION4) && lineaAnterior.tieneFinAtencion(servidorActividad2))
            {
                servidorActividad2.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad2));
            }
        }
        private void calcularFinAtencion2EventoFinAtencion5()
        {
            if (this.evento.Equals(FIN_ATENCION5) && lineaAnterior.tieneFinAtencion(servidorActividad2))
            {
                servidorActividad2.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad2));
            }
        }
        private void calcularFinAtencion2EventoConteo()
        {
            if (this.evento.Equals(CONTEO) && lineaAnterior.tieneFinAtencion(servidorActividad2))
            {
                servidorActividad2.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad2));
            }
        }
        private void calcularFinAtencion3EventoFinAtencion1()
        {
            if (this.evento.Equals(FIN_ATENCION1) && lineaAnterior.tieneFinAtencion(servidorActividad3))
            {
                servidorActividad3.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad3));
            }
        }
        private void calcularFinAtencion3EventoFinAtencion2()
        {
            if (this.evento.Equals(FIN_ATENCION2) && lineaAnterior.tieneFinAtencion(servidorActividad3))
            {
                servidorActividad3.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad3));
            }
        }
        private void calcularFinAtencion3EventoFinAtencion4()
        {
            if (this.evento.Equals(FIN_ATENCION4) && lineaAnterior.tieneFinAtencion(servidorActividad3))
            {
                servidorActividad3.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad3));
            }
        }
        private void calcularFinAtencion3EventoFinAtencion5()
        {
            if (this.evento.Equals(FIN_ATENCION5) && lineaAnterior.tieneFinAtencion(servidorActividad3))
            {
                servidorActividad3.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad3));
            }
        }
        private void calcularFinAtencion3EventoConteo()
        {
            if (this.evento.Equals(CONTEO) && lineaAnterior.tieneFinAtencion(servidorActividad3))
            {
                servidorActividad3.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad3));
            }
        }

        private void calcularFinAtencion4EventoLlegadaCliente()
        {
            if (this.evento.Equals(LLEGADA_PEDIDO) && lineaAnterior.tieneFinAtencion(servidorActividad4))
            {
                servidorActividad4.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad4));
            }
        }
        private void calcularFinAtencion4EventoFinAtencion2()
        {
            if (this.evento.Equals(FIN_ATENCION2) && lineaAnterior.tieneFinAtencion(servidorActividad4))
            {
                servidorActividad4.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad4));
            }
        }
        private void calcularFinAtencion4EventoFinAtencion3()
        {
            if (this.evento.Equals(FIN_ATENCION3) && lineaAnterior.tieneFinAtencion(servidorActividad4))
            {
                servidorActividad4.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad4));
            }
        }
        private void calcularFinAtencion4EventoFinAtencion5()
        {
            if (this.evento.Equals(FIN_ATENCION5) && lineaAnterior.tieneFinAtencion(servidorActividad4))
            {
                servidorActividad4.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad4));
            }
        }
        private void calcularFinAtencion4EventoConteo()
        {
            if (this.evento.Equals(CONTEO) && lineaAnterior.tieneFinAtencion(servidorActividad4))
            {
                servidorActividad4.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad4));
            }
        }
        private void calcularFinAtencion5EventoLlegadaCliente()
        {
            if (this.evento.Equals(LLEGADA_PEDIDO) && lineaAnterior.tieneFinAtencion(servidorActividad5))
            {
                servidorActividad5.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad5));
            }
        }
        private void calcularFinAtencion5EventoFinAtencion1()
        {
            if (this.evento.Equals(LLEGADA_PEDIDO) && lineaAnterior.tieneFinAtencion(servidorActividad5))
            {
                servidorActividad5.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad5));
            }
        }
        private void calcularFinAtencion5EventoConteo()
        {
            if(this.evento.Equals(CONTEO) && lineaAnterior.tieneFinAtencion(servidorActividad5))
            {
                servidorActividad5.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad5));
            }
        }

        private Boolean tieneColaServidor(ServidorActividad servidorActividad)
        {
            return servidorActividad.tieneCola();
        }
        private double obtenerFinAtencionServidor(ServidorActividad servidorActividad)
        {
            return servidorActividad.finAtencion;
        }

        public void calcularColasMaximas()
        {
            colaMaximaServidor1 = Math.Max(servidorActividad1.cola.Count, colaMaximaServidor1);
            colaMaximaServidor2 = Math.Max(servidorActividad2.cola.Count, colaMaximaServidor2);
            colaMaximaServidor3 = Math.Max(servidorActividad3.cola.Count, colaMaximaServidor3);
            colaMaximaServidor4 = Math.Max(servidorActividad4.cola.Count, colaMaximaServidor4);
            colaMaximaServidor5 = Math.Max(servidorActividad5.cola.Count, colaMaximaServidor5);
            colaEncastre = Math.Max(servidorActividad3.colaDeposito.Count + servidorActividad5.colaDeposito.Count, colaEncastre);
        }
        public void calcularPorcentajeOcupacionServidores()
        {
            calcularPorcentajeOcupacionServidor1();
            calcularPorcentajeOcupacionServidor2();
            calcularPorcentajeOcupacionServidor3();
            calcularPorcentajeOcupacionServidor4();
            calcularPorcentajeOcupacionServidor5();

            porcentajeOcupacionServidor1 = contadorOcupadoServidor1 * 100 / idFila;
            porcentajeOcupacionServidor2 = contadorOcupadoServidor2 * 100 / idFila;
            porcentajeOcupacionServidor3 = contadorOcupadoServidor3 * 100 / idFila;
            porcentajeOcupacionServidor4 = contadorOcupadoServidor4 * 100 / idFila;
            porcentajeOcupacionServidor5 = contadorOcupadoServidor5 * 100 / idFila;
        }

        private void calcularPorcentajeOcupacionServidor1()
        {
            if (servidorActividad1.estaOcupado())
            {
                contadorOcupadoServidor1 += 1;
            }
        }
        private void calcularPorcentajeOcupacionServidor2()
        {
            if (servidorActividad2.estaOcupado())
            {
                contadorOcupadoServidor2 += 1;
            }
        }
        private void calcularPorcentajeOcupacionServidor3()
        {
            if (servidorActividad3.estaOcupado())
            {
                contadorOcupadoServidor3 += 1;
            }
        }
        private void calcularPorcentajeOcupacionServidor4()
        {
            if (servidorActividad4.estaOcupado())
            {
                contadorOcupadoServidor4 += 1;
            }
        }
        private void calcularPorcentajeOcupacionServidor5()
        {
            if (servidorActividad5.estaOcupado())
            {
                contadorOcupadoServidor5 += 1;
            }
        }
        public void calcularEnsamblesPorHora()
        {
            if (this.evento.Equals(CONTEO))
            {
                if (this.ensamblesHora >= 3)
                {
                    contador3EnsamblesHora += 1;
                }
                horasTranscurridas += 1;
                probabilidad3Ensambles = contador3EnsamblesHora / horasTranscurridas;

                promedioEnsamblesHora = (lineaAnterior.promedioEnsamblesHora + ensamblesHora) / horasTranscurridas;
                ensamblesHora = 0;
                

                
            }
        }
        public void calcularPromedioProductosCola()
        {
            promedioProductosCola = (lineaAnterior.promedioProductosCola + 
                servidorActividad1.cola.Count + servidorActividad2.cola.Count + servidorActividad3.cola.Count
                + servidorActividad4.cola.Count + servidorActividad5.cola.Count) / idFila;
        }
        public void calcularPromedioProductosSistema()
        {
             cliente1 = hayClienteServidor(servidorActividad1);
             cliente2 = hayClienteServidor(servidorActividad2);
             cliente3 = hayClienteServidor(servidorActividad3);
             cliente4 = hayClienteServidor(servidorActividad4);
             cliente5 = hayClienteServidor(servidorActividad5);

            promedioProductosSistema = (lineaAnterior.promedioProductosSistema + 
                servidorActividad1.cola.Count + cliente1 +
                servidorActividad2.cola.Count + servidorActividad2.colaDeposito.Count + cliente2 +
                servidorActividad3.cola.Count + servidorActividad3.colaDeposito.Count + cliente3 +
                servidorActividad4.cola.Count + servidorActividad3.colaDeposito.Count + cliente4 +
                servidorActividad5.cola.Count + servidorActividad5.colaDeposito.Count + cliente5) / idFila;
        }

        private double hayClienteServidor(ServidorActividad servidorActividad)
        {
            if (servidorActividad.estaOcupado())
            {
                return 1;
            }
            return 0;
        }

        public void calcularTiempoBloqueo()
        {
            if (lineaAnterior.servidorActividad5.estaBloqueado())
            {
                this.acumuladorTiemposBloqueo += (reloj - lineaAnterior.reloj);
            }
            
        }

        public void calcularTiempoOcupacion()
        {
            if (lineaAnterior.servidorActividad5.estaOcupado())
            {
                this.acumuladorTiemposOcupacion += (reloj - lineaAnterior.reloj);
            }
        }

        public void calcularProporcionBloqueoOcupacion()
        {
            if (this.acumuladorTiemposOcupacion == 0) { proporcionBloqueoOcupacion = 0; }
            else { proporcionBloqueoOcupacion = this.acumuladorTiemposBloqueo / this.acumuladorTiemposOcupacion; }
        }
        public  void calcularPromedioDuracionEnsamble()
        {
            if (lineaAnterior.cantidadProductos != this.cantidadProductos)
            {
                promedioDuracionEnsamble = this.reloj / cantidadProductos;
            }
        }
    }
}