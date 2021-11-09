using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas.Soporte
{
    class RungeKutta
    {
        double a;
        double b;
        double c;
        double tiempo;
        double h;
        double x1;
        double x2;
        double k1;
        double k2;
        double k3;
        double k4;
        double l1;
        double l2;
        double l3;
        double l4;
        double[] lineaAnterior;
        double[] lineaActual;
        double contador;
        double iteracion;
        private Random aleatorio;

        public RungeKutta()
        {
            this.x1 = 0;
            this.x2 = 0;
            this.h = 0.05;
            this.lineaAnterior = new double[11];
            this.lineaActual = new double[11];
            this.b = 10;
            this.c = 5;
            aleatorio = new Random();
        }

        public double calcularFinEncastre(double tiempoInicial)
        {
            contador = 0;
            a = 0.5 + (2 - 0.5) * aleatorio.NextDouble();
            while (true)
            {
                if (iteracion == 0)
                {
                    tiempo = tiempoInicial;
                    x1 = 0;
                    x2 = 0;
                }
                if (iteracion > 0)
                {
                    tiempo += h;
                    x1 += (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                    x2 += (l1 + 2 * l2 + 2 * l3 + l4) / 6;
                }
                k1 = h * x2;
                l1 = h * (Math.Exp(-c * tiempo) - a * x2 - b * x1);
                k2 = h * (x2 + 0.5 * l1);
                l2 = h * (Math.Exp(-c * (tiempo + 0.5 * h)) - a * (x2 + 0.5 * l1) - b * (x1 + 0.5 * k1));
                k3 = h * (x2 + 0.5 * l2);
                l3 = h * (Math.Exp(-c * (tiempo + 0.5 * h)) - a * (x2 + 0.5 * l2) - b * (x1 + 0.5 * k2));
                k4 = h * (x2 + l3);
                l4 = h * (Math.Exp(-c * (tiempo + h)) - a * (x2 + l3) - b * (x1 + k3));

                if (x2 < 0 && lineaAnterior[6] > 0)
                {
                    contador++;
                }

                lineaActual[0] = tiempo;
                lineaActual[1] = x1;
                lineaActual[2] = k1;
                lineaActual[3] = k2;
                lineaActual[4] = k3;
                lineaActual[5] = k4;
                lineaActual[6] = x2;
                lineaActual[7] = l1;
                lineaActual[8] = l2;
                lineaActual[9] = l3;
                lineaActual[10] = l4;

                iteracion++;

                if (contador == 2)
                {
                    return lineaAnterior[0];
                }

                lineaAnterior = lineaActual;
            }
        }
    }
}
