using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        // Atributos
        int alto;
        int ancho;

        // Constructor
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string barcode, int ancho, int alto) : base(titulo, autor, anio, numNormalizado, barcode)
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        // Propiedades
        public int Alto
        {
            get => this.alto;
        }
        public int Ancho
        {
            get => this.ancho;
        }
        public int Superficie
        {
            get
            {
                return this.Alto * this.Ancho;
            }
        }

        // Sobrecarga de Metodos
        public static bool operator ==(Mapa m1, Mapa m2)
        {
            return (m1.Barcode == m2.Barcode || (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor && m1.Anio == m2.Anio && m1.Superficie == m2.Superficie));
        }
        public static bool operator !=(Mapa m1, Mapa m2)
        {
            return !(m1 == m2);
        }

        // Metodos
        public override string ToString()
        {
            StringBuilder datosMapa = new StringBuilder();
            datosMapa.Append(base.ToString());
            datosMapa.AppendLine($"Superficie: {this.Alto} * {this.Ancho} = {this.Superficie} cm2.");
            return datosMapa.ToString();
        }
    }
}
