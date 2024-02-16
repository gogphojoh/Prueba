using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Prueba
{
    public class Tarjeta
    {
        public string Codigo { get; set; }
        public string Marca { get; set; }
        public string Placas { get; set; }
        public string Color { get; set; }

        public Tarjeta(string codigo, string marca, string placas, string color)
        {
            Codigo = codigo;
            Marca = marca;
            Placas = placas;
            Color = color;
        }
    }
}