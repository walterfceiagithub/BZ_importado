using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace CLI
{
  class Program
  {
    static void Main(string[] args)
    {
      //  JSON -- javascript object notation
      //
      var cfg = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("config.json")
        .AddCommandLine(args)
        .Build();

      //  DECLARACION
      Aplicacion app = new Aplicacion(cfg);

      //  ASIGNACION
      //
      
      app.Archivo = "d:\\libros.csv";
      try
      {
        app.Run();
        Console.WriteLine("Finalizado OK!");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        Console.WriteLine("Finalizado MAL!!!");
        //  app.Archivo = "nombre_archivo_que_seguro_existe";
        //  app.Run();
      }
    }
  }
}
