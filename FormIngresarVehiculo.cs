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
    public partial class FormIngresarVehiculo : Form
    {
        public delegate void puente();
        public event puente aEjecutar;

        string VehiculosPath = Directory.GetCurrentDirectory() + "\\" + "Vehiculos.txt";
        
        List<Vehiculo> Vls = new List<Vehiculo>();

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

        public FormIngresarVehiculo()
        {
            InitializeComponent();
            LoadVehiculosToGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idx = Vls.FindIndex(p => p.Placa == textBox1.Text);

            if (idx == -1)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    StreamWriter sw = new StreamWriter(new FileStream(VehiculosPath, FileMode.Append, FileAccess.Write));
                    sw.WriteLine(textBox1.Text + ";" + textBox2.Text + ";" + textBox3.Text + ";" + textBox4.Text + ";" + textBox5.Text);
                    sw.Close();

                    aEjecutar();

                    this.Dispose();
                }
                else MessageBox.Show("ERROR: Datos inválidos!");
            }
            else MessageBox.Show("ERROR: Un vehículo con las placas ingresadas ya existe!");
        }

        private void FormIngresarVehiculo_FormClosing(object sender, FormClosingEventArgs e)
        {
            aEjecutar();
        }

        private void FormIngresarVehiculo_Load(object sender, EventArgs e)
        {

        }
    }
}
