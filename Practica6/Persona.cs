using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica6
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }

        public Persona(string nombre, string apellido, int edad, string direccion)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Direccion = direccion;
        }

        public void Mostrar()
        {
            MessageBox.Show($"Nombre: {Nombre}\nApellido: {Apellido}\nEdad: {Edad}\nDirección: {Direccion}", "Detalles de la persona", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
