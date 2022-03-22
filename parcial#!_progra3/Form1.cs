using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parcial

{
    public partial class Form1 : Form
    {
        List<Alumno> alumnos = new List<Alumno>();
        List<Inscripcion> inscripciones = new List<Inscripcion>();

        public Form1()
        {
            InitializeComponent();
        }
        private void CargarAlumnos()
        {
            FileStream stream = new FileStream("Alumnos.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);


            while (reader.Peek() > -1)
            {
                Alumno alumno = new Alumno();
                alumno.Carne = Convert.ToInt16(reader.ReadLine());
                alumno.nombre = reader.ReadLine();

                alumnos.Add(alumno);
            }
        }
        private void CargarInscripcion()
        {
            FileStream stream = new FileStream("Inscripcion.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);


            while (reader.Peek() > -1)
            {
                Inscripcion inscripcion = new Inscripcion();
                inscripcion.Carne2 = reader.ReadLine(); 
                inscripcion.Grado = reader.ReadLine();
                inscripcion.fecha1 = reader.ReadLine();

                inscripciones.Add(inscripcion);

            }
            reader.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void CargarGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = alumnos;

        }
            private void button1_Click(object sender, EventArgs e)
        {
            CargarAlumnos();
            CargarInscripcion();
            CargarGrid();

        }
    }
}
