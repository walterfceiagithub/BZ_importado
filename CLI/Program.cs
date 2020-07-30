using System;

namespace CLI
{
  class Program
  {
    static void Main(string[] args)
    {
      //  DECLARACION
      Aplicacion app ;

      //  ASIGNACION
      app = new Aplicacion();

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
