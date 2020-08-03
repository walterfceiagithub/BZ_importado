using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Entidades;
using Microsoft.Extensions.Configuration;
using Servicios;

namespace CLI
{
  public class Aplicacion
  {
    public string Archivo { get; set; }

    private IConfiguration _config;

    public Aplicacion(IConfiguration config)
    {
      _config = config;
    }

    public bool FiltrarTipo(Publicacion p)
    {
      return p.Tipo == TipoPublicacion.Revista;
    }

    public bool FiltrarPaginas(Publicacion p)
    {
      return p.Paginas > 500;
    }

    /// <summary>
    /// Ejecuta la aplicacion principal
    /// </summary>
    public void Run()
    {
      int j = 10;
      //var nombre = _config["nombre"];

      ServiciosImportacion imp = new ServiciosImportacion(_config);

      IEnumerable<Publicacion> listaOriginal = imp.ImportarCSV(Archivo);

      //  AISLO LA EXPRESION LINQ (FLUENT)
      //

      //  var xx = Enumerable.All(listaOriginal, publicacion => true);

      //  var xxx = listaOriginal.Any(pub => pub.Tipo == TipoPublicacion.Revista);

      var filtrada = listaOriginal
        .Where((x) => x.Tipo == TipoPublicacion.Libro && x.Paginas > j) // IEnum<Publicacion>
        .Select((p) => new {p.Titulo, Hojas = p.Paginas}) // IEnumerable<????>
        .Where((pub) => pub.Titulo.Contains("prog", StringComparison.CurrentCultureIgnoreCase));

      //  ???? es un tipo anonimo que consiste de dos propiedades
      //  Titulo (string)
      //  Hojas (int?)
      foreach (var x in filtrada)
      {
        Console.WriteLine($"{x.Titulo} {x.Hojas}");
      }

      /*
            List<Publicacion> listaFiltrada = new List<Publicacion>();

            //  DELEGADO GENERICO
            //
            Func<Publicacion, bool> predicado = FiltrarPaginas;

            foreach (var l in listaOriginal)
            {
              if (predicado(l))
                listaFiltrada.Add(l);
            }
            foreach (Publicacion p in listaFiltrada)
            {
              Console.WriteLine($"{p.Titulo} {p.Paginas}");
            }
      */

      /*
            Publicacion --> bool

            (pub) => pub.Tipo == TipoPublicacion.Revista

      */



      /*
            //  CASTING TRADICIONAL QUE PUEDE PROVOCAR EXCEPCIONES SI NO SE PUEDE CONVERTIR
            //
            //  List<Publicacion> listaReal = (List<Publicacion>)lista ;

            List<Publicacion> listaReal = lista as List<Publicacion> ?? new List<Publicacion>();

            //  usamos throw para generar una excepcion propia
            //
            //  List<Publicacion> listaReal = lista as List<Publicacion> ?? throw new ApplicationException("");


            if (listaReal.Count >= 10)
            {
              Console.WriteLine($"{listaReal[10].Titulo}");
            }

            int i = 1;
            foreach (Publicacion p in lista)
            {
              Console.WriteLine($"{i++} -- {p.Titulo}");
            }
      */
      Console.ReadLine();
    }

  }
}

