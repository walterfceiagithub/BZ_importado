using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

using Entidades;

namespace Servicios
{

  public class ServiciosImportacion
  {
    private IConfiguration _config;

    public ServiciosImportacion(IConfiguration config)
    {
      _config = config;
    }

    /*
      00 - Titulo                        Dynamic Programming 
      01 - Subtitulo;                    A Computational Tool
      02 - Autores;                      Art Lew|Holger Mauch 
      03 - Editorial;                    Springer Science & Business Media
      04 - Fecha_Publicacion;            2006-10-09
      05 - ISBN_13;                      9783540370130
      06 - ISBN_10;                      3540370137
      07 - Paginas;                      379
      08 - Categorias;                   Computers
      09 - Tipo;                         BOOK
      10 - Lenguaje;                     en
      11 - Imagen;                       http://books.google.com/books/content?id=H_m59Mp1kkEC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api
      12 - Rating;
      13 - Opiniones;
      14 - Precio_Lista;                 6664.53
      15 - Moneda_Lista;                 ARS
      16 - Precio_Venta;                 4665.17
      17 - Moneda_Venta                  ARS

     */
    public void ImportarCSV(string archivo)
    {
      FileInfo fi = new FileInfo(archivo);

      //FileInfo fi1 = new FileInfo("C:\\autoexec.bat");

      bool existe = fi.Exists;

      //  var saltarLineas = _config["saltarLineas"];

      var saltarLineas = _config.GetValue<int>("saltarLineas");

      if (existe)
      {
        //  string interpolation
        //
        string mostrar =
          $"Tamaño del archivo: {fi.Length} bytes; Fecha de acceso: {fi.LastAccessTime:hh:mm yyyy*MM/dd}";

        //  LINQ
        //  inferencia de tipos...
        //
        var rdr = fi.OpenText();

        while (!rdr.EndOfStream)
        {
          if (saltarLineas > 0)
          {
            rdr.ReadLine();
            //  saltarLineas -= 5;  //  saltarLineas = saltarLineas - 5
            saltarLineas--;     //  saltarLineas = saltarLineas - 1

            continue;
          }
          Publicacion pub = new Publicacion();

          string linea = rdr.ReadLine();

          string[] campos = linea?.Split(';');
          
          //  Console.WriteLine(campos?[4]);

          if (campos != null && campos.Length == 18)
          {
            int? paginasReales;
            //  TipoPublicacion tp;

            pub.ISBN13 = campos[5];
            pub.Titulo = campos[0];

            if (Int32.TryParse(campos[7], out int paginas))
            {
              if (paginas == 0)
                paginasReales = null;
              else
                paginasReales = paginas;

              pub.Paginas = paginasReales;
              //  Console.WriteLine($"El libro tiene {(paginas == 0 ? "paginas no informadas":$"{paginas} paginas")}");
            }

            pub.Tipo = campos[9].ToUpper() switch
            {
              "BOOK" => TipoPublicacion.Libro,
              "MAGAZINE" => TipoPublicacion.Revista,
              _ => TipoPublicacion.Indefinido
            };

            /*
              switch (campos[9].ToUpper())
              {
                case "BOOK":
                  pub.Tipo = TipoPublicacion.Libro;
                  break;

                case "MAGAZINE":
                  pub.Tipo = TipoPublicacion.Revista;
                  break;

                default:
                  //  tp = null;
                  pub.Tipo = TipoPublicacion.Indefinido;
                  break;
              }
            */
          }
          else
          {
            Console.WriteLine($"ERROR EN LA LINEA ==> {linea}");
          }
          //  Console.WriteLine(linea);
        }
      }
      else
      {
        ApplicationException ex = new ApplicationException("El archivo no existe!!");

        throw ex;
      }
    }
  }
}
