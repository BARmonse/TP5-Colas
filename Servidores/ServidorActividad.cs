using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas.Servidores
{
    class ServidorActividad
    {
        string LIBRE = "libre";
        string OCUPADO = "ocupado";
        string BLOQUEADO = "bloqueado";

        public string estado { get; set; }
        public double finAtencion { get; set; }

        public Queue<Producto> cola;
        public Queue<Producto> colaDeposito;
        public Producto productoActual;

        public ServidorActividad()
        {
            this.estado = LIBRE;
            this.finAtencion = -1;
            this.cola = new Queue<Producto>();
            this.colaDeposito = new Queue<Producto>();
        }
        public Boolean tieneCola()
        {
            return cola.Count > 0;
        }
        public Boolean tieneColaDeposito()
        {
            return colaDeposito.Count > 0;
        }
        public void agregarFinAtencion(double tiempo)
        {
            this.finAtencion = tiempo;
            this.estado = OCUPADO;
        }
        public Boolean tieneFinAtencion()
        {
            return this.finAtencion > 0;
        }
        public double obtenerFinAtencion()
        {
            return finAtencion;
        }
        public void liberar()
        {
            this.estado = LIBRE;
            this.finAtencion = -1;
        }
        public void bloquear()
        {
            this.estado = BLOQUEADO;
            this.finAtencion = -1;
        }
        public Boolean estaOcupado()
        {
            return this.estado.Equals(OCUPADO);
        }
        public Boolean estaLibre()
        {
            return this.estado.Equals(LIBRE);
        }
        public Boolean estaBloqueado()
        {
            return this.estado.Equals(BLOQUEADO);
        }
        public Producto siguienteProducto()
        {
            return cola.Dequeue();
        }
        public Producto siguienteProductoDeposito()
        {
            return colaDeposito.Dequeue();
        }

        public Producto getProductoActual()
        {
            return this.productoActual;
        }

        public void agregarACola(Producto producto)
        {
            cola.Enqueue(producto);
        }
        public void agregarAColaDeposito(Producto producto)
        {
            colaDeposito.Enqueue(producto);
        }
    }
}
