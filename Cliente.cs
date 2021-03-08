using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_No2_repaso_Joel_Gramajo
{
    class Cliente
    {
        string nit, nombre, direccion;

        public string Nit { get => nit; set => nit = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }

        public Cliente(string nit, string nombre, string dir)
        {
            this.nit = nit;
            this.nombre = nombre;
            this.direccion = dir;
        }
    }
}
