using Colas.Servidores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas
{
    class Producto
    {
        String ESPERANDO_SERVIDOR1 = "ES1";
        String ESPERANDO_SERVIDOR2 = "ES2";
        String ESPERANDO_SERVIDOR3 = "ES3";
        String ESPERANDO_SERVIDOR4 = "ES4";
        String ESPERANDO_SERVIDOR5 = "ES5";

        String SIENDO_PROCESADO_SERVIDOR1 = "SPS1";
        String SIENDO_PROCESADO_SERVIDOR2 = "SPS2";
        String SIENDO_PROCESADO_SERVIDOR3 = "SPS3";
        String SIENDO_PROCESADO_SERVIDOR4 = "SPS4";
        String SIENDO_PROCESADO_SERVIDOR5 = "SPS5";

        String EN_DEPOSITO1 = "ED1";
        String EN_DEPOSITO2 = "ED2";
        String EN_DEPOSITO4 = "ED4";
        String ESPERANDO_ENCASTRE = "EE";
        
        public string estado;
        public double tiempoEsperaCola;
        public double horaLlegadaServidor;
        
        public Producto()
        {
            this.estado = "";
            tiempoEsperaCola = 0;
            horaLlegadaServidor = 0;
        }
        public void esperarAtencionServidor1()
        {
            this.estado = ESPERANDO_SERVIDOR1;
        }
        public void esperarAtencionServidor2()
        {
            this.estado = ESPERANDO_SERVIDOR2;
        }
        public void esperarAtencionServidor3()
        {
            this.estado = ESPERANDO_SERVIDOR3;
        }
        public void esperarAtencionServidor4()
        {
            this.estado = ESPERANDO_SERVIDOR4;
        }
        public void esperarAtencionServidor5()
        {
            this.estado = ESPERANDO_SERVIDOR5;
        }

        public void atenderServidor1()
        {
            this.estado = SIENDO_PROCESADO_SERVIDOR1;
        }
        public void atenderServidor2()
        {
            this.estado = SIENDO_PROCESADO_SERVIDOR2;
        }
        public void atenderServidor3()
        {
            this.estado = SIENDO_PROCESADO_SERVIDOR3;
        }
        public void atenderServidor4()
        {
            this.estado = SIENDO_PROCESADO_SERVIDOR4;
        }
        public void atenderServidor5()
        {
            this.estado = SIENDO_PROCESADO_SERVIDOR5;
        }
        public void colocarDeposito1()
        {
            this.estado = EN_DEPOSITO1;
        }
        public void colocarDeposito2()
        {
            this.estado = EN_DEPOSITO2;
        }
        public void colocarDeposito3()
        {
            this.estado = ESPERANDO_ENCASTRE;
        }
        public void colocarDeposito4()
        {
            this.estado = EN_DEPOSITO4;
        }
        public void colocarDeposito5()
        {
            this.estado = ESPERANDO_ENCASTRE;
        }

        public Boolean estaLibre()
        {
            return this.estado == "";
        }
        public void limpiar()
        {
            estado = "";
            tiempoEsperaCola = 0;
            horaLlegadaServidor = -1;
        }
    }
}
