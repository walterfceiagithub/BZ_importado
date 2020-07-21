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
      app.Run();
    }
  }
}
