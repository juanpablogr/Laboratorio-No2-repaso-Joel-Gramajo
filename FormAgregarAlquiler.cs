using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Laboratorio_No2_repaso_Joel_Gramajo
{
    public partial class FormAgregarAlquiler : Form
    {
        public delegate void puente();
        public event puente aEjecutar;

        string AlquileresPath = Directory.GetCurrentDirectory() + "\\" + "Alquileres.txt";

        string ClientesPath = Directory.GetCurrentDirectory() + "\\" + "Clientes.txt";
        string VehiculosPath = Directory.GetCurrentDirectory() + "\\" + "Vehiculos.txt";
        
        List<Cliente> Cls = new List<Cliente>();
        List<Vehiculo> Vls = new List<Vehiculo>();

        void LoadClientesToGrid()
        {
            StreamReader sr = new StreamReader(new FileStream(ClientesPath, FileMode.OpenOrCreate, FileAccess.Read));

            Cls.Clear();

            foreach (string line in sr.ReadToEnd().Split('\n'))
            {
                string[] pr = line.Split(';');
                if (line.Length != 0)
                {
                    Cls.Add(new Cliente(pr[0], pr[1], pr[2]));
                }
            }

            sr.Close();
        }

        void LoadVehiculosToGrid()
        {
            StreamReader sr = new StreamReader(new FileStream(VehiculosPath, FileMode.OpenOrCreate, FileAccess.Read));

            Vls.Clear();

            foreach (string line in sr.ReadToEnd().Split('\n'))
            {
                string[] pr = line.Split(';');
                if (line.Length != 0)
                {
                    Vls.Add(new Vehiculo(pr[0], pr[1], int.Parse(pr[2]), pr[3], float.Parse(pr[4])));
                }
            }

            sr.Close();
        }


        public FormAgregarAlquiler()
        {
            InitializeComponent();
            LoadClientesToGrid();
            LoadVehiculosToGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Cls.FindIndex(p => p.Nit == textBox1.Text) != -1)
            {
                if (Vls.FindIndex(v => v.Placa == textBox2.Text) != -1)
                {
                    float n;
                    if (float.TryParse(textBox3.Text, out n))
                    {
                        StreamWriter sw = new StreamWriter(new FileStream(AlquileresPath, FileMode.Append, FileAccess.Write));
                        sw.WriteLine(textBox1.Text + ";" + textBox2.Text + ";" + dateTimePicker1.Value.ToString() + ";" + dateTimePicker2.Value.ToString() + ";" + textBox3.Text);
                        sw.Close();

                        aEjecutar();
                        this.Dispose();
                    }
                    else MessageBox.Show("ERROR: Datos inválidos!");
                }
                else MessageBox.Show("ERROR: No hay ningún vehículo con el número de placa ingresado!");
            }
            else MessageBox.Show("ERROR: No hay ningún cliente registrado con el nit ingresado");
        }

        private void FormAgregarAlquiler_FormClosing(object sender, FormClosingEventArgs e)
        {
            aEjecutar();
        }

        private void FormAgregarAlquiler_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = dateTimePicker2.Value;
        }
    }
}
