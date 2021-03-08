using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_No2_repaso_Joel_Gramajo
{
    class Vehiculo
    {
        string placa, marca, color;
        int modelo;
        float precio_por_km;

        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Color { get => color; set => color = value; }
        public int Modelo { get => modelo; set => modelo = value; }
        public float Precio_por_km { get => precio_por_km; set => precio_por_km = value; }

        public Vehiculo(string placa, string marca, int modelo, string color, float preciokm)
        {
            this.placa = placa;
            this.marca = marca;
            this.modelo = modelo;
            this.color = color;
            this.precio_por_km = preciokm;
        }
    }
}
