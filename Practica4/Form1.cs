using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBoton_Click(object sender, EventArgs e)
        {
            if (textBoxApellido.Text == "")
                textBoxApellido.BackColor = Color.Red;
            else
                textBoxApellido.BackColor = System.Drawing.SystemColors.Control;
        }

        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textNuevo_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("Tiene " + textNuevo.Text.Length + " Caracteres");
        }
    }
}
