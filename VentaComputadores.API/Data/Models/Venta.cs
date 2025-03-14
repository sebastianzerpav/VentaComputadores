using System;
using System.Collections.Generic;

namespace VentaComputadores.API.Data.Models;

public partial class Venta
{
    public int CodigoVenta { get; set; }

    public int? NumeroUnicoComputador { get; set; }

    public int? IdCliente { get; set; }

    public DateOnly? FechaVenta { get; set; }

    public decimal? PrecioComputador { get; set; }

    public decimal? PorcentajeDescuentoAplicado { get; set; }

    public decimal? PorcentajeImpuestosAplicados { get; set; }

    public decimal? TotalVenta { get; set; }

    public string? MetodoPago { get; set; }

    public string? Observaciones { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Computador? NumeroUnicoComputadorNavigation { get; set; }
}
