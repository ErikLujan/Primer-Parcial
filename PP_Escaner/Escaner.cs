using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{
    public class Escaner
    {
        // Atributos
        public enum Departamento
        {
            nulo, mapoteca, procesosTecnicos
        }
        public enum TipoDoc
        {
            mapa, libro
        }

        List<Documento> listaDocumentos;
        Departamento locacion;
        string marca;
        TipoDoc tipo;

        // Constructor 
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();

            if (tipo == TipoDoc.mapa)
            {
                this.locacion = Departamento.mapoteca;
            }
            else if (tipo == TipoDoc.libro)
            {
                this.locacion = Departamento.procesosTecnicos;
            }
            else
            {
                this.locacion = Departamento.nulo;
            }
        }

        // Propiedades
        public List<Documento> ListaDocumentos
        {
            get => this.listaDocumentos;
        }
        public Departamento Locacion
        {
            get => this.locacion;
        }
        public string Marca
        {
            get => this.marca;
        }
        public TipoDoc Tipo
        {
            get => this.tipo;
        }

        // Sobrecarga de Operadores
        public static bool operator ==(Escaner e, Documento d)
        {
            bool retorno = false;

            foreach (var doc in e.listaDocumentos)
            {
                if (doc == d)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }
        public static bool operator +(Escaner e, Documento d)
        {
            bool retorno = false;

            if (e != d && d.Estado == Documento.Paso.Inicio)
            {
                bool documentoExiste = e.listaDocumentos.Any(doc => doc.Barcode == d.Barcode); // --> Revisa si el documento existe en la lista

                if (!documentoExiste)
                {
                    if ((e.tipo == Escaner.TipoDoc.libro && d is Libro) || (e.tipo == Escaner.TipoDoc.mapa && d is Mapa))
                    {
                        e.listaDocumentos.Add(d);
                        e.CambiarEstadoDocumento(d);
                        retorno = true;
                    }
                }
            }
            return retorno;
        }

        // Metodos
        public bool CambiarEstadoDocumento(Documento d)
        {
            bool retorno = false;
            foreach (var doc in this.ListaDocumentos)
            {
                if (doc == d)
                {
                    retorno = doc.AvanzarEstado();
                }
            }
            return retorno;
        }
    }
}
