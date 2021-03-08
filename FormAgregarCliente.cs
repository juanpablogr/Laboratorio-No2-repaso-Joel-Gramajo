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
    public partial class FormAgregarCliente : Form
    {
        public delegate void puente();
        public event puente aEjecutar;

        List<Cliente> Cls = new List<Cliente>();
        string ClientesPath = Directory.GetCurrentDirectory() + "\\" + "Clientes.txt";

        public FormAgregarCliente()
        {
            InitializeComponent();
            LoadClientesToGrid();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Cls.FindIndex(p => p.Nit == textBox1.Text) == -1)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    StreamWriter sw = new StreamWriter(new FileStream(ClientesPath, FileMode.Append, FileAccess.Write));
                    sw.WriteLine(textBox1.Text + ";" + textBox2.Text + ";" + textBox3.Text);
                    sw.Close();

                    aEjecutar();
                    this.Dispose();
                }
                else MessageBox.Show("ERROR: Datos inválidos!");
            }
            else MessageBox.Show("ERROR: Un cliente con el nit ingresado ya existe!");
        }

        private void FormAgregarCliente_Load(object sender, EventArgs e)
        {

        }

        private void FormAgregarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            aEjecutar();
        }
    }
}
