using Colas.Soporte;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colas
{
    class GestorColas
    {
        DataTable resultados;
        private Form1 pantallaResultados;
        private Linea lineaActual;
        private Truncador truncador;

        public GestorColas(Form1 pantallaResultados)
        {
            this.pantallaResultados = pantallaResultados;
            resultados = new DataTable();
            crearTabla(resultados);

        }

        private void crearTabla(DataTable tabla)
        {
            tabla.Columns.Add("i");
            tabla.Columns.Add("evento");
            tabla.Columns.Add("reloj");
            tabla.Columns.Add("Proxima llegada");
            tabla.Columns.Add("Estado servidor 1");
            tabla.Columns.Add("Siguiente Fin atención 1");
            tabla.Columns.Add("Cola servidor 1");
            tabla.Columns.Add("Estado servidor 2");
            tabla.Columns.Add("Siguiente Fin atención 2");
            tabla.Columns.Add("Cola servidor 2");
            tabla.Columns.Add("Estado servidor 3");
            tabla.Columns.Add("Siguiente Fin atención 3");
            tabla.Columns.Add("Cola servidor 3");
            tabla.Columns.Add("Estado servidor 4");
            tabla.Columns.Add("Siguiente Fin atención 4");
            tabla.Columns.Add("Cola servidor 4");
            tabla.Columns.Add("Estado servidor 5");
            tabla.Columns.Add("Siguiente Fin atención 5");
            tabla.Columns.Add("Cola servidor 5");
            truncador = new Truncador(2);
        }
        public void simular(double cantidad, int desde, int hasta, double limInferiorActividad1, double limSuperiorActividad1, double limInferiorActividad2, double limSuperiorActividad2, double mediaExponencialActividad3, double limInferiorActividad4, double limSuperiorActividad4, double mediaExponencialActividad5)
        {
            Linea lineaAnterior = new Linea();
            int i;

            agregarLinea(lineaAnterior, 0);

            for (i=1; i <= cantidad; i++)
            {
                lineaActual = new Linea(lineaAnterior, this, desde, hasta, i);
                lineaActual.calcularEvento();
                lineaActual.calcularSiguienteLlegada();
                lineaActual.calcularFinAtencion1(limInferiorActividad1,limSuperiorActividad1);
                lineaActual.calcularFinAtencion2(limInferiorActividad2,limSuperiorActividad2);
                lineaActual.calcularFinAtencion3(mediaExponencialActividad3);
                //lineaActual.calcularFinAtencion4(limInferiorActividad4,limSuperiorActividad4);
                //lineaActual.calcularFinAtencion5(mediaExponencialActividad5);

                lineaAnterior = lineaActual;
                if (i >= desde && i <= hasta)
                {
                    agregarLinea(lineaActual, i);
                }
            }
            //agregarLinea(lineaAnterior, lineaAnterior.idFila);
            pantallaResultados.mostrarResultados(resultados);
        }
        private void agregarLinea(Linea linea, int i)
        {
            DataRow row = resultados.NewRow();
            row[0] = i;
            row[1] = linea.evento;
            row[2] = truncador.truncar(linea.reloj);
            row[3] = truncador.truncar(linea.llegadaPedido);
            row[4] = linea.servidorActividad1.estado;
            row[5] = linea.servidorActividad1.finAtencion.ToString() !="-1" ? truncador.truncar(linea.servidorActividad1.finAtencion).ToString() : "";
            row[6] = linea.servidorActividad1.cola.Count;
            row[7] = linea.servidorActividad2.estado;
            row[8] = linea.servidorActividad2.finAtencion.ToString() !="-1" ? truncador.truncar(linea.servidorActividad2.finAtencion).ToString() : "";
            row[9] = linea.servidorActividad2.cola.Count;
            row[10] = linea.servidorActividad3.estado;
            row[11] = linea.servidorActividad3.finAtencion.ToString() !="-1" ? truncador.truncar(linea.servidorActividad3.finAtencion).ToString() : "";
            row[12] = linea.servidorActividad3.cola.Count;
            row[13] = linea.servidorActividad4.estado;
            row[14] = linea.servidorActividad4.finAtencion.ToString() !="-1" ? truncador.truncar(linea.servidorActividad4.finAtencion).ToString() : "";
            row[15] = linea.servidorActividad4.cola.Count;
            row[16] = linea.servidorActividad5.estado;
            row[17] = linea.servidorActividad5.finAtencion.ToString() !="-1" ? truncador.truncar(linea.servidorActividad5.finAtencion).ToString() : "";
            row[18] = linea.servidorActividad5.cola.Count;

            resultados.Rows.Add(row);
        }
    }
}
