using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas
{
    class GestorColas
    {
        DataTable resultados;
        private Form1 pantallaResultados;
        private List<Object> lineaActual;
        private List<Object> lineaAnterior;

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
            tabla.Columns.Add("llegada pedido");
        }
        public void simular(double cantidad, int desde, int hasta, double limInferiorActividad1, double limSuperiorActividad1, double limInferiorActividad2, double limSuperiorActividad2, double mediaExponencialActividad3, double limInferiorActividad4, double limSuperiorActividad4, double mediaExponencialActividad5)
        {
            for (int i=1; i <= cantidad; i++)
            {

                

                lineaAnterior = lineaActual;
            }

            pantallaResultados.mostrarResultados(resultados);
        }
    }
}
