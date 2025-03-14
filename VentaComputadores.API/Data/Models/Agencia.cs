using System;
using System.Collections.Generic;

namespace VentaComputadores.API.Data.Models;

public partial class Agencia
{
    public int Nit { get; set; }

    public string? NombreAgencia { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? SitioWeb { get; set; }

    public virtual ICollection<Computador> Computadores { get; set; } = new List<Computador>();
}
