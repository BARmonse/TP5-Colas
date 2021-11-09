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
        private int cantidadProductos;
        private int indice;

        public GestorColas(Form1 pantallaResultados)
        {
            this.pantallaResultados = pantallaResultados;
            resultados = new DataTable();
            crearTabla(resultados);
        }

        private void crearTabla(DataTable tabla)
        {
            tabla.Columns.Add("i");//linea 0
            tabla.Columns.Add("evento");//linea 1
            tabla.Columns.Add("reloj");//linea 2
            tabla.Columns.Add("Proxima llegada");//linea 3
            tabla.Columns.Add("Estado servidor 1");//linea 4
            tabla.Columns.Add("Siguiente Fin atención 1");//linea 5
            tabla.Columns.Add("Cola servidor 1");//linea 6
            tabla.Columns.Add("Estado servidor 2");//linea 7
            tabla.Columns.Add("Siguiente Fin atención 2");//linea 8
            tabla.Columns.Add("Cola servidor 2");//linea 9
            tabla.Columns.Add("Depósito 2");//linea 10
            tabla.Columns.Add("Estado servidor 3");//linea 11
            tabla.Columns.Add("Siguiente Fin atención 3");//linea 12
            tabla.Columns.Add("Cola servidor 3");//linea 13
            tabla.Columns.Add("Depósito 3");//linea 14
            tabla.Columns.Add("Estado servidor 4");//linea 15
            tabla.Columns.Add("Siguiente Fin atención 4");//linea 16
            tabla.Columns.Add("Cola servidor 4");//linea 17
            tabla.Columns.Add("Depósito 4");//linea 18
            tabla.Columns.Add("Estado servidor 5");//linea 19
            tabla.Columns.Add("Siguiente Fin atención 5");//linea 20
            tabla.Columns.Add("Cola servidor 5");//linea 21
            tabla.Columns.Add("Depósito 5");//linea 22
            tabla.Columns.Add("Estado servidor Encastre");//linea 23
            tabla.Columns.Add("Siguiente Fin Encastre");//linea 24
            tabla.Columns.Add("Cola encastre");//linea 25
            tabla.Columns.Add("Productos ensamblados");//linea 26
            tabla.Columns.Add("Tiempos de espera Servidor1");//linea 27
            tabla.Columns.Add("Tiempos de espera Servidor2");//linea 28
            tabla.Columns.Add("Tiempos de espera Servidor3");//linea 29
            tabla.Columns.Add("Tiempos de espera Servidor4");//linea 30
            tabla.Columns.Add("Tiempos de espera Servidor5");//linea 31
            tabla.Columns.Add("Duración promedio de ensamble");//linea 32
            tabla.Columns.Add("Cola máxima servidor1");//linea 33
            tabla.Columns.Add("Cola máxima servidor2");//linea 34
            tabla.Columns.Add("Cola máxima servidor3");//linea 35
            tabla.Columns.Add("Cola máxima servidor4");//linea 36
            tabla.Columns.Add("Cola máxima servidor5");//linea 37
            tabla.Columns.Add("Cola máxima encastre");//linea 38
            tabla.Columns.Add("Promedio productos en cola de servidores");//linea 39
            tabla.Columns.Add("Promedio de productos en sistema");//linea 40
            tabla.Columns.Add("Porcentaje ocupación servidor1");//linea 41
            tabla.Columns.Add("Porcentaje ocupación servidor2");//linea 42
            tabla.Columns.Add("Porcentaje ocupación servidor3");//linea 43
            tabla.Columns.Add("Porcentaje ocupación servidor4");//linea 44
            tabla.Columns.Add("Porcentaje ocupación servidor5");//linea 45
            tabla.Columns.Add("Tiempo bloqueo servidor 5");//linea 46
            tabla.Columns.Add("Tiempo ocupación servidor 5");//linea 47
            tabla.Columns.Add("Bloqueo/Ocupacion servidor5");//linea 48
            tabla.Columns.Add("Productos ensamblados por hora");//linea 49
            tabla.Columns.Add("Probabilidad de completar 3 o más ensambles por hora");//linea 50
            tabla.Columns.Add("Horas transcurridas");//linea 51
            tabla.Columns.Add("Promedio ensambles por hora");//linea 52

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
                lineaActual.calcularTiempoBloqueo();
                lineaActual.calcularTiempoOcupacion();
                lineaActual.calcularSiguienteLlegada();
                lineaActual.calcularFinAtencion1(limInferiorActividad1,limSuperiorActividad1);
                lineaActual.calcularFinAtencion2(limInferiorActividad2,limSuperiorActividad2);
                lineaActual.calcularFinAtencion3(mediaExponencialActividad3);
                lineaActual.calcularFinAtencion4(limInferiorActividad4,limSuperiorActividad4);
                lineaActual.calcularFinAtencion5(mediaExponencialActividad5);
                lineaActual.calcularFinEnsamble();

                //Estadisticas
                lineaActual.calcularColasMaximas();
                lineaActual.calcularPorcentajeOcupacionServidores();
                lineaActual.calcularEnsamblesPorHora();
                lineaActual.calcularPromedioProductosCola();
                lineaActual.calcularPromedioProductosSistema();
 
                lineaActual.calcularProporcionBloqueoOcupacion();
                lineaActual.calcularPromedioDuracionEnsamble();

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
            row[10] = linea.servidorActividad2.colaDeposito.Count;
            row[11] = linea.servidorActividad3.estado;
            row[12] = linea.servidorActividad3.finAtencion.ToString() !="-1" ? truncador.truncar(linea.servidorActividad3.finAtencion).ToString() : "";
            row[13] = linea.servidorActividad3.cola.Count;
            row[14] = linea.servidorActividad3.colaDeposito.Count;
            row[15] = linea.servidorActividad4.estado;
            row[16] = linea.servidorActividad4.finAtencion.ToString() !="-1" ? truncador.truncar(linea.servidorActividad4.finAtencion).ToString() : "";
            row[17] = linea.servidorActividad4.cola.Count;
            row[18] = linea.servidorActividad4.colaDeposito.Count;
            row[19] = linea.servidorActividad5.estado;
            row[20] = linea.servidorActividad5.finAtencion.ToString() !="-1" ? truncador.truncar(linea.servidorActividad5.finAtencion).ToString() : "";
            row[21] = linea.servidorActividad5.cola.Count;
            row[22] = linea.servidorActividad5.colaDeposito.Count;
            row[23] = linea.servidorEncastre.estado;
            row[24] = linea.servidorEncastre.finAtencion.ToString() != "-1" ? truncador.truncar(linea.servidorEncastre.finAtencion).ToString() : "";
            row[25] = linea.servidorEncastre.cola.Count;
            row[26] = linea.cantidadProductos.ToString();
            row[27] = truncador.truncar(linea.acumuladorEsperaServidor1).ToString();
            row[28] = truncador.truncar(linea.acumuladorEsperaServidor2).ToString();
            row[29] = truncador.truncar(linea.acumuladorEsperaServidor3).ToString();
            row[30] = truncador.truncar(linea.acumuladorEsperaServidor4).ToString();
            row[31] = truncador.truncar(linea.acumuladorEsperaServidor5).ToString();
            row[32] = truncador.truncar(linea.promedioDuracionEnsamble).ToString();
            row[33] = linea.colaMaximaServidor1.ToString();
            row[34] = linea.colaMaximaServidor2.ToString();
            row[35] = linea.colaMaximaServidor3.ToString();
            row[36] = linea.colaMaximaServidor4.ToString();
            row[37] = linea.colaMaximaServidor5.ToString();
            row[38] = linea.colaEncastre.ToString();
            row[39] = truncador.truncar(linea.promedioProductosCola).ToString();
            row[40] = truncador.truncar(linea.promedioProductosSistema).ToString();
            row[41] = truncador.truncar(linea.porcentajeOcupacionServidor1).ToString();
            row[42] = truncador.truncar(linea.porcentajeOcupacionServidor2).ToString();
            row[43] = truncador.truncar(linea.porcentajeOcupacionServidor3).ToString();
            row[44] = truncador.truncar(linea.porcentajeOcupacionServidor4).ToString();
            row[45] = truncador.truncar(linea.porcentajeOcupacionServidor5).ToString();
            row[46] = truncador.truncar(linea.acumuladorTiemposBloqueo).ToString();
            row[47] = truncador.truncar(linea.acumuladorTiemposOcupacion).ToString();
            row[48] = truncador.truncar(linea.proporcionBloqueoOcupacion).ToString();
            row[49] = truncador.truncar(linea.ensamblesHora).ToString();
            row[50] = truncador.truncar(linea.probabilidad3Ensambles).ToString();
            row[51] = truncador.truncar(linea.horasTranscurridas).ToString();
            row[52] = truncador.truncar(linea.promedioEnsamblesHora).ToString();


            indice = 52;
            for (int j = 0; j < cantidadProductos; j++)
            {
                indice += 1;
                row[indice] = linea.productos[j].estado;
                indice += 1;
                row[indice] = linea.productos[j].horaLlegadaServidor.ToString() != "-1" ? truncador.truncar(linea.productos[j].horaLlegadaServidor).ToString() : ""; ;
            }
            resultados.Rows.Add(row);
        }

        public void agregarColumna()
        {
            cantidadProductos++;
            this.resultados.Columns.Add("estado" + cantidadProductos);
            this.resultados.Columns.Add("hora espera" + cantidadProductos);
        }
    }
}
