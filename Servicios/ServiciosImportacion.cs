using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using System.IO;

namespace Servicios
{
  public class ServiciosImportacion
  {
    public void ImportarCSV(string archivo)
    {
      FileInfo fi = new FileInfo(archivo);

      //FileInfo fi1 = new FileInfo("C:\\autoexec.bat");

      bool existe = fi.Exists;

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
          string linea = rdr.ReadLine();

          Console.WriteLine(linea);
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
