using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica6
{
    public partial class FormDatosPersona : Form
    {
        private List<Persona> personas = new List<Persona>();
        private bool mensajeMostrado = false; // Bandera para controlar si se ha mostrado el mensaje de campos incompletos
        private bool mensajeCargaMostrado = false;

        public FormDatosPersona()
        {
            InitializeComponent();
            buttonAceptar.Click += buttonAceptar_Click;
            textBoxEdad.KeyPress += textBoxEdad_KeyPress;

            // Establecer el color de fondo inicial de cada TextBox
            textBoxNombre.BackColor = SystemColors.Window;
            textBoxApellido.BackColor = SystemColors.Window;
            textBoxEdad.BackColor = SystemColors.Window;
            textBoxDireccion.BackColor = SystemColors.Window;

            // Suscribir al evento TextChanged para cada TextBox
            textBoxNombre.TextChanged += TextBox_TextChanged;
            textBoxApellido.TextChanged += TextBox_TextChanged;
            textBoxEdad.TextChanged += TextBox_TextChanged;
            textBoxDireccion.TextChanged += TextBox_TextChanged;

            // Suscribir al evento KeyDown para cada TextBox para evitar que reciban la tecla Enter
            textBoxNombre.KeyDown += textBox_KeyDown;
            textBoxApellido.KeyDown += textBox_KeyDown;
            textBoxEdad.KeyDown += textBox_KeyDown;
            textBoxDireccion.KeyDown += textBox_KeyDown;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
          
            // Verificar si hay campos vacíos
            bool camposVacios = string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                                string.IsNullOrWhiteSpace(textBoxApellido.Text) ||
                                string.IsNullOrWhiteSpace(textBoxEdad.Text) ||
                                string.IsNullOrWhiteSpace(textBoxDireccion.Text);

            // Cambiar el color de fondo de los TextBox vacíos a rojo
            if (!mensajeMostrado && camposVacios)
            {
                if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
                    textBoxNombre.BackColor = Color.Red;

                if (string.IsNullOrWhiteSpace(textBoxApellido.Text))
                    textBoxApellido.BackColor = Color.Red;

                if (string.IsNullOrWhiteSpace(textBoxEdad.Text))
                    textBoxEdad.BackColor = Color.Red;

                if (string.IsNullOrWhiteSpace(textBoxDireccion.Text))
                    textBoxDireccion.BackColor = Color.Red;

                // Mostrar el mensaje de campos incompletos solo si no se ha mostrado el mensaje de carga
                if (camposVacios && !mensajeCargaMostrado && !mensajeMostrado)
                {
                    MostrarMensaje("Por favor, complete todos los campos.", MessageBoxIcon.Warning);
                    mensajeMostrado = true; // Establecer la bandera como verdadera para indicar que el mensaje se ha mostrado
                }
                // Detener el procesamiento si hay campos vacíos, con esto logramos que al cargar una segunda persona se mantengan los campos en rojo si no estan diligenciados.
                return;
            }

            // Restablecer el color de fondo de los TextBox
            textBoxNombre.BackColor = SystemColors.Window;
            textBoxApellido.BackColor = SystemColors.Window;
            textBoxEdad.BackColor = SystemColors.Window;
            textBoxDireccion.BackColor = SystemColors.Window;

            mensajeMostrado = false;

            // Si hay campos incompletos, no continuar con el procesamiento
            if (camposVacios)
                return;

            bool camposIncompletos = !CamposCompletos();
            if (camposIncompletos && !mensajeCargaMostrado)
            {
                return;
            }

            if (camposIncompletos)
            {
                return;
            }

            if (!int.TryParse(textBoxEdad.Text, out int edad))
            {
                return;
            }

            Persona persona = new Persona(textBoxNombre.Text, textBoxApellido.Text, edad, textBoxDireccion.Text);
            personas.Add(persona);
            MostrarEnListView(persona);

            LimpiarCampos();
            mensajeCargaMostrado = true;
            
            MostrarMensaje("Carga de datos completada.", MessageBoxIcon.Information);
            // Restablecer la bandera cuando se muestra el mensaje de carga completada
            mensajeMostrado = false; 
        }

        //Este metodo verifica si todos los campos estan completos
        private bool CamposCompletos()
        {
            return !string.IsNullOrWhiteSpace(textBoxNombre.Text) &&
                   !string.IsNullOrWhiteSpace(textBoxApellido.Text) &&
                   !string.IsNullOrWhiteSpace(textBoxEdad.Text) &&
                   !string.IsNullOrWhiteSpace(textBoxDireccion.Text);
        }

        //Este metodo muestra un mensaje emergente, donde por referencia se le pasa "Carga de datos completada." y un una variable icono
        private void MostrarMensaje(string mensaje,MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, icono);
        }

        private void MostrarEnListView(Persona persona)
        {
            // Limpiar la ListView antes de agregar nuevos elementos, si lo comento se pueden visualizar todas las cargas en la list view y no se van a borrar
            //listViewDatosPersona.Items.Clear();

            // Crear grupos para separar cada carga de datos
            ListViewGroup grupoCarga = new ListViewGroup("Persona " + (listViewDatosPersona.Groups.Count + 1), HorizontalAlignment.Center);
            listViewDatosPersona.Groups.Add(grupoCarga);

            // Convertir los datos a mayúsculas antes de agregarlos
            string nombreMayusculas = persona.Nombre.ToUpper();
            string apellidoMayusculas = persona.Apellido.ToUpper();
            string edadMayusculas = persona.Edad.ToString().ToUpper();
            string direccionMayusculas = persona.Direccion.ToUpper();

            // Agregar elementos a la ListView y asignarlos al grupo correspondiente
            ListViewItem nombreItem = new ListViewItem("NOMBRE: " + nombreMayusculas);
            nombreItem.Group = grupoCarga;
            listViewDatosPersona.Items.Add(nombreItem);

            ListViewItem apellidoItem = new ListViewItem("APELLIDO: " + apellidoMayusculas);
            apellidoItem.Group = grupoCarga;
            listViewDatosPersona.Items.Add(apellidoItem);

            ListViewItem edadItem = new ListViewItem("EDAD: " + edadMayusculas);
            edadItem.Group = grupoCarga;
            listViewDatosPersona.Items.Add(edadItem);

            ListViewItem direccionItem = new ListViewItem("DIRECCION: " + direccionMayusculas);
            direccionItem.Group = grupoCarga;
            listViewDatosPersona.Items.Add(direccionItem);

            // Ajustar automáticamente el tamaño de las columnas al contenido
            listViewDatosPersona.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void LimpiarCampos()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                    textBox.BackColor = SystemColors.Window;
                }
            }
        }

        //Este metodo asegura que el textbox edad, solo reciba datos numericos
        private void textBoxEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }       

        //Este metodo se ejecuta cada vez que cambia el textbox en cualquier metodo, si esta vacio se pone en rojo si no su color se normaliza.
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            // Verificar si el texto está vacío o solo contiene espacios en blanco
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.BackColor = Color.Red; // Cambiar a color rojo si el texto está vacío o solo contiene espacios en blanco
            }
            else
            {
                // Restaurar el color de fondo normal solo si el texto no estaba vacío previamente
                if (textBox.BackColor == Color.Red)
                {
                    textBox.BackColor = SystemColors.Window;
                }
            }   
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar un mensaje de salida del formulario
            MessageBox.Show("Has salido del formulario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cerrar el formulario actual
            this.Close();
        }


        //Este metodo sirve para que la textbox no reciba la tecla enter.
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Suprime el comportamiento predeterminado de la tecla Enter
            }
        }
    }
}

