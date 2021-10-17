using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas.Servidores
{
    class ServidorActividad : ICloneable
    {
        string LIBRE = "libre";
        string OCUPADO = "ocupado";
        string BLOQUEADO = "bloqueado";

        public string estado { get; set; }
        public double finAtencion { get; set; }

        public Queue<Producto> cola;
        public Producto productoActual;

        public ServidorActividad()
        {
            this.estado = LIBRE;
            this.finAtencion = -1;
            this.cola = new Queue<Producto>();
        }
        public Boolean tieneCola()
        {
            return cola.Count > 0;
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
        public Boolean estaOcupada()
        {
            return this.estado.Equals(OCUPADO);
        }
        public object Clone()
        {
            ServidorActividad res = new ServidorActividad();
            res.estado = this.estado;
            res.finAtencion = this.finAtencion;
            res.productoActual = this.productoActual;
            Producto[] temp = new Producto[cola.Count];
            cola.CopyTo(temp, 0);
            res.cola = new Queue<Producto>(temp);

            return res;
        }
        public Producto siguienteCliente()
        {
            return cola.Dequeue();
        }

        public Producto getClienteActual()
        {
            return this.productoActual;
        }

        public void agregarACola(Producto producto)
        {
            cola.Enqueue(producto);
        }
    }
}
