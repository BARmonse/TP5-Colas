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

        public int idFila;
        public int desde;
        public int hasta;
        public List<ServidorActividad> listaActividad;

        public Linea()
        {
            this.llegadaPedido = 0;
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
        }
        
        public ServidorActividad obtenerServidor1()
        {
            return (ServidorActividad)this.servidorActividad1.Clone();
        }
        public ServidorActividad obtenerServidor2()
        {
            return (ServidorActividad)this.servidorActividad2.Clone();
        }
        public ServidorActividad obtenerServidor3()
        {
            return (ServidorActividad)this.servidorActividad3.Clone();
        }
        public ServidorActividad obtenerServidor4()
        {
            return (ServidorActividad)this.servidorActividad4.Clone();
        }
        public ServidorActividad obtenerServidor5()
        {
            return (ServidorActividad)this.servidorActividad5.Clone();
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
                //colas.agregarColumna();
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
                this.llegadaPedido = reloj + (-90 * Math.Log(1-aleatorios.siguienteAleatorio()));
                return;
            }
            this.llegadaPedido = lineaAnterior.llegadaPedido;
        }
        public void calcularFinAtencion1(double a, double b)
        {
            //calcularTiempoOcupacion();
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
            //calcularTiempoOcupacion();
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
            //calcularTiempoOcupacion();
            calcularFinAtencion3EventoLlegadaCliente(servidorActividad3,media);
            calcularFinAtencion3EventoFinAtencion1();
            calcularFinAtencion3EventoFinAtencion2();
            calcularFinAtencion3EventoFinAtencion3(servidorActividad3,media);
            calcularFinAtencion3EventoFinAtencion4();
            calcularFinAtencion3EventoFinAtencion5();
            calcularFinAtencion3EventoConteo();
        }

        private void calcularFinAtencion1EventoLlegadaCliente(ServidorActividad servidorActividad, double a, double b)
        {
            if (this.evento.Equals(LLEGADA_PEDIDO))
            {
                Producto productoActual = buscarProductoLibre();
                if (lineaAnterior.servidorActividad1.estaOcupada())
                {
                    esperarAtencionServidor1(servidorActividad, productoActual);
                }
                else
                {
                    atenderServidor1(servidorActividad, productoActual, a, b);
                }
                return;
            }

        }
        private void calcularFinAtencion1EventoFinAtencion1(ServidorActividad servidorActividad, double a, double b)
        {
            if (this.evento.Equals(FIN_ATENCION1))
            {
                if (lineaAnterior.tieneColaServidor(servidorActividad))
                {
                    Producto productoActual = servidorActividad.siguienteCliente();
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
                if (lineaAnterior.servidorActividad2.estaOcupada())
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
                if (lineaAnterior.tieneColaServidor(servidorActividad))
                {
                    Producto productoActual = servidorActividad.siguienteCliente();
                    atenderServidor2(servidorActividad2, productoActual, a, b);
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
                if (lineaAnterior.servidorActividad3.estaOcupada())
                {
                    esperarAtencionServidor3(servidorActividad3, productoActual);
                }
                else
                {
                    atenderServidor3(servidorActividad3,productoActual, media);
                }
            }
        }
        private void calcularFinAtencion3EventoFinAtencion3(ServidorActividad servidorActividad, double media)
        {
            if (this.evento.Equals(FIN_ATENCION3))
            {
                if (lineaAnterior.tieneColaServidor(servidorActividad))
                {
                    Producto productoActual = servidorActividad.siguienteCliente();
                    atenderServidor3(servidorActividad2, productoActual,media);
                }
                else
                {
                    servidorActividad.liberar();
                }
            }
        }

        private void esperarAtencionServidor2(ServidorActividad servidorActividad, Producto productoActual)
        {
            servidorActividad.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad2));
            servidorActividad.agregarACola(productoActual);
            productoActual.esperarAtencionServidor2();
        }
        private void esperarAtencionServidor1(ServidorActividad servidorActividad, Producto productoActual)
        {
            servidorActividad.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad1));
            servidorActividad.agregarACola(productoActual);
            productoActual.esperarAtencionServidor1();
        }
        private void esperarAtencionServidor3(ServidorActividad servidorActividad, Producto productoActual)
        {
            servidorActividad.agregarFinAtencion(lineaAnterior.obtenerFinAtencionServidor(servidorActividad3));
            servidorActividad.agregarACola(productoActual);
            productoActual.esperarAtencionServidor3();
        }
        private void atenderServidor2(ServidorActividad servidorActividad,Producto productoActual, double a, double b)
        {
            productoActual.atenderServidor2();
            servidorActividad.agregarFinAtencion(this.reloj + a + (b - a) * aleatorios.siguienteAleatorio());
            servidorActividad.productoActual = productoActual;
        }
        private void atenderServidor1(ServidorActividad servidorActividad, Producto productoActual, double a, double b)
        {
            productoActual.atenderServidor1();
            servidorActividad.agregarFinAtencion(this.reloj + a + (b - a) * aleatorios.siguienteAleatorio());
            servidorActividad.productoActual = productoActual;
        }
        private void atenderServidor3(ServidorActividad servidorActividad,Producto productoActual,double media)
        {
            productoActual.atenderServidor3();
            servidorActividad.agregarFinAtencion(this.reloj + (-media * Math.Log(1 - aleatorios.siguienteAleatorio())));
            servidorActividad.productoActual = productoActual;
        }
        
        private Boolean tieneFinAtencion(ServidorActividad servidorActividad)
        {
            return servidorActividad1.tieneFinAtencion();
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

        private Boolean tieneColaServidor(ServidorActividad servidorActividad)
        {
            return servidorActividad.tieneCola();
        }
        private double obtenerFinAtencionServidor(ServidorActividad servidorActividad)
        {
            return servidorActividad.finAtencion;
        }
    }
}
