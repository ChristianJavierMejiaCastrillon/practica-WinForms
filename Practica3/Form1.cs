using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void labelEtiqueta_MouseMove(object sender, MouseEventArgs e)
        {
            labelEtiqueta.BackColor = Color.Cyan;
            labelEtiqueta.Cursor = Cursors.Hand;
        }

        private void labelEtiqueta_MouseLeave(object sender, EventArgs e)
        {
            labelEtiqueta.BackColor = System.Drawing.SystemColors.Control;
            labelEtiqueta.Cursor = Cursors.Arrow;
        }
    }
}
