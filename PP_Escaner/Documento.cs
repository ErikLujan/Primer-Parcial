using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Documento
    {
        // Atributos
        public enum Paso
        {
            Inicio, Distribuido, EnEscaner, EnRevision, Terminado
        }

        int anio;
        string autor;
        string barcode;
        Paso estado;
        string numNormalizado;
        string titulo;

        // Constructor
        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }

        // Propiedades
        public int Anio
        {
            get => this.anio;
        }
        public string Autor
        {
            get => this.autor;
        }
        public string Barcode
        {
            get => this.barcode;
        }
        public Paso Estado
        {
            get => this.estado;
        }
        protected string NumNormalizado
        {
            get => this.numNormalizado;
        }
        public string Titulo
        {
            get => this.titulo;
        }

        // Metodos
        public bool AvanzarEstado()
        {
            bool retorno = true;
            if (this.estado == Paso.Terminado)
            {
                retorno = false;
            }

            this.estado = (Paso)((int)estado + 1);
            return retorno;
        }
        public override string ToString()
        {
            StringBuilder datosDocumento = new StringBuilder();
            datosDocumento.AppendLine($"Titulo: {this.Titulo}");
            datosDocumento.AppendLine($"Autor: {this.Autor}");
            datosDocumento.AppendLine($"Año: {this.Anio}");
            datosDocumento.AppendLine($"Cód. de barras: {this.Barcode}");

            return datosDocumento.ToString();
        }
    }
}