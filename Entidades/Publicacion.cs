using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
  public enum TipoPublicacion
  {
    Indefinido,
    Libro,
    Revista
  }

  public class Publicacion
  {
    public string ISBN13 { get; set; }

    public string Titulo { get; set; }

    public int? Paginas { get; set; }

    public TipoPublicacion Tipo { get; set; }
  }
}
