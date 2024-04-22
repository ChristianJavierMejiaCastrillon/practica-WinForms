using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica5
{
    public partial class Form1 : Form
    {
        
        // Lista para almacenar instancias de Persona
        private List<Persona> personas = new List<Persona>();
        // Variable para controlar si la carga de datos fue exitosa
        private bool cargaDatosExitosa = false;
        // Variable para controlar si se ha mostrado la advertencia de campos incompletos
        private bool advertenciaMostrada = false;
        // Variable para controlar si se ha mostrado los datos de la persona
        private bool ventanaDetallesMostrada = false;
        // Variable para controlar si la advertencia de campos incompletos se ha mostrado
        private bool ingreseCampos = false;

        public Form1()
        {
            InitializeComponent();
            buttonAceptar.Click += buttonAceptar_Click; // Asociar el evento de clic del botón al método btnAgregar_Click   
            textBox_Edad.KeyPress += textBoxEdad_KeyPress; // Suscribir al evento KeyPress

            // Adjuntar manejadores de eventos TextChanged para cada TextBox
            textBox_Nombre.TextChanged += textBox_Nombre_TextChanged;
            textBox_Apellido.TextChanged += textBox_Apellido_TextChanged;
            textBox_Edad.TextChanged += textBox_Edad_TextChanged;
            textBox_Direccion.TextChanged += textBox_Direccion_TextChanged;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {

            // Verificar si la ventana de detalles de persona se ha mostrado
            if (ventanaDetallesMostrada)
            {
                // Limpiar campos y resetear colores
                LimpiarCampos();

                // Marcar la ventana de detalles de persona como no mostrada
                ventanaDetallesMostrada = false;

                return; // Salir del método si la ventana de detalles de persona se ha mostrado
            }
            if (ingreseCampos == false)
            {
                // Verificar si todos los campos están completos
                if (string.IsNullOrWhiteSpace(textBox_Nombre.Text) ||
                string.IsNullOrWhiteSpace(textBox_Apellido.Text) ||
                string.IsNullOrWhiteSpace(textBox_Edad.Text) ||
                string.IsNullOrWhiteSpace(textBox_Direccion.Text))

                 // Marcar cambio el estado a verdadero si todos los campos estan diligenciados. con esto logro que el mensaje de campos incompletos se ejecute una sola vez.
                 ingreseCampos = true;
                {
                // Marcar en rojo los campos vacíos
                if (string.IsNullOrWhiteSpace(textBox_Nombre.Text))
                    textBox_Nombre.BackColor = Color.Red;

                if (string.IsNullOrWhiteSpace(textBox_Apellido.Text))
                    textBox_Apellido.BackColor = Color.Red;

                if (string.IsNullOrWhiteSpace(textBox_Edad.Text))
                    textBox_Edad.BackColor = Color.Red;

                if (string.IsNullOrWhiteSpace(textBox_Direccion.Text))
                    textBox_Direccion.BackColor = Color.Red;

                    //Mensaje que se lanza cuando falta algun o todos los campos por diligenciar
                    MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
                // Verificar si la edad es un número entero válido
                if (string.IsNullOrWhiteSpace(textBox_Edad.Text))
                {
                    //MessageBox.Show("Por favor, ingrese la edad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no se ingresó ninguna edad
                }

                string edadText = textBox_Edad.Text.Trim();

                if (!int.TryParse(edadText, out int edad))
                {
                    //MessageBox.Show("La edad debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si la conversión falla
                }

                // Si todos los campos están completos y la conversión de edad es exitosa, continuar con la lógica para agregar la persona
                // Crear una nueva instancia de Persona con los datos ingresados en los TextBox
                Persona persona = new Persona(textBox_Nombre.Text, textBox_Apellido.Text, edad, textBox_Direccion.Text);
                personas.Add(persona);
                MostrarEnListView(persona);

                // Mostrar los detalles de la persona en un MessageBox utilizando el método Mostrar de la clase Persona
                persona.Mostrar();

                // Marcar la ventana de detalles de persona como mostrada
                ventanaDetallesMostrada = true;

                // Limpiar campos y resetear colores
                LimpiarCampos();

                // Marcar la carga de datos como exitosa
                cargaDatosExitosa = true;

                // Mostrar mensaje de "Carga de datos terminada"
                MessageBox.Show("Carga de datos terminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);  
        }

    private void CargaExitosaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cargaDatosExitosa = false; // Restablecer cargaDatosExitosa cuando se cierra la ventana de carga exitosa
        }

        // Método para mostrar los datos de una persona en el ListView
        private void MostrarEnListView(Persona persona)
        {
            listViewDatos.Items.Add(persona.Nombre);
            listViewDatos.Items.Add(persona.Apellido);
            listViewDatos.Items.Add(persona.Edad.ToString());
            listViewDatos.Items.Add(persona.Direccion);
        }

        // Método para limpiar los campos de entrada
        private void LimpiarCampos()
        {
            textBox_Nombre.Clear();
            textBox_Apellido.Clear();
            textBox_Edad.Clear();
            textBox_Direccion.Clear();

            // Resetear el color de fondo de todos los campos a su estado normal
            textBox_Nombre.BackColor = SystemColors.Window;
            textBox_Apellido.BackColor = SystemColors.Window;
            textBox_Edad.BackColor = SystemColors.Window;
            textBox_Direccion.BackColor = SystemColors.Window;
        }

        private void textBoxEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (por ejemplo, borrar, retroceso)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Nombre_TextChanged(object sender, EventArgs e)
        {
            // Cambiar el color de fondo del TextBox a su color normal si el texto no está vacío
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = string.IsNullOrWhiteSpace(textBox.Text) ? Color.Red : SystemColors.Window;
        }

        private void textBox_Apellido_TextChanged(object sender, EventArgs e)
        {
            // Cambiar el color de fondo del TextBox a su color normal si el texto no está vacío
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = string.IsNullOrWhiteSpace(textBox.Text) ? Color.Red : SystemColors.Window;
        }

        private void textBox_Edad_TextChanged(object sender, EventArgs e)
        {
            // Cambiar el color de fondo del TextBox a su color normal si el texto no está vacío
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = string.IsNullOrWhiteSpace(textBox.Text) ? Color.Red : SystemColors.Window;
        }

        private void textBox_Direccion_TextChanged(object sender, EventArgs e)
        {
            // Cambiar el color de fondo del TextBox a su color normal si el texto no está vacío
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = string.IsNullOrWhiteSpace(textBox.Text) ? Color.Red : SystemColors.Window;
        }
    }
}
