using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colas
{
    public partial class Form1 : Form
    {
        double cantidad;
        double mostrarDesde;
        double mostrarHasta;

        double limInferiorActividad1;
        double limInferiorActividad2;
        double limInferiorActividad4;
        double limSuperiorActividad1;
        double limSuperiorActividad2;
        double limSuperiorActividad4;

        double mediaExponencialActividad3;
        double mediaExponencialActividad5;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void tomarDatos()
        {
            cantidad = double.Parse(cant.Text);
            mostrarDesde = double.Parse(desde.Text);
            mostrarHasta = double.Parse(hasta.Text);

            limInferiorActividad1 = double.Parse(limInferiorAct1.Text);
            limInferiorActividad2 = double.Parse(limInferiorAct2.Text);
            limInferiorActividad4 = double.Parse(limInferiorAct4.Text);

            limSuperiorActividad1 = double.Parse(limSuperiorAct1.Text);
            limSuperiorActividad2 = double.Parse(limSuperiorAct2.Text);
            limSuperiorActividad4 = double.Parse(limSuperiorAct4.Text);

            mediaExponencialActividad3 = double.Parse(mediaExpAct3.Text);
            mediaExponencialActividad5 = double.Parse(mediaExpAct5.Text);
        }
    }
}
