using System;
using System.Collections.Generic;
using System.Text;
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

    /// <summary>
    /// Ejecuta la aplicacion principal
    /// </summary>
    public void Run()
    {
      var nombre = _config["nombre"];

      ServiciosImportacion imp = new ServiciosImportacion(_config);

      imp.ImportarCSV(Archivo);

      Console.ReadLine();
    }

  }
}
