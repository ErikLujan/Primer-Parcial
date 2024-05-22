using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        // Atributo
        int numPaginas;

        // Constructor
        public Libro(string titulo, string autor, int anio, string numNormalizado, string barcode, int numPaginas) : base(titulo, autor, anio, numNormalizado, barcode)
        {
            this.numPaginas = numPaginas;
        }

        // Propiedades
        public string ISBN
        {
            get => this.NumNormalizado;
        }
        public int NumPaginas
        {
            get => this.numPaginas;
        }

        // Sobrecarga de Operadores
        public static bool operator ==(Libro l1, Libro l2)
        {
            return (l1.Barcode == l2.Barcode || l1.ISBN == l2.ISBN || (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor));
        }

        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }

        // Metodos
        public override string ToString()
        {
            StringBuilder datosLibro = new StringBuilder();
            datosLibro.Append(base.ToString());
            string datosString = datosLibro.ToString(); // --> Convierto el StringBuilder para encontrar la posicion adecuada.

            int posCodBarras = datosString.IndexOf("Cód. de barras:"); // --> Encuentra la posicion para ubicar el ISBN

            if (posCodBarras != -1) 
            {
                datosLibro.Insert(posCodBarras, $"ISBN: {this.ISBN}\n"); // --> Añade el ISBN antes del Codigo de barras.
            }
            datosLibro.AppendLine($"Número de Páginas: {this.NumPaginas}.");

            return datosLibro.ToString();
        }
    }
}