using System;
using System.Collections.Generic;

namespace VentaComputadores.API.Data.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Dni { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}
