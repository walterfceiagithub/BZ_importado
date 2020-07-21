using System;
using System.Collections.Generic;
using System.Text;

//using Servicios;

namespace CLI
{
  public class Aplicacion
  {
    public string Archivo { get; set; }

    /// <summary>
    /// Ejecuta la aplicacion principal
    /// </summary>
    public void Run()
    {
      Servicios.ServiciosImportacion imp = 
        new Servicios.ServiciosImportacion();

      imp.ImportarCSV(Archivo);
      Console.ReadLine();
    }

  }
}
