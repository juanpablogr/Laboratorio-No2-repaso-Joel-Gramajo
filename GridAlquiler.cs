using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_No2_repaso_Joel_Gramajo
{
    class GridAlquiler
    {
        string nombre_del_cliente, placa, marca, color;
        int modelo;
        float precio_por_km;
        DateTime fecha_devolucion;
        float total_a_pagar;

        public string Nombre_del_cliente { get => nombre_del_cliente; set => nombre_del_cliente = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Color { get => color; set => color = value; }
        public int Modelo { get => modelo; set => modelo = value; }
        public float Precio_por_km { get => precio_por_km; set => precio_por_km = value; }
        public DateTime Fecha_devolucion { get => fecha_devolucion; set => fecha_devolucion = value; }
        public float Total_a_pagar { get => total_a_pagar; set => total_a_pagar = value; }

        public GridAlquiler(string nombrecliente, string placa, string marca, string color, int modelo, float preciokm, DateTime fecha_dev, float total)
        {
            this.nombre_del_cliente = nombrecliente;
            this.placa = placa;
            this.marca = marca;
            this.color = color;
            this.modelo = modelo;
            this.precio_por_km = preciokm;
            this.fecha_devolucion = fecha_dev;
            this.total_a_pagar = total;
        }
    }
}
