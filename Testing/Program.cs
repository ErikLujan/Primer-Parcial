using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Escaner;
using Entidades;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --> Instancias de Libro y Mapa
            Libro libroUno = new Libro("Yerma", "García Lorca, Federico", 1995, "1114", "22222", 27);
            Mapa mapaUno = new Mapa("Ciudad Autónoma de Buenos Aires", "Instituto de Geografia", 2022, "", "8888", 20, 30);
            Libro libroDos = new Libro("La Casa de Bernarda Alba", "García Lorca, Federico", 1945, "1115", "22223", 30);
            Mapa mapaDos = new Mapa("Provincia de Buenos Aires", "Instituto de Geografia", 2023, "", "8889", 25, 35);

            // --> Instancias de Escaner para libros y mapas
            Escaner escanerLibros = new Escaner("Marca Patito", Escaner.TipoDoc.libro);
            Escaner escanerMapas = new Escaner("Marca Acme", Escaner.TipoDoc.mapa);

            // --> Muestro los datos de los objetos
            Console.WriteLine("---[ Datos de cada documento ]---\n");
            Console.WriteLine(libroUno.ToString());
            Console.WriteLine(mapaUno.ToString());
            Console.WriteLine(libroDos.ToString());
            Console.WriteLine(mapaDos.ToString());

            // --> Prueba agregar un libro al escaner de libros
            if (escanerLibros + libroUno)
            {
                Console.WriteLine($"Se agrega al escaner el libro: \n--> {libroUno.Titulo}");
            }

            // --> Intenta agregar el mismo libro de nuevo
            if (!(escanerLibros + libroUno))
            {
                Console.WriteLine($"No se puede agregar el mismo libro al escaner: \n--> {libroUno.Titulo}");
            }

            // --> Prueb agregar un mapa al escaner de mapas
            if (escanerMapas + mapaUno)
            {
                Console.WriteLine($"Se agrega al escaner el mapa: \n--> {mapaUno.Titulo}");
            }

            // --> Intenta agregar el mismo mapa de nuevo
            if (!(escanerMapas + mapaUno))
            {
                Console.WriteLine($"No se puede agregar el mismo mapa al escaner: \n--> {mapaUno.Titulo}");

                // --> Prueba agregar un libro diferente al escáner de libros
                if (escanerLibros + libroDos)
                {
                    Console.WriteLine($"Se agrega al escaner el libro: \n--> {libroDos.Titulo}");
                }

                // --> Prueba agregar un mapa diferente al escáner de mapas
                if (escanerMapas + mapaDos)
                {
                    Console.WriteLine($"Se agrega al escaner el mapa: \n--> {mapaDos.Titulo}");
                }

                // --> Imprime los datos que hay en el escaner de libros
                Console.WriteLine("\n---[ Contenido del Escaner de libros ]---\n");
                foreach (var doc in escanerLibros.ListaDocumentos)
                {
                    Console.WriteLine(doc);
                }

                // --> Imprime los datos que hay en el escaner de mapas
                Console.WriteLine("---[ Contenido del Escaner de mapas ]---\n");
                foreach (var doc in escanerMapas.ListaDocumentos)
                {
                    Console.WriteLine(doc);
                }

                Console.ReadKey();
            }
        }
    }
}
