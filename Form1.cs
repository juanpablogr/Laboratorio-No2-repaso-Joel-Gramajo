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
    public partial class Form1 : Form
    {
        string ClientesPath = Directory.GetCurrentDirectory() + "\\" + "Clientes.txt";
        string VehiculosPath = Directory.GetCurrentDirectory() + "\\" + "Vehiculos.txt";
        string AlquileresPath = Directory.GetCurrentDirectory() + "\\" + "Alquileres.txt";
        
        List<Cliente> Cls = new List<Cliente>();
        List<Vehiculo> Vls = new List<Vehiculo>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAlquileresToGrid();
        }

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
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Cls;
            dataGridView1.Refresh();
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
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = Vls;
            dataGridView2.Refresh();
        }

        void LoadAlquileresToGrid()
        {
            LoadClientesToGrid();
            LoadVehiculosToGrid();

            StreamReader sr = new StreamReader(new FileStream(AlquileresPath, FileMode.OpenOrCreate, FileAccess.Read));

            List<GridAlquiler> ls = new List<GridAlquiler>();
            float max = -1;

            foreach (string line in sr.ReadToEnd().Split('\n'))
            {
                string[] pr = line.Split(';');
                if (line.Length != 0)
                {
                    int cidx = Cls.FindIndex(c => c.Nit == pr[0]);
                    Vehiculo vidx = Vls.Find(v => v.Placa == pr[1]);

                    ls.Add(new GridAlquiler(Cls[cidx].Nombre, vidx.Placa, vidx.Marca, vidx.Color, vidx.Modelo, vidx.Precio_por_km, DateTime.Parse(pr[3]), vidx.Precio_por_km * float.Parse(pr[4])));

                    float n = float.Parse(pr[4]);
                    if (n > max) max = n;
                }
            }

            sr.Close();

            if (max == -1) label5.Text = "0";
            else label5.Text = max.ToString();

            dataGridView3.DataSource = null;
            dataGridView3.DataSource = ls;
            dataGridView3.Refresh();
        }

        private void agregarNuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAgregarCliente formc = new FormAgregarCliente();
            formc.aEjecutar += new FormAgregarCliente.puente(RefreshUnlock);

            this.Enabled = false;
            formc.Show();
        }

        private void agregarNuevoVehículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIngresarVehiculo formv = new FormIngresarVehiculo();
            formv.aEjecutar += new FormIngresarVehiculo.puente(RefreshUnlock);

            this.Enabled = false;
            formv.Show();
        }

        public void RefreshUnlock()
        {
            LoadAlquileresToGrid();
            this.Enabled = true;
        }

        private void agregarNuevoAlquilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAgregarAlquiler forma = new FormAgregarAlquiler();
            forma.aEjecutar += new FormAgregarAlquiler.puente(RefreshUnlock);

            this.Enabled = false;
            forma.Show();
        }
    }
}
